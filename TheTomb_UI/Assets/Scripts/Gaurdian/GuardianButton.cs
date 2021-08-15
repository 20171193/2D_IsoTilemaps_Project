using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuardianButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject guardianTile;    // ����� ��ġ�� ���� Ÿ�ϸ�
    [SerializeField]
    private GameObject guardianPrefab;  // �̹��� �ش� ������
    [SerializeField]
    private GameObject[] onObjects;    // ����� ��ġ �� �ٸ� ��ɵ� true
    [SerializeField]
    private GameObject[] offObjects;    // ����� ��ġ �� �ٸ� ��ɵ� false
    [SerializeField]
    private Image guardianImage;        // �ش� ����� �̹���
    [SerializeField]
    private GameObject guardianInfoImage;   // ��ġ�ϰ����ϴ� ����� �̸�����




    private DeploymentGuardian dpGuardian;

    private BasicCameraFollow camera;


    // Start is called before the first frame update
    void Awake()
    {
        dpGuardian = GameObject.Find("DeploymentGuardian").GetComponent<DeploymentGuardian>();
        camera = GameObject.Find("MainCamera").GetComponent<BasicCameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData ped)
    {
        // ��ư Ŭ�� ȿ��
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
    }
    public void OnPointerUp(PointerEventData ped)
    {
        // ��ư Ŭ�� ȿ��
        transform.localScale = new Vector3(1, 1, 1);

        // ��ġ �� �ٸ� ��ɵ� Ȱ��ȭ/�� Ȱ��ȭ
        for (int i = 0; i < onObjects.Length; i++)
        {
            onObjects[i].SetActive(true);
        }
        for (int i = 0; i < offObjects.Length; i++)
        {
            offObjects[i].SetActive(false);
        }
        // ī�޶� ��ġ �ʱ�ȭ
        camera.isDeploy = true;
        // ��ġ�� ����� ������ ����
        dpGuardian.deployPrefab = guardianPrefab;
        guardianInfoImage.GetComponent<Image>().sprite = guardianImage.sprite;
    }
}
