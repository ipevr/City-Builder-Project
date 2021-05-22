using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [System.Serializable]
    public class UnityEvent: UnityEvent<Vector3> { }

    public Action<Vector3> OnPointerDownHandler;

    [SerializeField] LayerMask mouseInputMask;

    public UnityEvent OnHit;

    #region Unity Callbacks

    private void Update()
    {
        GetInput();
    }

    #endregion


    #region Private Methods

    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask))
            {
                Vector3 position = hit.point - transform.position;
                OnHit?.Invoke(position);
            }
        }
    }

    #endregion
}
