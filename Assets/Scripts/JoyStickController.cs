using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickController : MonoBehaviour , IBeginDragHandler, IEndDragHandler ,IDragHandler
{

    [SerializeField] private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField,Range(10,150)] private float leverRange;

    private Vector2 inputDirection;
    private bool isInput;

    [SerializeField] CharacterController characterController;
    private void Awake()
    {
        rectTransform=GetComponent<RectTransform>();
    }
    public void OnBeginDrag(PointerEventData eventData)//드래그 시작
    {
        ControlJoyStickLever(eventData);
        isInput = true;
    }

    public void OnDrag(PointerEventData eventData)//드래그 중
    {
        ControlJoyStickLever(eventData);
    }
    public void OnEndDrag(PointerEventData eventData)//드래그끝
    {
        lever.anchoredPosition = Vector2.zero;
        isInput=false;
        characterController.Move(Vector2.zero);
    }
    private void ControlJoyStickLever(PointerEventData eventData)
    {
        var inputPos = eventData.position - rectTransform.anchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;

        lever.anchoredPosition = inputVector;
        inputDirection = inputVector / leverRange;
    }
    private void InputControlVector() 
    {
        characterController.Move(inputDirection);
    }

    private void Update()
    {
        if (isInput) 
        {
            InputControlVector();
        }
    }
}
