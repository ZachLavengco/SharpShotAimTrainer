using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetVariables : MonoBehaviour
{
    void Start()
    {
        StateNameController.lowSensAccuracy = 0f;
        StateNameController.lowSensScoreTotal = 0;
        StateNameController.midSensAccuracy = 0f;
        StateNameController.midSensScoreTotal = 0;
        StateNameController.highSensAccuracy = 0f;
        StateNameController.highSensScoreTotal = 0;
        StateNameController.round4SensAccuracy = 0f;
        StateNameController.round4SensScoreTotal = 0;
        StateNameController.round5SensAccuracy = 0f;
        StateNameController.round5SensScoreTotal = 0;
    }
}
