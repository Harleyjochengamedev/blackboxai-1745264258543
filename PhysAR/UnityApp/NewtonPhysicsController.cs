using UnityEngine;

public class NewtonPhysicsController : MonoBehaviour
{
    public Rigidbody blockRigidbody;
    public float forceMagnitude = 10f;

    void Update()
    {
        // Apply force to the block when user presses space key (for testing)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 forceDirection = transform.forward; // Forward direction
            blockRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
            Debug.Log("Force applied to block: " + forceDirection * forceMagnitude);
        }
    }

    // Optional: Visualize force vector in the editor
    void OnDrawGizmos()
    {
        if (blockRigidbody != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(blockRigidbody.position, blockRigidbody.position + transform.forward * forceMagnitude);
        }
    }
}
