using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    public Transform vip;  // Drag VIP here in Inspector
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

       
        if (vip == null)
        {
            GameObject vipObj = GameObject.FindGameObjectWithTag("VIP");

            if (vipObj != null)
            {
                vip = vipObj.transform;
            }
            else
            {
                Debug.LogWarning("VIP not assigned to EnemyFollow and no object with tag 'VIP' found!");
            }
        }
    }

    void Update()
    {
        // Follow VIP only if reference exists
        if (vip != null)
        {
            agent.SetDestination(vip.position);
        }
    }
}
