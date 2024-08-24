using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTestSensitivities : MonoBehaviour
{
    public void ChangeStartSens()
    {
        if (StateNameController.sensitivity - .2f < .125f)
        {
            StateNameController.testSensitivity_low = StateNameController.sensitivity / 2f;
        }
        else
        {
            StateNameController.testSensitivity_low = StateNameController.sensitivity - .2f;
        }
        StateNameController.testSensitivity_mid = StateNameController.sensitivity;
        StateNameController.testSensitivity_high = StateNameController.sensitivity + .2f;
        StateNameController.nextTestSensitivity = StateNameController.testSensitivity_high;
        StateNameController.testSensitivity = StateNameController.sensitivity;
    }
}
