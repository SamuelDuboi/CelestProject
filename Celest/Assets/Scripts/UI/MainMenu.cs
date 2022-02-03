using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void Play()
    {
        SceneManagement.instance.LoadScene(1);
    }
    public void Exit()
    {
        SceneManagement.instance.Quit();
    }
}
