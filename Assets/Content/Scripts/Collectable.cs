using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    bool hideAnimation = false;
    protected virtual void OnRabbitHit(HeroRabbitGood rab)
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
         if (!this.hideAnimation)
        {
            HeroRabbitGood ra = col.GetComponent<HeroRabbitGood>();
            if (ra != null)
            {//щосб знайшли 
                this.OnRabbitHit(ra);

            }
        }

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void CollectedHide()
    {
        Destroy(this.gameObject);
    }
}
