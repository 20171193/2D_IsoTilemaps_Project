﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class VirualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] 
    private RectTransform lever;
    private RectTransform rectTransform;
    [SerializeField, Range(10f, 150f)]
    private float leverRange;
    private Vector2 inputVector;
    private bool isInput;
    public PlayerController characterController;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (isInput)
        {
            characterController.InputControlVector(inputVector);
        }
    }
    public void OnBeginDrag(PointerEventData eventData) 
    {
        ControlJoystickLever(eventData);
        isInput = true;
    } 
    // 오브젝트를 클릭해서 드래그 하는 도중에 들어오는 이벤트 
    // 하지만 클릭을 유지한 상태로 마우스를 멈추면 이벤트가 들어오지 않음
    public void OnDrag(PointerEventData eventData) 
    {
        ControlJoystickLever(eventData);
        
    } 
    public void OnEndDrag(PointerEventData eventData) 
    {
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
