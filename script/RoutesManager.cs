using UnityEngine;

public class RoutesManager : MonoBehaviour
{
    public Transform[] route1;
    public Transform[] route2;
    public Transform[] route3;

    public VIPMovement vip;

    void Start()
    {
        Transform[][] allRoutes = new Transform[][] { route1, route2, route3 };
        
        int randomIndex = Random.Range(0, allRoutes.Length);

        vip.SetRoute(allRoutes[randomIndex]);
        Debug.Log("Selected Route: " + randomIndex);
    }
}
