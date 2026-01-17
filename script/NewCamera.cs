using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;            // The VIP (player)
    public Vector3 offset = new Vector3(0, 3.5f, -5f); 
    public float followSpeed = 10f;     
    public float rotationSpeed = 5f;    
    public bool lookAtTarget = true;   

    void LateUpdate()
    {
        if (!target) return;

        
        Vector3 desiredPosition = target.position + target.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        
        if (lookAtTarget)
        {
            Quaternion lookRot = Quaternion.LookRotation(target.position + Vector3.up * 1.5f - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotationSpeed * Time.deltaTime);
        }
    }
}
