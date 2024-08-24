using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_sfResults : MonoBehaviour
{
    public Text scoreText;
    public Text accuracyText;
    public Text recommendedSensText;

    void Start()
    {
        scoreText.text = "Total Score:\n" + StateNameController.sensFinderTotalScore;
        accuracyText.text = "Avg Accuracy:\n" + StateNameController.sensFinderTotalAccuracy.ToString("#") + "%";
        recommendedSensText.text = "Recommended Sensivity: " + StateNameController.recommendedSens.ToString("#.#####");
    }
}
