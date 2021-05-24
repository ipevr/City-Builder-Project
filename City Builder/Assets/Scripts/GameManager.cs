using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] InputManager inputManager = null;
    [SerializeField] PlacementManager placementManager = null;
    [SerializeField] UIController uiController = null;
    [SerializeField] CameraMovement cameraMovement = null;
    [SerializeField] int cellSize = 3;
    [SerializeField] int width = 100;
    [SerializeField] int length = 100;

    private GridStructure grid;
    private bool buildingModeActive = false;


    #region Unity Callbacks

    private void Start()
    {
        grid = new GridStructure(cellSize, width, length);
        cameraMovement.SetCameraBounds(0, width * cellSize, 0, length * cellSize);

        inputManager.OnPointerDownHandler.AddListener(HandlePointerDownEvent);
        inputManager.OnPointerDragHandler.AddListener(HandlePointerDragEvent);
        inputManager.OnPointerUpHandler.AddListener(HandlePointerUpEvent);
        inputManager.OnPointerSecondDownHandler.AddListener(HandleStartCameraMovement);
        inputManager.OnPointerSecondDragHandler.AddListener(HandleCameraMovement);
        uiController.OnBuildAreaHandler.AddListener(HandlePlacementMode);
        uiController.OnCancelActionHandler.AddListener(CancleAction);
    }

    private void HandlePointerUpEvent(Vector3 position)
    {
        Debug.Log("Pointer up at " + position);
    }

    private void HandlePointerDragEvent(Vector3 position)
    {
        Debug.Log("Pointer drag at " + position);
    }

    private void OnDisable()
    {
        inputManager.OnPointerDownHandler.RemoveListener(HandlePointerDownEvent);
        inputManager.OnPointerSecondDownHandler.RemoveListener(HandleStartCameraMovement);
        inputManager.OnPointerSecondDragHandler.RemoveListener(HandleCameraMovement);
        uiController.OnBuildAreaHandler.RemoveListener(HandlePlacementMode);
        uiController.OnCancelActionHandler.RemoveListener(CancleAction);
    }

    #endregion


    #region Private Methods

    private void HandlePointerDownEvent(Vector3 position)
    {
        if (!buildingModeActive)
        {
            return;
        }

        Vector3 gridPosition = grid.GetGridPosition(position);

        if (!grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }

    private void HandleStartCameraMovement(Vector3 position)
    {
        cameraMovement.StartCameraMovement(position);
    }

    private void HandleCameraMovement(Vector3 position)
    {
        if (!buildingModeActive)
        {
            cameraMovement.MoveCamera(position);
        }
    }

    private void HandlePlacementMode()
    {
        buildingModeActive = true;
    }

    private void CancleAction()
    {
        buildingModeActive = false;
    }

    #endregion
}
