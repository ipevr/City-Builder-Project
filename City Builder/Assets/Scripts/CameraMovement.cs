using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.05f;

    private int cameraXMin, cameraXMax, cameraZMin, cameraZMax;
    private Vector3 newPosition, previousPosition;


    #region Public Methods

    public void SetCameraBounds(int cameraXMin, int cameraXMax, int cameraZMin, int cameraZMax)
    {
        this.cameraXMin = cameraXMin;
        this.cameraXMax = cameraXMax;
        this.cameraZMin = cameraZMin;
        this.cameraZMax = cameraZMax;
    }

    public void StartCameraMovement(Vector3 pointerPosition)
    {
        previousPosition = new Vector3(pointerPosition.x, 0, pointerPosition.y);
    }

    public void MoveCamera(Vector3 pointerPosition)
    {
        newPosition = new Vector3(pointerPosition.x, 0, pointerPosition.y);

        transform.Translate((previousPosition - newPosition) * movementSpeed);
        previousPosition = newPosition;
        LimitPositionToCameraBounds();
    }

    #endregion


    #region Private Methods

    private void LimitPositionToCameraBounds()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, cameraXMin, cameraXMax),
            0,
            Mathf.Clamp(transform.position.z, cameraZMin, cameraZMax));
    }

    #endregion

}
