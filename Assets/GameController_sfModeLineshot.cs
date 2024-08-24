using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController_sfModeLineshot : MonoBehaviour
{
    public Text scoreText;
    public Text accuracyText;
    public Text roundText;
    public Text sensText;
    public Text nextSensText;

    private void Start()
    {
        CalculateSens();
        scoreText.text = StateNameController.score;
        accuracyText.text = StateNameController.accuracy;
        roundText.text = StateNameController.roundText;
        sensText.text = "Current Sensivity: " + StateNameController.testSensitivity.ToString("#.###");
        nextSensText.text = "Next Round Sensivity: " + StateNameController.nextTestSensitivity.ToString("#.###");
    }

    private void CalculateSens()
    {
        if (StateNameController.round == 9)
        {
            // set sensitivity settings for round 4
            StateNameController.lowSensScoreTotal = (StateNameController.tracking_sfScore_low + StateNameController.flickshot_sfScore_low + StateNameController.lineshot_sfScore_low) * (int)StateNameController.lowSensAccuracy;
            StateNameController.midSensScoreTotal = (StateNameController.tracking_sfScore_mid + StateNameController.flickshot_sfScore_mid + StateNameController.lineshot_sfScore_mid) * (int)StateNameController.midSensAccuracy;
            StateNameController.highSensScoreTotal = (StateNameController.tracking_sfScore_high + StateNameController.flickshot_sfScore_high + StateNameController.lineshot_sfScore_high) * (int)StateNameController.highSensAccuracy;

            // lowest sens best scores overall
            if (StateNameController.lowSensScoreTotal > StateNameController.highSensScoreTotal && StateNameController.lowSensScoreTotal > StateNameController.midSensScoreTotal)
            {
                float lowSense = StateNameController.testSensitivity_low;
                StateNameController.testSensitivity_mid = StateNameController.testSensitivity_low;

                // won't let low sens go below .125
                if (StateNameController.testSensitivity_mid - .1f < .125f)
                {
                    StateNameController.testSensitivity_low = StateNameController.testSensitivity_mid / 2f;
                }
                else
                {
                    StateNameController.testSensitivity_low = lowSense - .1f;
                }

                StateNameController.testSensitivity_high = lowSense + .1f;
                StateNameController.midSensScoreTotal = StateNameController.lowSensScoreTotal;
            }
            // mid sens best scores overall, low sense second best
            else if (StateNameController.midSensScoreTotal > StateNameController.highSensScoreTotal && StateNameController.midSensScoreTotal > StateNameController.lowSensScoreTotal && StateNameController.lowSensScoreTotal > StateNameController.highSensScoreTotal)
            {
                if (StateNameController.testSensitivity_mid - .2f < .125f)
                {
                    StateNameController.testSensitivity_low = StateNameController.testSensitivity_mid / 2f;
                }
                else
                {
                    StateNameController.testSensitivity_low = StateNameController.testSensitivity_mid - .2f;
                }
                StateNameController.testSensitivity_high = StateNameController.testSensitivity_mid + .05f;
            }
            // mid sens best scores overall, high sense second best
            else if (StateNameController.midSensScoreTotal > StateNameController.highSensScoreTotal && StateNameController.midSensScoreTotal > StateNameController.lowSensScoreTotal && StateNameController.highSensScoreTotal > StateNameController.lowSensScoreTotal)
            {
                if (StateNameController.testSensitivity_mid - .05f < .125f)
                {
                    StateNameController.testSensitivity_low = StateNameController.testSensitivity_mid / 2f;
                }
                else
                {
                    StateNameController.testSensitivity_low = StateNameController.testSensitivity_mid - .05f;
                }
                StateNameController.testSensitivity_high = StateNameController.testSensitivity_mid + .2f;
            }
            // high sens best scores overall
            else if (StateNameController.highSensScoreTotal > StateNameController.lowSensScoreTotal && StateNameController.highSensScoreTotal > StateNameController.midSensScoreTotal)
            {
                float highSense = StateNameController.testSensitivity_high;
                StateNameController.testSensitivity_mid = StateNameController.testSensitivity_high;
                StateNameController.testSensitivity_low = highSense - .1f;
                StateNameController.testSensitivity_high = highSense + .1f;
                StateNameController.newMidSensScoreTotal = StateNameController.highSensScoreTotal;
            }
            // weird results do this
            else
            {
                if (StateNameController.testSensitivity_mid - .1f < .125f)
                {
                    StateNameController.testSensitivity_low = StateNameController.testSensitivity_mid / 2f;
                }
                else
                {
                    StateNameController.testSensitivity_low = StateNameController.testSensitivity_mid - .1f;
                }
                StateNameController.testSensitivity_high = StateNameController.testSensitivity_mid + .1f;
            }

            // set next sens for round 4
            StateNameController.nextTestSensitivity = StateNameController.testSensitivity_low;
        } 
        else if (StateNameController.round == 12)
        {
            // set sens for round 5
            StateNameController.nextTestSensitivity = StateNameController.testSensitivity_high;
        }
    }
}