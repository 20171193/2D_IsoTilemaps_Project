using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuardianButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject guardianPrefab;  // �̹��� �ش� ������
    [SerializeField]
    private Image guardianImage;        // �ش� ����� �̹���
    [SerializeField]
    private GameObject guardianInfoImage;   // ��ġ�ϰ����ϴ� ����� �̸�����
    [SerializeField]
    private Color bgColor;

    [SerializeField]
    private GameObject ClickEvent;      // ����� Ŭ�� �� �׵θ�


[SerializeField]
    private GameObject[] onObjects;

    private DeploymentGuardian dpGuardian;



    // Start is called before the first frame update
    void Awake()
    {
        dpGuardian = GameObject.Find("DeploymentGuardian").GetComponent<DeploymentGuardian>();
        guardianImage = GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPointerDown(PointerEventData ped)
    {
        // ��ư Ŭ�� ȿ��
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
        
        if(dpGuardian.curObject != null)
        {
            Transform clickEvent = dpGuardian.curObject.transform.Find("ClickEvent");
            clickEvent.gameObject.SetActive(false);
        }
    }
    public void OnPointerUp(PointerEventData ped)
    {
        // ��ư Ŭ�� ȿ��
        transform.localScale = new Vector3(1, 1, 1);

        //for (int i = 0; i < offObjects.Length; i++)
        //{
        //    offObjects[i].SetActive(false);
        //}

        if (guardianImage != null && guardianPrefab != null)
        {
            // Ŭ�� �� ����� ������ ����
            //gameObject.GetComponent<RawImage>().color = new Color(0, 0, 3,1);
           
            // ��ġ�� ����� ������ ����
            dpGuardian.deployPrefab = guardianPrefab;

            // ��ġ �� �ٸ� ��ɵ� Ȱ��ȭ/�� Ȱ��ȭ
            for (int i = 0; i < onObjects.Length; i++)
            {
                onObjects[i].SetActive(true);
            }
            ClickEvent.SetActive(true);
            dpGuardian.curObject = this.gameObject;
            guardianInfoImage.GetComponent<Image>().sprite = guardianImage.sprite;
        }
    }
}
