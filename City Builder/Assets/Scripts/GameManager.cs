using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] InputManager inputManager = null;
    [SerializeField] PlacementManager placementManager = null;
    [SerializeField] UIController uiController = null;
    [SerializeField] int cellSize = 3;
    [SerializeField] int width = 100;
    [SerializeField] int length = 100;

    private GridStructure grid;
    private bool buildingModeActive = false;


    #region Unity Callbacks

    private void Start()
    {
        grid = new GridStructure(cellSize, width, length);

        inputManager.OnHit.AddListener(HandleInputHit);
        uiController.OnBuildAreaHandler.AddListener(HandlePlacementMode);
        uiController.OnCancelActionHandler.AddListener(CancleAction);
    }

    private void OnDisable()
    {
        inputManager.OnHit.RemoveListener(HandleInputHit);
        uiController.OnBuildAreaHandler.RemoveListener(HandlePlacementMode);
        uiController.OnCancelActionHandler.RemoveListener(CancleAction);
    }

    #endregion


    #region Private Methods

    private void HandleInputHit(Vector3 position)
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
