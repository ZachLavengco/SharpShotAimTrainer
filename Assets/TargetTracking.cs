using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTracking : MonoBehaviour
{
    public void Update()
    {
        if (Time.frameCount % 3 == 0)
        {
            StateNameController.currentPosition = transform.position;
            transform.position = TargetBoundsTracking.Instance.GetRandomPosition();
            if (StateNameController.changedDirection == true)
            {
                StateNameController.changedDirection = false;
            } else
            {
                StateNameController.lastPosition = StateNameController.currentPosition;
            }
        }
    }
}
