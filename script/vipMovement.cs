using UnityEngine;

public class VIPMovement : MonoBehaviour
{
    public Transform[] currentRoute;
    public float speed = 3f;
    private int waypointIndex = 0;

    private Animator anim;

    public void SetRoute(Transform[] route)
    {
        currentRoute = route;
        waypointIndex = 0;

        if (currentRoute != null && currentRoute.Length > 0)
            transform.position = currentRoute[0].position;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (currentRoute == null || currentRoute.Length == 0 || waypointIndex >= currentRoute.Length)
            return;

        Transform target = currentRoute[waypointIndex];
        Vector3 direction = (target.position - transform.position).normalized;

        
        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        
        if (direction != Vector3.zero)
        {
            Quaternion lookRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5f);
        }

        
        if (anim != null)
            anim.SetBool("isWalking", direction.magnitude > 0.1f);

        
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            waypointIndex++;

            if (waypointIndex >= currentRoute.Length)
            {
                
                Debug.Log("VIP reached destination!");

                if (anim != null)
                    anim.SetBool("isWalking", false);

                
                GameOverManager gameOver = FindFirstObjectByType<GameOverManager>();
                if (gameOver != null)
                    gameOver.TriggerGameOver();

                enabled = false; 
            }
        }
    }
}
