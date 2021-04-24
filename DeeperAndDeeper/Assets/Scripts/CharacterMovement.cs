using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    private Rigidbody2D rb;
    private CircleCollider2D boxCol;
    // public Animator maltAnimator;
    private float jumpTimeCounter;
    public float jumpTime;
    private int numJumps = 0;
    public float jumpForce = 13f;
    public float moveSpeed = 2.5f;
    private bool isJumping;
    // public SpriteRenderer testCharSprite;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        boxCol = transform.GetComponent<CircleCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded())
        {
            // numJumps = 0;
            if (Input.GetKeyDown(KeyCode.UpArrow) && numJumps<1){
                isJumping =true;
                jumpTimeCounter = jumpTime;
                rb.velocity = Vector2.up * jumpForce;
                numJumps+=1;
            }else{
                numJumps = 0;

            }
        }
        if (Input.GetKey(KeyCode.UpArrow) && numJumps<1)
        {
            if (jumpTimeCounter>0){
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -=Time.deltaTime;
                numJumps += 1;

            }else{
                isJumping =false;
                numJumps = 5;

            }
            // 
        }
        
        if (Input.GetKeyUp(KeyCode.UpArrow)){
            // numJumps = 0;
            isJumping =false;
            numJumps = 5;

        }

        // if (Input.GetButtonDown("Attack"))
        // {
        //     Debug.Log("here attack pressed");
        //     // if (testCharSprite.flipX)
        //     // {
        //     //     maltAnimator.SetTrigger("AttackLeftTrigger");
        //     // }else{
        //     //     maltAnimator.SetTrigger("AttackSideTrigger");
        //     // }
            
        // }
    }
    private bool IsGrounded()
    {
        RaycastHit2D rc = Physics2D.BoxCast(boxCol.bounds.center, boxCol.bounds.size, 0f, Vector2.down, 1f, platformsLayerMask);
        // Debug.Log(rc.collider);
        Debug.Log("hit ground");
        return rc.collider != null;
    }

    void FixedUpdate()
    {
        HandleMovement();
       
        // Debug.Log(IsGrounded());

    }

    private void HandleMovement()
    {
        
        // var speed = 10; 
        // rb.velocity = new Vector3(0,1,0) * speed; 
        float movement = Input.GetAxisRaw("Horizontal");
        // transform.position += movement * Time.deltaTime * moveSpeed;
        // rb.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
        //   rb.MovePosition(transform.position + movement * Time.deltaTime * moveSpeed);
        // rb.AddForce( new Vector2(movement, 0)* moveSpeed);
        // rb.velocity = new Vector3(movement,0,0) * moveSpeed;
        rb.velocity = new Vector2(movement*moveSpeed, rb.velocity.y);
        //  rb.AddForce(new Vector2(movement, 0), ForceMode2D.Force);
        // if (movement.x < 0f)
        // {
        //     testCharSprite.flipX = true;
        // }
        // else if (movement.x > 0f)
        // {
        //     testCharSprite.flipX = false;
        // }

        // Debug.Log(movement);


    }
}
