using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public List<GameObject> lifeImages;
    void OnDeath()
    {
        for (int i = lifeImages.Count - 1; i > GameState.currentLife; i--)
        {
            lifeImages[i].SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        EventHandler.instance.OnDeath += OnDeath;
        EventHandler.instance.OnTakeDamage += OnTakeDamage;
    }
    void OnTakeDamage()
    {
        GameState.currentLife--;
        if (GameState.currentLife==0)
        {
            EventHandler.instance.OnDeath();
            return;
        }
        lifeImages[GameState.currentLife-1].SetActive(false);
        
    }
}
