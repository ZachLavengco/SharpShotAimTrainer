using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] Text timer;
    [SerializeField] string screen;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        timer.text = (Mathf.Round(currentTime)).ToString();

        if (currentTime < 0)
        {
            SceneManager.LoadScene(screen);
        }
    }
}
