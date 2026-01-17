using UnityEngine;
using UnityEngine.AI;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 3f;
    public float damagePerSecond = 10f;
    public float maxHealth = 50f;
    private float currentHealth;
    public Transform attackOrigin;

    private Transform vip;
    private NavMeshAgent agent;
    private VIPHealth vipHealth;
    private bool vipInRange;
    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        agent = GetComponent<NavMeshAgent>();
        vip = GameObject.FindGameObjectWithTag("VIP")?.transform;

        if (vip != null)
            vipHealth = vip.GetComponent<VIPHealth>();
    }

    void Update()
    {
        // Stop doing anything if enemy is dead
        if (isDead) return;

        if (vip == null || vipHealth == null) return;

        float distance = Vector3.Distance(
            (attackOrigin ? attackOrigin.position : transform.position),
            vip.position
        );

        if (distance <= attackRange)
        {
            vipInRange = true;
            agent.isStopped = true;
            AttackVIP();
        }
        else
        {
            vipInRange = false;
            agent.isStopped = false;
            agent.SetDestination(vip.position);
        }
    }

    void AttackVIP()
    {
        if (vipInRange && vipHealth != null)
        {
            vipHealth.TakeDamage(damagePerSecond * Time.deltaTime);
        }
    }

    // Called when enemy is shot
    public void TakeDamage(float amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Stop all logic immediately
    void Die()
    {
        isDead = true;

        // Stop movement and attacks instantly
        if (agent != null)
            agent.isStopped = true;

        // Optional: disable collider so bullets don’t hit again
        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        // Play death animation (if available)
        Animator anim = GetComponent<Animator>();
        if (anim != null)
            anim.SetTrigger("Die");

        // Destroy after delay (for animation)
        Destroy(gameObject, 1.5f);
    }
}
