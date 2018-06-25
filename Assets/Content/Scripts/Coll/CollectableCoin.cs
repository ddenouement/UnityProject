using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCoin : Collectable  {

    public AudioClip Sound = null;
    public AudioSource Source = null;
    // Use this for initialization
    void Start()
    {

        Source = gameObject.AddComponent<AudioSource>();
        Source.clip = Sound;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    protected override void OnRabbitHit(HeroRabbitGood rab)
    {
        LevelController.current.addCoins(1);
        Source.Play();
        this.CollectedHide();
        
    }
}
