using UnityEngine;

public class BarPosition : MonoBehaviour
{
    private Vector3 initialPosition;

    void Start()
    {
        // Save the initial position when the script starts
        initialPosition = transform.position;
    }

    public void SetToInitialPosition()
    {
        // Set the GameObject's position to the initial position instantly
        transform.position = initialPosition;
    }
}
