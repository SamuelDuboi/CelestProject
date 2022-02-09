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
        if(pauseBackground ==null)
        {
            EventHandler.instance.OnPause -= Activate;
            EventHandler.instance.OnUnPause -= Desactivate;
            return;
        }
        pauseBackground.SetActive(true);
        GameState.isPaused = true;
    }
    private void Desactivate()
    {
        GameState.isPaused = false;
        pauseBackground.SetActive(false);
    }
    public void UnPause()
    {
        EventHandler.instance.OnUnPause.Invoke();
    }
    public void Menu()
    {
        SceneManagement.instance.LoadScene(0);
        EventHandler.instance.OnPause -= Activate;
        EventHandler.instance.OnUnPause -= Desactivate;
    }
}
