using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBombGood : Collectable {

    public AudioClip  Sound = null;
    public AudioSource  Source = null;
	// Use this for initialization
	void Start () {

        Source = gameObject.AddComponent<AudioSource>();
         Source.clip =  Sound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnRabbitHit(HeroRabbitGood rab){
          Source.Play();
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
