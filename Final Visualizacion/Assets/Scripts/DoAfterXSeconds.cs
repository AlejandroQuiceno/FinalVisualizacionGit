using UnityEngine;
using UnityEngine.Events;

public class DoAfterXSeconds : MonoBehaviour
{
    public float delayInSeconds = 2f; // Time delay before calling the Unity Event
    public UnityEvent onTimerComplete; // Unity Event to be triggered after the delay

    private void OnEnable()
    {
        // Start the timer when the object is enabled
        Invoke("CallEvent", delayInSeconds);
    }

    private void CallEvent()
    {
        // Trigger the Unity Event
        onTimerComplete.Invoke();
    }
}
