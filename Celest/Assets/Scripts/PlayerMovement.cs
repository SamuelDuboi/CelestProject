using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Move player in 2D space
    [Header("Stats")]
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float jumpHeight;
    [SerializeField]
    float gravityScale;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    float ChangeHeight;
    [SerializeField]
    float DashSpeed;

    [Header("References")]
    [SerializeField]
    Rigidbody2D MyRigidBody2D;
    [SerializeField]
    Transform MyTransform;

    bool isJumping = true;
    bool CanDash = true;
    bool isDashing = false;
    float moveDirection = 0;
    float heightDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    RaycastHit2D hit;
    
    void Start()
    {
        MyRigidBody2D.gravityScale = gravityScale;
        cameraPos = mainCamera.transform.position;
    }


    void Update()
    {
        if (!isDashing)
        {
            moveDirection = 0;
        }
        // Movement controls
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 : 1;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isJumping == false)
        {
            MyRigidBody2D.velocity = new Vector2(MyRigidBody2D.velocity.x, jumpHeight);
            isGrounded = false;
            isJumping = true;
        }

        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(MyTransform.position.x, cameraPos.y, cameraPos.z);
        }
        // Apply movement velocity
        MyRigidBody2D.velocity = new Vector2((moveDirection) * maxSpeed, MyRigidBody2D.velocity.y);

        //Check IsGrounded
        if (Physics2D.Raycast(new Vector3(MyTransform.position.x, MyTransform.position.y - ChangeHeight, MyTransform.position.z), -Vector3.up, 0.1f, 3))
        {
            if (isJumping)
            {
                isGrounded = true;
                isJumping = false;
                isDashing = false;
                CanDash = true;
            }
        }
        else
        {
            isJumping = true;
        }

        //Test Freeze gravité (start dash)
        if (Input.GetKey(KeyCode.Z))
        {
            MyRigidBody2D.gravityScale = 0;
            MyRigidBody2D.velocity = Vector2.zero;
        }

        //Dash (Working On)
        if (Input.GetKey(KeyCode.D)&& CanDash)
        {
            CanDash = false;
            isDashing = true;
            MyRigidBody2D.gravityScale = 0;
            MyRigidBody2D.velocity = Vector2.zero;

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
            MyRigidBody2D.AddForce(new Vector2((moveDirection) * DashSpeed, DashSpeed * heightDirection), ForceMode2D.Impulse);
            Debug.DrawRay(new Vector3(MyTransform.position.x, MyTransform.position.y, MyTransform.position.z), new Vector2((moveDirection) * DashSpeed, (moveDirection) * heightDirection) * 10, Color.red, 0.1f);

           StartCoroutine( test());

          
        }
        //
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(2f);
        MyRigidBody2D.gravityScale = gravityScale;

    }
    
}