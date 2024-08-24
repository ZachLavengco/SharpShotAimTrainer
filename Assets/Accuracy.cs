using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accuracy : MonoBehaviour
{
    public Text accuracyText;
    private float accuracy;
    private float hit;
    private float miss;

    void Start()
    {
        hit = 0f;
        miss = 0f;
    }

    public void increaseHit(int newHit)
    {
        hit += newHit;
    }

    public void increaseMiss(int newMiss)
    {
        miss += newMiss;
    }

    public Text getAccuracy()
    {
        return accuracyText;
    }

    void Update()
    {
        if (hit == 0f && miss == 0f)
        {
            accuracyText.text = "Accuracy: ";
        } else
        {
            accuracy = (hit / (hit + miss))  * 100f;
            accuracyText.text = "Accuracy: " + accuracy.ToString("#") + "%";

            StateNameController.accuracy = "Accuracy: " + accuracy.ToString("#") + "%";
            StateNameController.accuracyInt = (int)accuracy;
        }
    }
}
