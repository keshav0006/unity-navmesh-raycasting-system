using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform vip;
    public float spawnDistance = 20f;
    public float timeBetweenSpawns = 3f;

    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeBetweenSpawns)
        {
            timer = 0f;
            SpawnEnemyAhead();
        }
    }

    void SpawnEnemyAhead()
    {
        if (vip == null) return;

        Vector3 forwardPos = vip.position + vip.forward * spawnDistance;
        forwardPos.y = -1f; // ground

        Instantiate(enemyPrefab, forwardPos, Quaternion.identity);
    }
}
