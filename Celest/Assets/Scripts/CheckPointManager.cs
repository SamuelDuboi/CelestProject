using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    [Header("Stats")]

    [Header("Références")]
    [SerializeField]
    public GameObject MySpawn;
    private GameObject ActualCheckPoint;

    

    public Vector2 Respawn( bool Spawn)
    {
        if(Spawn || ActualCheckPoint is null)
        {
            ActualCheckPoint = null;
            return MySpawn.transform.position;
        }
        return ActualCheckPoint.transform.position;
        
    }
    public void SetMyCheckPoint(GameObject checkpoint)
    {
        ActualCheckPoint = checkpoint;
    }

}
