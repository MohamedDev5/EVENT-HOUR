using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerForMap2 : MonoBehaviour {

    public float timeRemaining = 180;
    public GameObject objectToShow;
    public GameObject objectToHide;
    public Text countdownText;

    void Update () {
        if (timeRemaining > 0) {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        } else {
            objectToShow.SetActive(true);
            objectToHide.SetActive(false);
            countdownText.text = "Time's up!";
        }
    }

    void DisplayTime(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}