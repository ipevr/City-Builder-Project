using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [SerializeField] LayerMask mouseInputMask;
    [SerializeField] GameObject buildingPrefab = null;
    [SerializeField] int cellSize = 3;

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
                Debug.Log(GetGridPosition(position));
                CreateBuilding(GetGridPosition(position));
            }
        }

    }

    private void CreateBuilding(Vector3 gridPosition)
    {
        Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
    }

    private Vector3 GetGridPosition(Vector3 inputPosition)
    {
        int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
        int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);

        return new Vector3(x * cellSize, 0, z * cellSize);
    }

    #endregion
}
