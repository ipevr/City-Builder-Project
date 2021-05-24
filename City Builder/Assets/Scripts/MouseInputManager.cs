using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseInputManager : InputManager
{
    [SerializeField] LayerMask mouseInputMask;

    protected override void GetInput()
    {
        GetPointerClickPosition();

        GetPanningPointer();
    }

    private void GetPointerClickPosition()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            CallEventOnPointer((position) => OnPointerDownHandler?.Invoke(position));
        }

        if (Input.GetMouseButton(0))
        {
            CallEventOnPointer((position) => OnPointerDragHandler?.Invoke(position));
        }

        if (Input.GetMouseButtonUp(0))
        {
            CallEventOnPointer((position) => OnPointerUpHandler?.Invoke(position));
        }
    }

    private void CallEventOnPointer(UnityAction<Vector3> action)
    {
        Vector3? position = GetMouseHitPosition();
        if (position.HasValue)
        {
            action.Invoke(position.Value);
        }
    }

    private Vector3? GetMouseHitPosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Vector3? position = null;
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
        {
            position = hit.point - transform.position;
        }

        return position;
    }

    private void GetPanningPointer()
    {
        var position = Input.mousePosition;

        if (Input.GetMouseButtonDown(1))
        {
            OnPointerSecondDownHandler?.Invoke(position);
        }

        if (Input.GetMouseButton(1))
        {
            OnPointerSecondDragHandler?.Invoke(position);
        }

        if (Input.GetMouseButtonUp(1))
        {
            OnPointerSecondUpHandler?.Invoke(position);
        }
    }
}
