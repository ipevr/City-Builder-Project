using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected GameManager gameManager;

    public PlayerState(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }

    public abstract void OnInputPointerDown(Vector3 position);
    public abstract void OnInputPointerDrag(Vector3 position);
    public abstract void OnInputPointerUp(Vector3 position);
    public abstract void OnInputPointerSecondDown(Vector3 position);
    public abstract void OnInputPointerSecondDrag(Vector3 position);
    public abstract void OnInputPointerSecondUp(Vector3 position);

    public virtual void EnterState()
    {

    }

    public abstract void OnCancle();
}
