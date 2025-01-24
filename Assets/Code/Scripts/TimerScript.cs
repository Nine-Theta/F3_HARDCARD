using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // Public variables for configuring the timer
    public float startTime = 60f; // Starting time (countdown starts from this value)
    public bool isCountdown = true; // Set to true for countdown, false for count up
    public Text timerText; // UI Text element to display the timer

    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        // Initialize the timer
        currentTime = isCountdown ? startTime : 0f;
    }

    void Update()
    {
        if (isRunning)
        {
            // Update the timer based on whether it's a countdown or count-up
            currentTime += isCountdown ? -Time.deltaTime : Time.deltaTime;

            // Stop the timer if countdown reaches zero
            if (isCountdown && currentTime <= 0)
            {
                currentTime = 0;
                isRunning = false;
            }

            // Update the timer display
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // Format the time as minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the UI Text element
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Optional: Method to start the timer
    public void StartTimer()
    {
        isRunning = true;
    }

    // Optional: Method to stop the timer
    public void StopTimer()
    {
        isRunning = false;
    }

    // Optional: Method to reset the timer
    public void ResetTimer()
    {
        currentTime = isCountdown ? startTime : 0f;
        UpdateTimerText();
    }
}
