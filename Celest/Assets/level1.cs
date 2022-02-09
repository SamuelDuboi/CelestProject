using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour
{
    public GameObject SpawnRoom;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.transform.SetPositionAndRotation(SpawnRoom.transform.position, SpawnRoom.transform.rotation);
        }
    }
}
