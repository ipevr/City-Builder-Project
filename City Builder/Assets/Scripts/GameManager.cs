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

    private PlayerState state;
    public PlayerSelectionState selectionState;
    public PlayerBuildingSingleStructureState buildingSingleStructureState;

    private GridStructure grid;


    #region Unity Callbacks

    private void Awake()
    {
        grid = new GridStructure(cellSize, width, length);

        selectionState = new PlayerSelectionState(this, cameraMovement);
        buildingSingleStructureState = new PlayerBuildingSingleStructureState(this, placementManager, grid);

        state = selectionState;
    }

    private void Start()
    {
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
        state.OnInputPointerUp(position);
    }

    private void HandlePointerDragEvent(Vector3 position)
    {
        state.OnInputPointerDrag(position);
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


    #region Public Methods

    public void TransitionToState(PlayerState newState)
    {
        this.state = newState;
        this.state.EnterState();
    }

    #endregion


    #region Private Methods

    private void HandlePointerDownEvent(Vector3 position)
    {
        state.OnInputPointerDown(position);
    }

    private void HandleStartCameraMovement(Vector3 position)
    {
        state.OnInputPointerSecondDown(position);   
    }

    private void HandleCameraMovement(Vector3 position)
    {
        state.OnInputPointerSecondDrag(position);
    }

    private void HandlePlacementMode()
    {
        TransitionToState(buildingSingleStructureState);
    }

    private void CancleAction()
    {
        state.OnCancle();
    }

    #endregion
}
