using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleFloor : MonoBehaviour
{
    public Transform self;
    public bool IsOn = false;
    public float TimeBeforeFall = 1f;
    public float RespawnDelay = 2f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsOn = true;
            StartCoroutine(Wait());
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IsOn = false;
            StopCoroutine(Wait());
        }
    }
    void Fall()
    {
        self.Translate(0,10000,0);
        StartCoroutine(WaitBeforeRespawn());
    }
    IEnumerator Wait()
    {
        Debug.Log("je lance le chrono");
        yield return new WaitForSeconds(TimeBeforeFall);
        Debug.Log("tu est resté une seconde");
        if(IsOn) Fall();  
    }
    public IEnumerator WaitBeforeRespawn()
    {
        Debug.Log("je re");
        yield return new WaitForSeconds(RespawnDelay);
        self.Translate(0,-10000,0);
    }

}
