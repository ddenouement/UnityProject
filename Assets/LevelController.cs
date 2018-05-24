using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
    public static LevelController current=null;
    Vector3 startingPosition;
	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
        current = this;
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void setStartPosition(Vector3 p)
    {
        this.startingPosition = p;

    }
    public void onRabbitDeath(HeroRabbitGood rab)
    {
        rab.transform.position = this.startingPosition;
        rab.death();
    }
}
