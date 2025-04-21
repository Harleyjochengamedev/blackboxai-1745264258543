using UnityEngine;

public class ProjectileMotion : MonoBehaviour
{
    public float initialSpeed = 10f;
    public float launchAngle = 45f; // degrees
    private Vector3 velocity;
    private Vector3 startPosition;
    private float time;

    void Start()
    {
        startPosition = transform.position;
        float angleRad = launchAngle * Mathf.Deg2Rad;
        velocity = new Vector3(initialSpeed * Mathf.Cos(angleRad), initialSpeed * Mathf.Sin(angleRad), 0);
        time = 0f;
    }

    void Update()
    {
        time += Time.deltaTime;
        Vector3 displacement = new Vector3(
            velocity.x * time,
            velocity.y * time - 0.5f * 9.81f * time * time,
            0
        );
        transform.position = startPosition + displacement;

        // Optional: Destroy object when it falls below start height
        if (transform.position.y < startPosition.y)
        {
            Destroy(gameObject);
        }
    }
}
