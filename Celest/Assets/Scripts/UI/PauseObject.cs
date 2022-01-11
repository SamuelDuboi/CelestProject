using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseObject : MonoBehaviour
{
    protected bool isPaused;

     protected  virtual void Start()
    {
        EventHandler.instance.OnPause += OnPause;
        EventHandler.instance.OnUnPause += OnPause;
    }

    protected virtual void OnPause()
    {
        isPaused = true;
    }
    protected virtual void OnUnPause()
    {
        isPaused = false;
    }
}
