using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Transform m_transform;
    public CircleCollider2D circleCollider2;
    private float radius;
    public LayerMask layer;
    public int index;
    private Collider2D collider2D;
    private void Start()
    {
        radius = circleCollider2.radius;
        Destroy(circleCollider2);
    }

    // Update is called once per frame
    void Update()
    {
        collider2D= Physics2D.OverlapCircle(m_transform.position, radius, layer);
        if(collider2D != null)
        {
            GameState.currentCheckPoint = index;
            GameState.currentCheckPointPos = transform.position;
        }
    }
}
