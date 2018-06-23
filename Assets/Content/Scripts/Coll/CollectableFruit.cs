using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFruit : Collectable {

    public int n=0;
    public bool hidden = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	} 
    protected override void OnRabbitHit(HeroRabbitGood rab)
    {
        if (!hidden)
        {
            LevelController.current.addFruits(n);
            this.CollectedHide();
           // hidden = true;
        }
    }
}
