using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBoundsTracking : MonoBehaviour
{
    public static TargetBoundsTracking Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] BoxCollider col;

    public Vector3 GetRandomPosition()
    {
        Vector3 center = col.center + transform.position;

        float minX = center.x - col.size.x / .1f;
        float maxX = center.x + col.size.x / .1f;
        float minY = center.y - col.size.y / .3f;
        float maxY = center.y + col.size.y / .3f;

        float randomX = 0f;
        float randomY = 0f;

        Vector3 currPosition = StateNameController.currentPosition;
        Vector3 lastPosition = StateNameController.lastPosition;

        float directionX = currPosition[0] - lastPosition[0];
        float directionY = currPosition[1] - lastPosition[1];

        if (directionX > 0f)  // going right
        {
            if (currPosition[0] >= maxX)
            {
                StateNameController.changedDirection = true;
                randomX = currPosition[0] - .085f;
            } else
            {
                randomX = currPosition[0] + .065f;
            }
        } else
        {
            if (currPosition[0] <= minX)
            {
                StateNameController.changedDirection = true;
                randomX = currPosition[0] + .085f;
            }
            else
            {
                randomX = currPosition[0] - .065f;
            }
        }

        if (directionY > 0f)  // going right
        {
            if (currPosition[1] >= maxY)
            {
                StateNameController.changedDirection = true;
                randomY = currPosition[1] - .02f;
            }
            else
            {
                randomY = currPosition[1] + .01f;
            }
        }
        else
        {
            if (currPosition[1] <= minY)
            {
                StateNameController.changedDirection = true;
                randomY = currPosition[1] + .02f;
            }
            else
            {
                randomY = currPosition[1] - .01f;
            }
        }

        Vector3 randomPosition = new Vector3(randomX, randomY, 10f);
        return randomPosition;
    }
}
