using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroRabbitGood : MonoBehaviour
{
    public bool big = false;
    public bool isDead = false;
   public bool isPaused;
   private bool moving;
    
    public float speed = 1;
    bool isGrounded = false;  
    public float bigTime = 0;
    float jumpTime = 0f;
    bool jumpActive = false;
    public float durationOfRedColor = 4f;
    private float tim = 2;
    bool  Red = false;

    public float maxBigTime = 8f;
    public float maxJumpTime = 2f;
     public float jumpSpeed = 2f;
    Rigidbody2D myBody = null;
    SpriteRenderer myBodyRenderer = null;
    Transform heroParent = null;
    Animator myAnimator = null;
    public static HeroRabbitGood lastRabbit = null;
    public static HeroRabbitGood current = null; 

    void Awake()
    {    current = this;
        lastRabbit = this;
    }

    // Use this for initialization
    void Start()
    {
        heroParent = this.transform.parent;
        myBody = this.GetComponent<Rigidbody2D>();
        myBodyRenderer = this.GetComponent<SpriteRenderer>();
          myAnimator = this.GetComponent<Animator>();
        if (LevelController.current)
            LevelController.current.setStartPosition(this.transform.position);
        
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isPaused)
        {
            if (isDead) return;//revive();
            if (big)
            {
                bigTime -= Time.deltaTime;
                if (bigTime <= 0)
                {
                    big = false;
                    this.transform.localScale -= new Vector3(0.5f, 0.5f, 0);
                }

            }
            //     if (!Red) myBodyRenderer.material.color = Color.Lerp(Color.white, Color.white, tim);
            if (Red) myBodyRenderer.material.color = Color.Lerp(Color.red, Color.white, tim);
            if (tim < 1)
            {
                tim += Time.deltaTime / durationOfRedColor;
                Red = true;
            }
            else { Red = false; }




            Vector3 from = this.transform.position + Vector3.up * 0.3f;
            Vector3 to = this.transform.position + Vector3.down * 0.01f;
            int layer_id = 1 << LayerMask.NameToLayer("Ground");

            RaycastHit2D hit = Physics2D.Linecast(from, to, layer_id);
            if (hit)
            {
                isGrounded = true;
                myAnimator.SetBool("jump", false);
                //щоб прилипнути до платформи коли ми на ній
                if (hit.transform != null && hit.transform.GetComponent<MovingPlatform>() != null)
                {
                    Debug.Log("new parent");
                    SetNewParent(this.transform, hit.transform);
                }
                else//відлипнути
                {
                    SetNewParent(this.transform, this.heroParent);
                }
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
             if(isGrounded&&!jumpActive) myBody.velocity = new Vector2(0.0f, 0.0f); 

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

    }

     

    public void death()
    {
        isDead = true;
        myAnimator.SetBool("death", true);
  //          myAnimator.Play("DieAnim");
 //        revive();
    }
    public void revive()
    {
       isDead = false;
        myAnimator.SetBool("death", false);
 
    }
    static void SetNewParent(Transform obj, Transform NewParent)
    {
        if (obj.transform.parent != NewParent)
        {
            Vector3 pos = obj.transform.position;
            obj.transform.parent = NewParent;
            obj.transform.position = pos;
        }
    }
    public void mushEaten(){
  //      Debug.Log("big");
        this.transform.localScale += new Vector3(0.5f, 0.5f, 0);//enlarge 	
        this.big = true;
        bigTime = maxBigTime;
    }
    public bool isRed()
    {
        return Red;
    }
    public void changeColor()
    {
        tim = 0;
        
    }
    public void doJump()
    {
        this.jumpActive = true;
        this.jumpTime += Time.deltaTime;
        if (this.jumpTime < this.maxJumpTime)
        {
            Vector2 velocity = myBody.velocity;
            velocity.y = jumpSpeed * (1.0f - jumpTime / maxJumpTime);
            myBody.velocity = velocity;
        }
    }
  
}
