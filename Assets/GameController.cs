using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreText;
    public Text accuracyText;

    private void Start()
    {
        scoreText.text = StateNameController.score;
        accuracyText.text = StateNameController.accuracy;
    }
}
