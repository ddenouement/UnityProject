using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenOrc : MonoBehaviour {
    enum Mode
    {
        GoToA,
        GoToB,
        Attack
    }
        public static float speed = 1;
        public AudioClip dieSound = null;
         protected AudioSource dieSource = null;
    
        public Vector3 pointA;
      public Vector3 pointB;
    public Vector3 diff = new Vector3(3, 0, 0);
    Mode mode = Mode.GoToA;

    public Rigidbody2D orcBody = null;
      public SpriteRenderer orcBodyRenderer = null;
      public Animator AnimController = null;
  public  bool dead = false;
	// Use this for initialization
    void Start()
    {
        orcBody = this.GetComponent<Rigidbody2D>();
        orcBodyRenderer = this.GetComponent<SpriteRenderer>();
        AnimController = this.GetComponent<Animator>();
        pointA = this.transform.position;
        pointB = pointA + diff; 
        dieSource = gameObject.AddComponent<AudioSource>();
        dieSource.clip = dieSound;
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void FixedUpdate()
    {
        if (dead) return;
        float value = this.getDirection();
        Vector2 velocity = orcBody.velocity;
        velocity.x = speed * value;
        orcBody.velocity = velocity;
        if (value > 0)
            orcBodyRenderer.flipX = true;
        else if (value < 0)
            orcBodyRenderer.flipX = false;

        this.checkAttack();
    }
     public   float getAttackDirection() {
        Vector3 orc_pos = this.transform.position;
        Vector3 rabbit_pos = HeroRabbitGood.current.transform.position;
        if (Mathf.Abs(orc_pos.x - rabbit_pos.x) < 0.1f)
        {
     //       this.AnimController.SetBool("run", false); this.AnimController.SetBool("walk", true);
               return 0;//немає
        }

        if (orc_pos.x < rabbit_pos.x)
        {
     //       Debug.Log("att");
     //       this.AnimController.SetBool("run", true);
            return 1;//->
        }
        else if (orc_pos.x > rabbit_pos.x)
        {
     //       Debug.Log("att");
      //      this.AnimController.SetBool("run", true);
            return -1;//<-
        }
        return 0; }
     public bool patroll()
     {
        float rabbit_x = HeroRabbitGood.current.transform.position.x;
        if (rabbit_x > pointA.x && rabbit_x< pointB.x)
        {
            Debug.Log("attck ");  
            return false;
        } 
             this.AnimController.SetBool("run", true);
        return true;
    }
     public bool atPoint(Vector3 to)
     {
        Vector3 at = this.transform.position;
        at.z = 0;
        to.z = 0;
        at.y = 0;
        to.y = 0;
        return Vector3.Distance(at, to) < 0.2f;
    }
     public float getWalkDirection()
     {
         Vector3 my_pos = this.transform.position;

         if (mode == Mode.GoToA && atPoint(pointA))
             mode = Mode.GoToB;
         else if (mode == Mode.GoToB && atPoint(pointB))
             mode = Mode.GoToA;

         Vector3 to = new Vector3(0, 0, 0);
         if (mode == Mode.GoToA)
             to = pointA;
         else if (mode == Mode.GoToB)
             to = pointB;
         if (to.x < my_pos.x)
             return -1;
         else if (to.x > my_pos.x)
             return 1;
         return 0;
     }
     public float getDirection()
     {
        if (dead) return 0; 
        if (patroll())    {
            return getWalkDirection();
        }
        else       return getAttackDirection();       
         //return 0;
    }

  private   void checkAttack()  {
        Vector3 orc_pos = this.transform.position;
        Vector3 rabbit_pos = HeroRabbitGood.current.transform.position;

        if (Mathf.Abs(orc_pos.x - rabbit_pos.x) < 1.25f){
           // if (!HeroRabbitGood.current.isDead) {
                this.AnimController.SetTrigger("attack");         
            } //}
    }
    public void OnTriggerEnter2D(Collider2D collider) {
        if (dead) return;  
        HeroRabbitGood rabbit = collider.GetComponent<HeroRabbitGood>();
        if (rabbit != null)
        {
          //  Debug.Log("here"); 
            OnCollideWithRabbit(rabbit);
        }
    }
    IEnumerator dieAnim()
    {
      //  Debug.Log("destroyed");
        orcBody.velocity = Vector3.zero;
        
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

    public void OnCollideWithRabbit(HeroRabbitGood rabbit)
    {
        float rabbit_y = rabbit.transform.position.y;
        float orc_y = this.transform.position.y;
        if (orc_y < rabbit_y && Mathf.Abs(rabbit_y - orc_y) > 0.5f)
        {
            rabbit.doJump();
            die();
            if (SoundController.soundControls.sound)
            {
              //  Debug.Log(SoundController.soundControls.sound);
                dieSource.Play();
                
            } 
        }

        else LevelController.current.onRabbitDeath(rabbit);
    }
    public void die()
    {
         this.AnimController.SetBool("die", true); 
        this.AnimController.SetBool("run", false);

        this.dead = true; 
         this.GetComponent<BoxCollider2D>().enabled = false;       
      //   this.GetComponent<CapsuleCollider2D>().enabled = false;
        this.orcBody.isKinematic = true;
        StartCoroutine(dieAnim());
    }
}
