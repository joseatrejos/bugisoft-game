using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Countdown : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField] float startingTime = 10;

    [SerializeField] TextElement countdownTxt;

    private void Start() {
        currentTime = startingTime;
    }

    private void Update() {
        currentTime -= 1 * Time.deltaTime;
        countdownTxt.text = currentTime.ToString();
    }

}
