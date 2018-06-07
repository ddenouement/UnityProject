using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedOrc : MonoBehaviour {
     
    public GameObject carrprefab;
    float lastCarrot = 0;

    public float minDistanceToAttack = 5;
    public float minIntervalToAttack = 1f;
    enum Mode
    {
        GoToA,
        GoToB,
        Attack
    }

    public static float speed = 1;

    public Vector3 pointA;
    public Vector3 pointB;
    public Vector3 diff = new Vector3(5, 0, 0);
    Mode mode = Mode.GoToA;
 
    protected Rigidbody2D orcBody = null;
    protected SpriteRenderer orcBodyRenderer = null;
    protected Animator AnimController = null; 
    bool dead = false;
    void Start()
    {
        orcBody = this.GetComponent<Rigidbody2D>();
        orcBodyRenderer = this.GetComponent<SpriteRenderer>();
        AnimController = this.GetComponent<Animator>();

        pointA = this.transform.position;
        pointB = pointA + diff;
    }

    // Update is called once per frame
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

    public bool atPoint(Vector3 to)
    {
        Vector3 at = this.transform.position;
        at.z = 0;
        to.z = 0;
        at.y = 0;
        to.y = 0;
        return Vector3.Distance(at, to) < 0.2f;
    }
    float getDirection()
    {
        if (dead)
            return 0;

        if (patroll())
        {
            if (AnimController.GetBool("run") == true) speed -= 1f;
          
            AnimController.SetBool("run", false);
             return getWDir();
        }
        else
        {         
           if( AnimController.GetBool("run") == false)  speed += 1f;
            AnimController.SetBool("run", true);
          
            return getAttackDirection();
        }
    }
    public float getWDir()
    {
        Vector3 orc_pos = this.transform.position;

        if (mode == Mode.GoToA && atPoint(pointA))
            mode = Mode.GoToB;
        else if (mode == Mode.GoToB && atPoint(pointB))
            mode = Mode.GoToA;

        Vector3 target = new Vector3(0, 0, 0);
        if (mode == Mode.GoToA)
            target = pointA;
        else if (mode == Mode.GoToB)
            target = pointB;

        if (target.x < orc_pos.x)
        {
          //  Debug.Log("-1");
            return -1;
        }
        else if (target.x > orc_pos.x)
        {
          //  Debug.Log("1");
            return 1;
        }
        return 0;
    }
    public bool deadOrc()
    {
        return dead;
    } 
    void death()
    { 
        this.AnimController.SetBool("die", true);
        this.dead = true;
         StartCoroutine(dieAnim());
    }
    IEnumerator dieAnim()
    {
        orcBody.velocity = Vector3.zero;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.orcBody.isKinematic = true;        
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    } 
    void OnCollideWithRabbit(HeroRabbitGood rabbit)
    {
        float rabbit_y = rabbit.transform.position.y;
        float orc_y = this.transform.position.y;

        if (orc_y < rabbit_y && Mathf.Abs(rabbit_y - orc_y) > 0.5f)
        {
            //do jump
            rabbit.doJump();
            this.death();
        }
        else
            LevelController.current.onRabbitDeath(rabbit);
    } 
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (dead)
            return;

        HeroRabbitGood rabbit = collider.GetComponent<HeroRabbitGood>();

        if (rabbit != null)
            OnCollideWithRabbit(rabbit);
    }

    void checkAttack()
    {
        if (this.dead)    return ;
        if (HeroRabbitGood.current.isDead) return ;
        Vector3 rabbit_pos = HeroRabbitGood.current.transform.position;
        Vector3 orc_pos = this.transform.position;
         if (Mathf.Abs(orc_pos.x - rabbit_pos.x) < this.minDistanceToAttack) {
            if (Time.time - lastCarrot > this.minIntervalToAttack)  {
                lastCarrot = Time.time;
                StartCoroutine(attackPerform());
            }
        }
        return ;
    }

    
     protected   bool patroll()
    {
        float orc_x = this.transform.position.x;
        float rabbit_x = HeroRabbitGood.current.transform.position.x;

        if (Mathf.Abs(orc_x - rabbit_x) < 3f)
            return false;
        return true;
    }
     IEnumerator attackPerform()
    {
        yield return new WaitForSeconds(0.1f);

        Vector3 rabbit_pos = HeroRabbitGood.current.transform.position;
        Vector3 orc_pos = this.transform.position;
        this.AnimController.SetTrigger("attack");
        GameObject ob = GameObject.Instantiate(this.carrprefab);
        ob.transform.position = this.transform.position + Vector3.up * 0.5f;
        Carrot goodcarrot = ob.GetComponent<Carrot>();
        if (orc_pos.x < rabbit_pos.x)
            goodcarrot.launch(1);
        else if (orc_pos.x > rabbit_pos.x)
            goodcarrot.launch(-1);
    } 
    protected   float getAttackDirection()
    {
        Vector3 orc_pos = this.transform.position;
        Vector3 rabbit_pos = HeroRabbitGood.current.transform.position;

        if (Mathf.Abs(orc_pos.x - rabbit_pos.x) < 0.5f)
            return 0;

        if (orc_pos.x < rabbit_pos.x)
            return 1;
        else if (orc_pos.x > rabbit_pos.x)
            return -1;
        return 0;
    }
}
