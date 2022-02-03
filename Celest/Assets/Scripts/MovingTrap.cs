using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTrap : MonoBehaviour
{
    public Transform self;
    public GameObject[] Path;
    int ActualTarget = 1;
    public float speed = 1f;
    public bool Loop = true;
    private bool Return = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Path.Length > 0) 
        self.SetPositionAndRotation(Path[0].transform.position, Path[0].transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        if (Path.Length < 2) return;

        Vector3 dir = Path[ActualTarget].transform.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé à sa destination
        if (Vector3.Distance(transform.position, Path[ActualTarget].transform.position) < 0.3f)
        {
            if(Loop)
            {
                ActualTarget = (ActualTarget + 1) % Path.Length;
            }
            else
            {
                if (ActualTarget == Path.Length -1)
                    Return = true;
                else if (ActualTarget == 0) Return = false;

                if(Return)
                {
                    ActualTarget--;
                    Debug.Log(ActualTarget);
                }
                else
                {
                    ActualTarget++;
                    Debug.Log(ActualTarget);
                }

            }
        }

    }
    



}
