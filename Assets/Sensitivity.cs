using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sensitivity : MonoBehaviour
{
    public static string sens;
    public InputField inputField;

    public void Start()
    {
        // print("HERE " + StateNameController.sensitivity.ToString());
        sens = StateNameController.sensitivity.ToString();
        inputField.text = sens;
    }

    public void newSensitivity()
    {
        sens = inputField.text;
        StateNameController.sensitivity = float.Parse(sens);
    }
}
