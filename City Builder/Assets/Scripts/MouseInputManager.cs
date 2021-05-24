using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
            {
                Vector3 position = hit.point - transform.position;
                OnPointerDownHandler?.Invoke(position);
            }
        }
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
