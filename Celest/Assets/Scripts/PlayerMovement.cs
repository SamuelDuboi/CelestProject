using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Move player in 2D space
    [Header("Stats")]
    [SerializeField]
    float maxSpeed = 10;
    [SerializeField]
    float jumpHeight = 10;
    [SerializeField]
    float gravityScale = 1.5f;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    float ChangeHeight = 1;
    [SerializeField]
    float DashSpeed = 10;

    [Header("References")]
    [SerializeField]
    Rigidbody2D MyRigidBody2D;
    [SerializeField]
    Transform MyTransform;
    [SerializeField]
    GameManager Gm;
    [SerializeField]
    AnimationHandler animationHandler;
    bool isJumping = true;
    bool CanDash = true;
    bool isDashing = false;
    float moveDirection = 0;
    float heightDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    RaycastHit2D hit;
    bool falling;
    void Start()
    {
        MyRigidBody2D.gravityScale = gravityScale;
        cameraPos = mainCamera.transform.position;
    }


    void Update()
    {
        #region     Movement controls
        if (!isDashing)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetKey(KeyCode.LeftArrow) && moveDirection != -1)
                {
                    if(isGrounded)
                        animationHandler.Run();
                    moveDirection = -1;
                    animationHandler.Flip(true);
                }
                else if(Input.GetKey(KeyCode.RightArrow) && moveDirection != 1)
                {
                    if (isGrounded)
                        animationHandler.Run();
                    moveDirection = 1;
                    animationHandler.Flip(false);
                }
            }
            else if(moveDirection != 0)
            {
                animationHandler.Idle();
                moveDirection = 0;
            }
        }
            #endregion

        //Check IsGrounded
        Debug.DrawRay(new Vector3(MyTransform.position.x, MyTransform.position.y - ChangeHeight, MyTransform.position.z), -Vector3.up,Color.black, 0.1f);
        if (Physics2D.Raycast(new Vector3(MyTransform.position.x, MyTransform.position.y - ChangeHeight, MyTransform.position.z), -Vector3.up, 0.1f, 3))
        {
            if (isJumping)
            {
                isGrounded = true;
                isJumping = false;
                isDashing = false;
                CanDash = true;
                animationHandler.TouchGround();
            }
        }
        else
        {
            isJumping = true;
            if(!falling&&MyRigidBody2D.velocity.y<0 )
            {
                falling = true;
                animationHandler.Fall();
            }
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && isJumping == false)
        {
            animationHandler.Jump();
            MyRigidBody2D.velocity = new Vector2(MyRigidBody2D.velocity.x, jumpHeight);
            isGrounded = false;
            isJumping = true;
            falling = false;
        }

        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(MyTransform.position.x, cameraPos.y, cameraPos.z);
        }
        // Apply movement velocity
        MyRigidBody2D.velocity = new Vector2((moveDirection) * maxSpeed, MyRigidBody2D.velocity.y);

       

        //Dash (Working On)
        if (Input.GetKey(KeyCode.D)&& CanDash)
        {
            CanDash = false;
            isDashing = true;
            MyRigidBody2D.gravityScale = 0;
            MyRigidBody2D.velocity = Vector2.zero;
            animationHandler.Dash();
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
                heightDirection = Input.GetKey(KeyCode.DownArrow) ? -1 : 1;
            }
            else
            {
                heightDirection = 0;
            }
            MyRigidBody2D.AddForce(new Vector2(moveDirection * DashSpeed, DashSpeed * heightDirection), ForceMode2D.Impulse);
            Debug.DrawRay(new Vector3(MyTransform.position.x, MyTransform.position.y, MyTransform.position.z), new Vector2((moveDirection) * DashSpeed, (moveDirection) * heightDirection) * 10, Color.red, 10.1f);

           StartCoroutine( test());

          
        }
        //
    }
    IEnumerator test()
    {
        yield return new WaitForSeconds(0.3f);
        MyRigidBody2D.gravityScale = gravityScale;
        isDashing = false;
        animationHandler.TouchGround();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillPlayer"))
        {
            EventHandler.instance.OnTakeDamage.Invoke();
            //Gm.GameOver();
            //lose one Hp + respawn au dernier point de sauvegarde
            //si plus de Hp, retour au début du niveau
        }
        if (collision.CompareTag("DashRecover"))
        {
            Destroy(collision.gameObject);
            CanDash = true;
        }
        if (collision.CompareTag("Fraise"))
        {
            Destroy(collision.gameObject);
            //NBFraises++
            //Score++
        }

    }

}