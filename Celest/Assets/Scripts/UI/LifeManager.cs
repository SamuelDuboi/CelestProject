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
    }
        
}
