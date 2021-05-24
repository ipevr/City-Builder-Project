using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[System.Serializable]
public class UnityVector3Event : UnityEvent<Vector3> { }


public abstract class InputManager : MonoBehaviour
{

    public UnityVector3Event OnPointerDownHandler;
    public UnityVector3Event OnPointerSecondDownHandler;
    public UnityVector3Event OnPointerSecondDragHandler;
    public UnityVector3Event OnPointerSecondUpHandler;


    #region Unity Callbacks

    protected virtual void Update()
    {
        GetInput();
    }

    #endregion


    #region Private Methods

    protected abstract void GetInput();

    #endregion
}
