using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPics : MonoBehaviour
{
    public float gravityScale;
    public float timeBeforeFall;
    public float timeBeforeRespawn;
    public GameObject TheFallingPic;
    bool CanFall = true;
    Vector2 v2;

    // Update is called once per frame
    void Start()
    {
        v2 = TheFallingPic.transform.position;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(CanFall) StartCoroutine(test());
        }
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(timeBeforeFall);
        CanFall = false;
        TheFallingPic.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        yield return new WaitForSeconds(timeBeforeRespawn);
        TheFallingPic.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        TheFallingPic.GetComponent<Rigidbody2D>().gravityScale = 0;
        TheFallingPic.transform.position = v2;
        CanFall = true;

    }

    
}

    
