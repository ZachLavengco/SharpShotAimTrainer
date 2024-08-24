using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBounds : MonoBehaviour
{
    public static TargetBounds Instance;
    [SerializeField] public string mode;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] BoxCollider col;

    public Vector3 GetRandomPosition(Vector3 lastPos)
    {
        Vector3 center = col.center + transform.position;

        float minX = 0f;
        float maxX = 0f;
        float minY = 0f;
        float maxY = 0f;
        float minZ = 0f;
        float maxZ = 0f;
        float randomX = 0f;
        float randomY = 0f;
        float randomZ = 0f;
        
        int randomXYpos = 0;

        if (mode == "Gridshot")
        {
            minX = center.x - col.size.x / .6f;
            maxX = center.x + col.size.x / .6f;
            minY = center.y - col.size.y / .6f;
            maxY = center.y + col.size.y / .6f;
            minZ = center.z - col.size.z / 3f;
            maxZ = center.z + col.size.z / 3f;

            randomX = Random.Range(minX, maxX);
            randomY = Random.Range(minY, maxY);
            randomZ = Random.Range(minZ, maxZ);
        } else if (mode == "Lineshot" || mode == "Lineshot_sfMode")
        {
            minX = center.x - col.size.x / .25f;
            maxX = center.x + col.size.x / .25f;
            randomX = Random.Range(minX, maxX);
            randomY = 0f;
            randomZ = 10f;
        } else if (mode == "Flickshot" || mode == "Flickshot_sfMode")
        {
            float[][] randomXYarr = new float[][]
            {
                new float[] { 3f, 0f },
                new float[] { -3f, 0f },
                new float[] { 0f, 3f },
                new float[] { 0f, -3f },
                new float[] { 2f, 2f },
                new float[] { -2f, 2f },
                new float[] { 2f, -2f },
                new float[] { -2f, -2f }

            };

            if (lastPos[0] == 0f && lastPos[1] == 0f)
            {
                randomXYpos = Random.Range(0, randomXYarr.Length);
                randomX = randomXYarr[randomXYpos][0];
                randomY = randomXYarr[randomXYpos][1];
            } else
            {
                randomX = 0f;
                randomY = 0f;
            }
            randomZ = 10f;
        }

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        //print("last: " + lastPos.ToString());
        //print("randomPosition: " + randomPosition.ToString());

        return randomPosition;
    }
}
