using UnityEngine;
using DG.Tweening;

public class DoMove : MonoBehaviour
{
    public Vector3 moveAmount = new Vector3(5f, 0f, 0f); // Amount to move in each axis
    public float moveTime = 2f; // Custom amount of time for the movement
    public Ease easeType = Ease.Linear; // Custom ease type for the movement

    private Vector3 startPosition; // Store the initial position

    void Start()
    {
        // Store the initial position
        startPosition = transform.position;

        // Call the Move method when the script starts
        //Move();
    }

    public void Move()
    {
        // Calculate the end position by adding the moveAmount to the initial position
        Vector3 endPosition = startPosition + moveAmount;

        // Use DoTween to move the object
        transform.DOMove(endPosition, moveTime)
            .SetEase(easeType)
            .OnComplete(() => Debug.Log("Movement completed")); // You can add additional actions when the movement is complete
    }

    public void MoveBack()
    {
        // Use DoTween to move the object back to the starting position
        transform.DOMove(startPosition, moveTime)
            .SetEase(easeType)
            .OnComplete(() => Debug.Log("Movement back completed")); // You can add additional actions when the movement back is complete
    }
}
