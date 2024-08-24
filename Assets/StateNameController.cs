using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateNameController : MonoBehaviour
{
    public static string score;
    public static string accuracy;
    public static int accuracyInt;
    public static int round;
    public static bool roundEnd;
    public static string roundText;
    public static float sensitivity;

    public static Vector3 hitPosition;

    public static Vector3 currentPosition;
    public static Vector3 lastPosition;
    public static bool changedDirection;

    // Sensitivity finder
    public static float testSensitivity_low;
    public static float testSensitivity_mid;
    public static float testSensitivity_high;
    public static float testSensitivity;
    public static float nextTestSensitivity;

    public static int tracking_sfScore_low;
    public static int flickshot_sfScore_low;
    public static int lineshot_sfScore_low;
    public static float lowSensAccuracy;
    public static int lowSensScoreTotal;

    public static int tracking_sfScore_mid;
    public static int flickshot_sfScore_mid;
    public static int lineshot_sfScore_mid;
    public static float midSensAccuracy;
    public static int midSensScoreTotal;

    public static int tracking_sfScore_high;
    public static int flickshot_sfScore_high;
    public static int lineshot_sfScore_high;
    public static float highSensAccuracy;
    public static int highSensScoreTotal;

    public static int lineshot_sfScore_r4;
    public static int flickshot_sfScore_r4;
    public static int tracking_sfScore_r4;
    public static float round4SensAccuracy;
    public static int round4SensScoreTotal;

    public static int lineshot_sfScore_r5;
    public static int flickshot_sfScore_r5;
    public static int tracking_sfScore_r5;
    public static float round5SensAccuracy;
    public static int round5SensScoreTotal;

    public static int newLowSensScoreTotal;
    public static int newMidSensScoreTotal;
    public static int newHighSensScoreTotal;

    public static int sensFinderTotalScore;
    public static int sensFinderTotalAccuracy;
    public static float recommendedSens;

    //public static string currentGameScore;
    //public static string currentGameAccuracy;
    //public static string totalGridshotGames;
    //public static string avgGridshotScore;
    //public static string avgGridshotAccuracy;
}
