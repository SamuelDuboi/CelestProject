using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventHandler : MonoBehaviour
{
    public UnityAction OnPause;
    public UnityAction OnUnPause;
    public UnityAction<int> OnScoreUp;
    public UnityAction OnDeath;
    public UnityAction OnTakeDamage;
    public UnityAction OnSave;

    public static EventHandler instance;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

            instance = this;
            return;
        }
        else { Destroy(gameObject); }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!GameState.isPaused)
            {
                OnPause.Invoke();
            }
            else
            {
                OnUnPause.Invoke();
            }
        }
    }
}
