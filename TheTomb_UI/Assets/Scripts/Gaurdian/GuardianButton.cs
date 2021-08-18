using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GuardianButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject guardianPrefab;  // 이미지 해당 프리팹
    [SerializeField]
    private Image guardianImage;        // 해당 가디언 이미지
    [SerializeField]
    private GameObject guardianInfoImage;   // 배치하고자하는 가디언 미리보기
    [SerializeField]
    private Color bgColor;

    [SerializeField]
    private GameObject ClickEvent;      // 가디언 클릭 시 테두리


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
        // 버튼 클릭 효과
        transform.localScale = new Vector3(1.2f, 1.2f, 1);
        
        if(dpGuardian.curObject != null)
        {
            Transform clickEvent = dpGuardian.curObject.transform.Find("ClickEvent");
            clickEvent.gameObject.SetActive(false);
        }
    }
    public void OnPointerUp(PointerEventData ped)
    {
        // 버튼 클릭 효과
        transform.localScale = new Vector3(1, 1, 1);

        //for (int i = 0; i < offObjects.Length; i++)
        //{
        //    offObjects[i].SetActive(false);
        //}

        if (guardianImage != null && guardianPrefab != null)
        {
            // 클릭 한 가디언 배경색상 변경
            //gameObject.GetComponent<RawImage>().color = new Color(0, 0, 3,1);
           
            // 배치할 가디언 프리팹 저장
            dpGuardian.deployPrefab = guardianPrefab;

            // 배치 중 다른 기능들 활성화/비 활성화
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
