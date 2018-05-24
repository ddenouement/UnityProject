using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbitGood : MonoBehaviour
{

    public float speed = 1;
    bool isGrounded = false;  
    public float bigTime = 0;
    float jumpTime = 0f;
    bool jumpActive = false;

    public float maxBigTime = 8f;
    public float maxJumpTime = 2f;
     public float jumpSpeed = 2f;
    Rigidbody2D myBody = null;
    SpriteRenderer myBodyRenderer = null;
  
    Animator myAnimator = null;
     
    public static HeroRabbitGood current = null; 

    void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
        myBodyRenderer = this.GetComponent<SpriteRenderer>();
          myAnimator = this.GetComponent<Animator>();
        if (LevelController.current)
            LevelController.current.setStartPosition(this.transform.position);
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        Vector3 from = this.transform.position + Vector3.up * 0.3f;
        Vector3 to = this.transform.position + Vector3.down * 0.01f;
        int layer_id = 1 << LayerMask.NameToLayer("Ground");  

        RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
        if (hit)
        {
            isGrounded = true;
            myAnimator.SetBool("jump", false); 
            
        }
        else
        {
            isGrounded = false;
           
            myAnimator.SetBool("jump", true);
             
        }
        Debug.DrawLine(from, to, Color.red);

        if (Input.GetButton("Jump") && isGrounded)
        { 
            this.jumpActive = true;
        }

        if (this.jumpActive)
        {
            if (Input.GetButton("Jump"))
            {
                this.jumpTime += Time.deltaTime;

                if (this.jumpTime < this.maxJumpTime)
                {
                    Vector2 velocity = myBody.velocity;
                    velocity.y = jumpSpeed * (1.0f - jumpTime / maxJumpTime);
                    myBody.velocity = velocity;
                }
            }
            else
            {
                this.jumpActive = false;
                this.jumpTime = 0; 
            }
        }

        //[-1, 1]
        float value = Input.GetAxis("Horizontal");

        if (Mathf.Abs(value) > 0)
        {
            myAnimator.SetBool("run", true);
            
            Vector2 vel = myBody.velocity;
            vel.x = value * speed;
            myBody.velocity = vel;
        }
        else
        {
            myAnimator.SetBool("run", false); 

        }
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (value < 0)
        {
            sr.flipX = true;
        }
        else if (value > 0)
        {
            sr.flipX = false;
        }
    }

     

    public void death()
    {
         
        myAnimator.SetBool("death", true);
        
    }

    

}
