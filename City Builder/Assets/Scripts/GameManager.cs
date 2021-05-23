using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] InputManager inputManager = null;
    [SerializeField] PlacementManager placementManager = null;
    [SerializeField] int cellSize = 3;
    [SerializeField] int width = 100;
    [SerializeField] int length = 100;

    private GridStructure grid;

    private void Start()
    {
        grid = new GridStructure(cellSize, width, length);

        inputManager.OnHit.AddListener(HandleInputHit);
    }

    private void OnDisable()
    {
        inputManager.OnHit.RemoveListener(HandleInputHit);
    }

    private void HandleInputHit(Vector3 position)
    {
        Vector3 gridPosition = grid.GetGridPosition(position);

        if (!grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }
}
