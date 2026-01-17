using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverCanvas; 

    public void TriggerGameOver()
    {
        
        Debug.Log("Mission Complete!");
        Time.timeScale = 0f;
    }
}
