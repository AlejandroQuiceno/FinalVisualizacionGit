using UnityEngine;
using UnityEngine.Events;

public class PlayerEnterTrigger : MonoBehaviour
{
    // Unity Event to be invoked when a player enters the trigger
    public UnityEvent OnPlayerEnter;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Invoke the Unity event
            OnPlayerEnter.Invoke();
        }
    }
}
