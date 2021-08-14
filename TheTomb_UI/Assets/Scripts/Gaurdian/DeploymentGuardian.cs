using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploymentGuardian : MonoBehaviour
{
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField]
    private GuardianSpawner guardianSpawner;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.CompareTag("GuardianTile"))
                {
                    guardianSpawner.SpawnGuardian(hit.transform);
                }
            }
        }
    }
}
