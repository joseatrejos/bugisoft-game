using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField] float startingTime = 10;

    [SerializeField] Text countdownTxt;
    [SerializeField] bool active = true;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        if (active)
        {
            currentTime -= 1 * Time.deltaTime;

            string currentTimeStr = currentTime.ToString("00.00");
            countdownTxt.text = currentTimeStr;
        }
    }

}
