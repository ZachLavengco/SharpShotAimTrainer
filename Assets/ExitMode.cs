using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMode : MonoBehaviour
{
    public void clickedExit()
    {
        StateNameController.round = 0;
        StateNameController.roundText = "Round: " + StateNameController.round.ToString() + "/15";
    }
}
