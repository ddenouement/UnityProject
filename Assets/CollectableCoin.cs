﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : Collectable  {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnRabbitHit(HeroRabbitGood rab)
    {
        this.CollectedHide();
    }
}
