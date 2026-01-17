using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target; // VIP follow target
    public Vector3 offset = new Vector3(0, 5, -8);
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // Desired position based on target + offset
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Look at the target
        transform.LookAt(target);
    }
}
