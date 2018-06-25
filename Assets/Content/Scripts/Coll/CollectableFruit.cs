using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableFruit : Collectable {

    public int n=0;
    public bool hidden = false;
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
        if (!hidden)
        {
            Source.Play();
            LevelController.current.addFruits(n);
            this.CollectedHide();
           // hidden = true;
        }
    }
}
