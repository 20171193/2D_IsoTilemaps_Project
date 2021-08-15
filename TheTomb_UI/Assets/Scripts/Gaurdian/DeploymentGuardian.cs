using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DeploymentGuardian : MonoBehaviour
{
    private Camera mainCamera;
    private BasicCameraFollow camera;

    private Ray ray;
    private RaycastHit hit;

    private Tilemap tilemap;
    private SpriteRenderer sprenderer;

    int layerMask;

    [SerializeField]
    private GuardianSpawner guardianSpawner;
    [SerializeField]
    private GameObject deployTile;

    [SerializeField]
    private GameObject[] onObjects;    // ����� ��ġ �� �ٸ� ��ɵ� true

    [SerializeField]
    private GameObject[] offObjects;   // ����� ��ġ �� �ٸ� ��ɵ� false


    [HideInInspector]
    public GameObject deployPrefab;  // ��ġ�� ������� �������� �޾ƿ� ����

    private void Awake()
    {
        mainCamera = Camera.main;
        camera = GameObject.Find("MainCamera").GetComponent<BasicCameraFollow>();
    }


    // Start is called before the first frame update
    void Start()
    {
        deployPrefab = null;
        layerMask = (-1) - (1 << LayerMask.NameToLayer("InDeployable"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity,layerMask))
            {
                if (hit.transform.CompareTag("GuardianTile"))
                {
                    guardianSpawner.SpawnGuardian(hit.transform, deployPrefab);

                    //tilemap = hit.transform.GetComponent<Tilemap>();

                    //tilemap.RefreshAllTiles();
                    //Vector3Int v3Int = new Vector3Int(
                    //    tilemap.WorldToCell(hit.transform.position).x,
                    //    tilemap.WorldToCell(hit.transform.position).y,
                    //    0);
                    //tilemap.SetTileFlags(v3Int, TileFlags.None);
                    //tilemap.SetColor(v3Int, Color.red);
                    sprenderer = hit.transform.GetComponent<SpriteRenderer>();
                    sprenderer.color = new Color(1, 0, 0, 1);
                    hit.transform.gameObject.layer = 11;
                    deployTile.SetActive(true);

                    camera.isDeploy = false;
                    // ��ġ �� �ٸ� ��ɵ� Ȱ��ȭ/�� Ȱ��ȭ
                    for (int i = 0; i < onObjects.Length; i++)
                    {
                        onObjects[i].SetActive(true);
                    }
                    for (int i = 0; i < offObjects.Length; i++)
                    {
                        offObjects[i].SetActive(false);
                    }

                }
            }
        }
    }
}
