using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer_sfMode : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 15f;

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
            if (StateNameController.round == 15)
            {
                // go to ending result screen
                SceneManager.LoadScene("Lineshot_sfModeResultsLast");
                return;
            }
            StateNameController.roundEnd = true;
            SceneManager.LoadScene(screen);
        }
    }
}
