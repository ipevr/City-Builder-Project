using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectionState : PlayerState
{
    CameraMovement cameraMovement;

    public PlayerSelectionState(GameManager gameManager, CameraMovement cameraMovement) : base(gameManager)
    {
        this.cameraMovement = cameraMovement;
    }

    public override void OnInputPointerDown(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerDrag(Vector3 position)
    {
        return;
    }

    public override void OnInputPointerSecondDown(Vector3 position)
    {
        cameraMovement.StartCameraMovement(position);
    }

    public override void OnInputPointerSecondDrag(Vector3 position)
    {
        cameraMovement.MoveCamera(position);
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
        return;
    }
}
