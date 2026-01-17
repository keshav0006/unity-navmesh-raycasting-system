using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VIPHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("UI References")]
    public Image fillImage; 

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (fillImage != null)
            fillImage.fillAmount = 1f;
    }

    public void TakeDamage(float amount)
    {
        if (isDead) return; 

        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth);

        if (fillImage != null)
            fillImage.fillAmount = currentHealth / maxHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("VIP died. Restarting game...");

       
        VIPMovement vipMovement = GetComponent<VIPMovement>();
        if (vipMovement != null)
            vipMovement.enabled = false;

        
        EnemyAttack[] enemies = FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None);
        foreach (EnemyAttack enemy in enemies)
        {
            enemy.enabled = false;

            
            var agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent != null)
                agent.isStopped = true;
        }

       
        Time.timeScale = 1f;

       
        Invoke(nameof(RestartGame), 3f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
