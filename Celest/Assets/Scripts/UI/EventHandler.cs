using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventHandler : MonoBehaviour
{
    public UnityAction OnPause;
    public UnityAction OnUnPause;
    public UnityAction<int> OnScoreUp;

    public static EventHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        else { Destroy(gameObject); }
    }

}
