using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController_sfMode : MonoBehaviour
{
    public Text scoreText;
    public Text accuracyText;
    public Text roundText;
    public Text sensText;

    private void Start()
    {
        scoreText.text = StateNameController.score;
        accuracyText.text = StateNameController.accuracy;
        roundText.text = StateNameController.roundText;
        sensText.text = "Current Sensivity: " + StateNameController.testSensitivity.ToString("#.###");
    }
}
