using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToNewSens : MonoBehaviour
{
    public void ChangeSens()
    {
        StateNameController.sensitivity = StateNameController.recommendedSens;
    }
}
