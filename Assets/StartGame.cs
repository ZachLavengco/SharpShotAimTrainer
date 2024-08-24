using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public void StartScene(string gameScreen)
    {
        if (gameScreen == "Tracking_sfMode" || gameScreen == "Flickshot_sfMode" || gameScreen == "Lineshot_sfMode")
        {
            updateRound();
            print(StateNameController.testSensitivity);
            // Set sensitivity for fourth set
            if (StateNameController.round == 3)
            {
                // set next sens for round 2
                StateNameController.nextTestSensitivity = StateNameController.testSensitivity_high;
            }
            else if (StateNameController.round == 4)
            {
                StateNameController.testSensitivity = StateNameController.testSensitivity_high;

                // set next sens for round 3
                StateNameController.nextTestSensitivity = StateNameController.testSensitivity_low;
            }
            else if (StateNameController.round == 7)
            {
                StateNameController.testSensitivity = StateNameController.testSensitivity_low;
            }
            else if (StateNameController.round == 10)
            {
                StateNameController.testSensitivity = StateNameController.testSensitivity_low;
            }
            else if (StateNameController.round == 13)
            {
                StateNameController.testSensitivity = StateNameController.testSensitivity_high;
            }
            // calculate scores
            else if (StateNameController.round == 16)
            {
                // total up scores and accuracy to see in result screen
                StateNameController.sensFinderTotalAccuracy = (int)((StateNameController.lowSensAccuracy + StateNameController.midSensAccuracy + StateNameController.highSensAccuracy + StateNameController.round4SensAccuracy + StateNameController.round5SensAccuracy)/15f);
                StateNameController.sensFinderTotalScore = StateNameController.tracking_sfScore_low + StateNameController.flickshot_sfScore_low + StateNameController.lineshot_sfScore_low + StateNameController.tracking_sfScore_mid + StateNameController.flickshot_sfScore_mid + StateNameController.lineshot_sfScore_mid + StateNameController.tracking_sfScore_high + StateNameController.flickshot_sfScore_high + StateNameController.lineshot_sfScore_high + StateNameController.tracking_sfScore_r4 + StateNameController.flickshot_sfScore_r4 + StateNameController.lineshot_sfScore_r4 + StateNameController.tracking_sfScore_r5 + StateNameController.flickshot_sfScore_r5 + StateNameController.lineshot_sfScore_r5;

                // find recommended sens
                StateNameController.round4SensScoreTotal = (StateNameController.tracking_sfScore_r4 + StateNameController.flickshot_sfScore_r4 + StateNameController.lineshot_sfScore_r4) * (int)StateNameController.round4SensAccuracy;
                StateNameController.round5SensScoreTotal = (StateNameController.tracking_sfScore_r5 + StateNameController.flickshot_sfScore_r5 + StateNameController.lineshot_sfScore_r5) * (int)StateNameController.round5SensAccuracy;

                // lowest sens best scores overall
                if (StateNameController.round4SensScoreTotal > StateNameController.round5SensScoreTotal && StateNameController.round4SensScoreTotal > StateNameController.midSensScoreTotal)
                {
                    float sensDiff = ((float)StateNameController.midSensScoreTotal / (float)(StateNameController.round4SensScoreTotal + StateNameController.midSensScoreTotal)) * (StateNameController.testSensitivity_mid - StateNameController.testSensitivity_low);
                    StateNameController.recommendedSens = StateNameController.testSensitivity_low + sensDiff;
                }
                // mid sens best scores overall, low sens second best
                else if (StateNameController.midSensScoreTotal > StateNameController.round5SensScoreTotal && StateNameController.midSensScoreTotal > StateNameController.round4SensScoreTotal && StateNameController.round4SensScoreTotal > StateNameController.round5SensScoreTotal)
                {
                    float sensDiff = ((float)StateNameController.round4SensScoreTotal / (float)(StateNameController.round4SensScoreTotal + StateNameController.midSensScoreTotal)) * (StateNameController.testSensitivity_low - StateNameController.testSensitivity_mid);
                    StateNameController.recommendedSens = StateNameController.testSensitivity_mid + sensDiff;
                }
                // mid sens best scores overall, high sens second best
                else if (StateNameController.midSensScoreTotal > StateNameController.round5SensScoreTotal && StateNameController.midSensScoreTotal > StateNameController.round4SensScoreTotal && StateNameController.round5SensScoreTotal > StateNameController.round4SensScoreTotal)
                {
                    float sensDiff = ((float)StateNameController.round5SensScoreTotal / (float)(StateNameController.round5SensScoreTotal + StateNameController.midSensScoreTotal)) * (StateNameController.testSensitivity_high - StateNameController.testSensitivity_mid);
                    StateNameController.recommendedSens = StateNameController.testSensitivity_mid + sensDiff;
                }
                // high sens best scores overall
                else if (StateNameController.round5SensScoreTotal > StateNameController.round4SensScoreTotal && StateNameController.round5SensScoreTotal > StateNameController.midSensScoreTotal)
                {
                    float sensDiff = ((float)StateNameController.midSensScoreTotal / (float)(StateNameController.round5SensScoreTotal + StateNameController.midSensScoreTotal)) * (StateNameController.testSensitivity_mid - StateNameController.testSensitivity_high);
                    StateNameController.recommendedSens = StateNameController.testSensitivity_high + sensDiff;
                }

                SceneManager.LoadScene("SensitivityFinderResults");
                return;
            }
        }
        SceneManager.LoadScene(gameScreen);
    }

    private void updateRound()
    {
        StateNameController.round += 1;
        StateNameController.roundText = "Round: " + StateNameController.round.ToString() + "/15";
    }
}
