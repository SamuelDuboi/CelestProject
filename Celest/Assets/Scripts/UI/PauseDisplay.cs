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
        Time.timeScale = 1;
        EventHandler.instance.OnUnPause.Invoke();
    }
    public void Reaload()
    {
        Time.timeScale = 1;
        GameState.score = 0;
        GameState.currentLife = 3;
        SceneManagement.instance.LoadScene(2);
    }
    public void Menu()
    {
        Time.timeScale = 1;
        GameState.currentLife = 3;
        GameState.score = 0;
        SceneManagement.instance.LoadScene(0);
        EventHandler.instance.OnPause -= Activate;
        EventHandler.instance.OnUnPause -= Desactivate;
    }
}
