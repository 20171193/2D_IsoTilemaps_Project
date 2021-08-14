using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.IO;
public class DeploymentButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool isBtnDown = false;
    private bool isValidPosition = false;
    public RawImage PreveiwImage;
    public GameObject DepolyGameObject;

    
    // Update is called once per frame
    void Update()
    {
        if (isBtnDown)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

            PreveiwImage.rectTransform.position = mousePos;
            byte[] bytetexture = System.IO.File.ReadAllBytes(Application.dataPath + "/Characters/Texture/" + DepolyGameObject.name + ".PNG");
            if(bytetexture.Length > 0)
            {
                Texture2D texture = new Texture2D(0, 0);
                texture.LoadImage(bytetexture);
                PreveiwImage.texture = texture;
                PreveiwImage.SetNativeSize();
            }
            
            Vector3 MousePosition = Input.mousePosition;
            MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(MousePosition,Camera.main.transform.forward, 15f);
            PreveiwImage.color = Color.red;
            bool isGrounded = false;
            bool isCollided = false;
            foreach (RaycastHit2D hit in hits)
            {
                if (hit)
                {
                    if (hit.collider.gameObject.tag == "TilemapCollider") {
                        isCollided = true;
                    }
                    else if(hit.collider.gameObject.tag == "Ground"){
                        isGrounded = true;
                    }
                    
                }
            }

            if(!isCollided && isGrounded)
            {
                PreveiwImage.color = Color.white;
                isValidPosition = true;
            }
            else
            {
                PreveiwImage.color = Color.red;
                isValidPosition = false;
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isBtnDown = true;
        PreveiwImage.gameObject.SetActive(true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isBtnDown = false;
        PreveiwImage.gameObject.SetActive(false);
        if(isValidPosition)
            DepolyObject();
    }
    public void DepolyObject()
    {
        
        Vector3 SpawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        SpawnPos.z = 0;
        
        Instantiate(DepolyGameObject, SpawnPos,Quaternion.identity);
        //DepolyGameObject.transform.position = SpawnPos;

    }
}
