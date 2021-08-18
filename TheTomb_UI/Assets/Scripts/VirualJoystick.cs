using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirualJoystick : MonoBehaviour, /*IBeginDragHandler,*/ IDragHandler, /*IEndDragHandler,*/ IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] 
    private RectTransform lever;
    private RectTransform rectTransform;
    [SerializeField, Range(10f, 150f)]
    private float leverRange;
    private Vector2 inputVector;
    public bool isInput;
    public PlayerController characterController;

    public GameObject joypad;

    public Vector3 joyStickFirstPosition;


    private bool isControll = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        // 초기 조이패드 위치 저장
        joyStickFirstPosition = rectTransform.position;
    }
    private void Update()
    {
        if (isInput)
        {
            characterController.InputControlVector(inputVector);
        }
    }
    public void OnPointerDown(PointerEventData ped)
    {
         isInput = true;
         joypad.transform.position = ped.position;
         ControlJoystickLever(ped);
    }
    public void OnDrag(PointerEventData ped)
    {
        ControlJoystickLever(ped);
    }

    public void OnPointerUp(PointerEventData ped)
    {
        joypad.transform.position = joyStickFirstPosition;
        lever.anchoredPosition = Vector2.zero;
        isInput = false;
    }
    public void ControlJoystickLever(PointerEventData eventData)
    {
        var inputDir = eventData.position - rectTransform.anchoredPosition; 
        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange; 
        lever.anchoredPosition = clampedDir; 
        inputVector = clampedDir / leverRange;
    }

}
