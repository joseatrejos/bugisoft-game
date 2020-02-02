using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField] float startingTime = 10;

    [SerializeField] Text countdownTxt;

    private void Start() {
        currentTime = startingTime;
    }

    private void Update() {
        currentTime -= 1 * Time.deltaTime;

        string currentTimeStr = currentTime.ToString("00.00");
        countdownTxt.text = currentTimeStr;
    }

}
