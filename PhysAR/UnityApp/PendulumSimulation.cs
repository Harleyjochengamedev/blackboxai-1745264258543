using UnityEngine;

public class PendulumSimulation : MonoBehaviour
{
    public Transform pivot;
    public float length = 2.0f;
    public float gravity = 9.81f;
    public float angle = 45.0f; // Initial angle in degrees

    private float angularVelocity = 0.0f;
    private float angularAcceleration = 0.0f;
    private float angleRad;

    void Start()
    {
        angleRad = angle * Mathf.Deg2Rad;
    }

    void Update()
    {
        // Simple pendulum physics
        angularAcceleration = (-gravity / length) * Mathf.Sin(angleRad);
        angularVelocity += angularAcceleration * Time.deltaTime;
        angleRad += angularVelocity * Time.deltaTime;

        // Damping
        angularVelocity *= 0.99f;

        // Update pendulum position
        Vector3 offset = new Vector3(length * Mathf.Sin(angleRad), -length * Mathf.Cos(angleRad), 0);
        transform.position = pivot.position + offset;
    }
}
