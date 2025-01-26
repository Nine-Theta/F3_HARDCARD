using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Rive;
using Rive.Components;
using UnityEditorInternal;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Timer : MonoBehaviour
{
    // Public variables for configuring the timer
    public float startTime = 60f; // Starting time (countdown starts from this value)
    public bool isCountdown = true; // Set to true for countdown, false for count up
    public TMP_Text timerText; // UI Text element to display the timer
    [SerializeField] private RiveWidget m_riveWidget;



    private float currentTime;
    private bool isRunning = true;

    void Start()
    {
        // Initialize the timer
        currentTime = isCountdown ? startTime : 0f;
        StartTimer();
    }

    void Update()
    {
        if (isRunning)
        {
            // Update the timer based on whether it's a countdown or count-up
            currentTime += isCountdown ? -Time.deltaTime : Time.deltaTime;

            // Stop the timer if countdown reaches zero

            if (isCountdown && currentTime <= 30)
            {
                if (isCountdown && currentTime <= 0)
                {
                    StopTimer();
                }
                else
                {
                    timerAlarm();
                }
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

        SMINumber someNumber = m_riveWidget.StateMachine.GetNumber("state");
        if (someNumber == null) return;
        someNumber.Value = 1;
    }

    // Optional: Method to stop the timer
    public void StopTimer()
    {
        currentTime = 0;
        isRunning = false;

        SMINumber someNumber = m_riveWidget.StateMachine.GetNumber("state");
        if (someNumber == null) return;
        someNumber.Value = 3;

        timerText.color = new UnityEngine.Color(0, 1, 0);
        ChangeScene(2);
    }

    public void ChangeScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    // Optional: Method to reset the timer
    public void ResetTimer()
    {
        currentTime = isCountdown ? startTime : 0f;
        UpdateTimerText();

        SMINumber someNumber = m_riveWidget.StateMachine.GetNumber("state");
        if (someNumber == null) return;
        someNumber.Value = 0;

        timerText.color = new UnityEngine.Color(1, 0, 0);

    }

    public void timerAlarm()
    {
        SMINumber someNumber = m_riveWidget.StateMachine.GetNumber("state");
        if (someNumber == null) return;
        someNumber.Value = 2;
    }
}
