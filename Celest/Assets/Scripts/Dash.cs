/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{ 

    [Header("Stats")]
    [SerializeField]
    float DashSpeed;

    [Header("References")]
    [SerializeField]
    Rigidbody2D MyRigidBody2D;
    [SerializeField]
    Transform MyTransform;

    bool CanDash = true;
    float moveDirection = 0;
    float heightDirection = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            CanDash = false;
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
            }
            else
            {
                moveDirection = 0;
            }
            
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                heightDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
            }
            else
            {
                heightDirection = 0;
            }
            MyRigidBody2D.AddForce(new Vector2((moveDirection) * DashSpeed, (moveDirection) * heightDirection));
            Debug.DrawRay(new Vector3(MyTransform.position.x, MyTransform.position.y, MyTransform.position.z), new Vector2((moveDirection) * DashSpeed, (moveDirection) * heightDirection)*10, Color.red, 0.1f);
            //MyRigidBody2D.velocity = new Vector2((moveDirection) * DashSpeed, (moveDirection) * heightDirection);
        }
    }
}
*/



/*** ACTUELLEMENT DANS LE SCRIPT PRINCIPAL ***/