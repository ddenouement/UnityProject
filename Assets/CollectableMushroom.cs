using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableMushroom : Collectable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnRabbitHit(HeroRabbitGood rab)
    {
        //Debug.Log("hh");
        this.CollectedHide();
       if(!rab.big) rab.mushEaten();
    }
}
