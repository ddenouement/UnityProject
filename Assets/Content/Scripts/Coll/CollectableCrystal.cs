using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCrystal : Collectable {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public string c;
    bool hidden = false;
    protected override void OnRabbitHit(HeroRabbitGood rab)
    {
        if (!hidden)
        {
            LevelController.current.addCrystal(rab, c);
            this.CollectedHide();
            hidden = true;
        }
    }
}
