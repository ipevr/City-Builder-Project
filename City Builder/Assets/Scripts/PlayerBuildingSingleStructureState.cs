using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuildingSingleStructureState : PlayerState
{
    PlacementManager placementManager;
    GridStructure grid;

    public PlayerBuildingSingleStructureState(
        GameManager gameManager, 
        PlacementManager placementManager,
        GridStructure grid
        ) : base(gameManager)
    {
        this.placementManager = placementManager;
        this.grid = grid;
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        Vector3 gridPosition = grid.GetGridPosition(position);

        if (!grid.IsCellTaken(gridPosition))
        {
            placementManager.CreateBuilding(gridPosition, grid);
        }
    }

    public override void OnInputPointerDrag(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerSecondDown(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerSecondDrag(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerSecondUp(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerUp(Vector3 position)
    {
        return;
    }

    public override void OnCancle()
    {
        this.gameManager.TransitionToState(this.gameManager.selectionState);
    }
}
