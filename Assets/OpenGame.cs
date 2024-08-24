using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGame : MonoBehaviour
{

    void Start()
    {
        StateNameController.currentPosition = new Vector3(0f, 0f, 0f);
        StateNameController.lastPosition = new Vector3(-1f, 0f, 0f);
        StateNameController.changedDirection = false;

        StateNameController.hitPosition = new Vector3(0f, 0f, 0f);

        StateNameController.round = 1;
        StateNameController.roundEnd = false;
        StateNameController.sensitivity = 0.7f;
        StateNameController.accuracyInt = 0;

        StateNameController.testSensitivity = 0.7f;
        StateNameController.nextTestSensitivity = 0.7f;
        StateNameController.testSensitivity_low = 0.5f;
        StateNameController.testSensitivity_mid = 0.7f;
        StateNameController.testSensitivity_high = 0.9f;

        StateNameController.tracking_sfScore_low = 0;
        StateNameController.flickshot_sfScore_low = 0;
        StateNameController.lineshot_sfScore_low = 0;
        StateNameController.lowSensAccuracy = 0f;
        StateNameController.lowSensScoreTotal = 0;

        StateNameController.flickshot_sfScore_mid = 0;
        StateNameController.tracking_sfScore_mid = 0;
        StateNameController.lineshot_sfScore_mid = 0;
        StateNameController.midSensAccuracy = 0f;
        StateNameController.midSensScoreTotal = 0;

        StateNameController.tracking_sfScore_high = 0;
        StateNameController.flickshot_sfScore_high = 0;
        StateNameController.lineshot_sfScore_high = 0;
        StateNameController.highSensAccuracy = 0f;
        StateNameController.highSensScoreTotal = 0;


        StateNameController.tracking_sfScore_r4 = 0;
        StateNameController.flickshot_sfScore_r4 = 0;
        StateNameController.lineshot_sfScore_r4 = 0;
        StateNameController.round4SensAccuracy = 0f;
        StateNameController.round4SensScoreTotal = 0;

        StateNameController.tracking_sfScore_r5 = 0;
        StateNameController.flickshot_sfScore_r5 = 0;
        StateNameController.lineshot_sfScore_r5 = 0;
        StateNameController.round5SensAccuracy = 0f;
        StateNameController.round5SensScoreTotal = 0;

        StateNameController.newLowSensScoreTotal = 0;
        StateNameController.newMidSensScoreTotal = 0;
        StateNameController.newHighSensScoreTotal = 0;

        StateNameController.recommendedSens = 0;

        SceneManager.LoadScene("TitleScreen");
    }
}
