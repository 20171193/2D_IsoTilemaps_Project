using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameSystemButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject popUp;
    public GameObject gameSystem;
    public  void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new Vector3(3, 0.8f, 1);
    }
    public  void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = new Vector3(5, 1, 1);
        popUp.SetActive(true);
        gameSystem.SetActive(true);
    }
}
