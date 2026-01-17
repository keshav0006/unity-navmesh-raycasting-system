using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform vip;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float triggerDistance = 15f;

    private bool[] spawned;

    void Start()
    {
        spawned = new bool[spawnPoints.Length];
    }

    void Update()
    {
        for(int i = 0; i < spawnPoints.Length; i++)
        {
            if(!spawned[i])
            {
                float dist = Vector3.Distance(vip.position, spawnPoints[i].position);
                
                if(dist <= triggerDistance)
                {
                    GameObject enemy = Instantiate(enemyPrefab, spawnPoints[i].position, Quaternion.identity);
                    spawned[i] = true;
                }
            }
        }
    }
}
