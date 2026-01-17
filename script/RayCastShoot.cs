using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    public Camera mainCam;
    public float range = 100f;
    public LayerMask enemyLayer;
    

    void Start()
    {
        if (mainCam == null)
            mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ShootRay();
    }

    void ShootRay()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, enemyLayer))
        {
            Debug.Log("Enemy hit instantly: " + hit.collider.name);


            
            Destroy(hit.collider.gameObject);

        
        }
    }
}
