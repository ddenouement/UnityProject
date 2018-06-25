using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCrystal : Collectable {

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
    public string c;
    bool hidden = false;
    protected override void OnRabbitHit(HeroRabbitGood rab)
    {
        if (!hidden)
        {
            Source.Play();
            LevelController.current.addCrystal(rab, c);
            this.CollectedHide();
            hidden = true;
        }
    }
}
