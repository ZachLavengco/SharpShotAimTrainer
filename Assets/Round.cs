using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public Text RoundText;
    private int round;

    void Start()
    {
        round = StateNameController.round;
        RoundText.text = StateNameController.roundText;
    }
}
