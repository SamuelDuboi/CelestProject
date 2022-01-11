using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDisplay : MonoBehaviour
{
    public GameObject pauseBackground;
    // Start is called before the first frame update
    void Start()
    {
        EventHandler.instance.OnPause += Activate;
        EventHandler.instance.OnUnPause += Desactivate;
    }

    private void Activate()
    {
        pauseBackground.SetActive(true);
    }
    private void Desactivate()
    {
        pauseBackground.SetActive(false);
    }
    public void UnPause()
    {
        EventHandler.instance.OnUnPause.Invoke();
    }
}
