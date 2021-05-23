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

    private UnityVector3Event onHitEvent = new UnityVector3Event();
    public virtual UnityVector3Event OnHit
    {
        get { return onHitEvent; }
    }

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
