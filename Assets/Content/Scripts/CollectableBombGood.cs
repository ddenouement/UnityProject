using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBombGood : Collectable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnRabbitHit(HeroRabbitGood rab){

 	       if (rab.big) {
		//	rab.big = false;
            rab.bigTime = 0;
            Debug.Log("bomb => small");
            rab.changeColor();
            this.CollectedHide();
		} else {
            if (!rab.isRed()) { LevelController.current.onRabbitDeath(rab); this.CollectedHide(); }

		}

		
	}
}
