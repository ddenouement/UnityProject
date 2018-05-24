using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBehaviour : MonoBehaviour {
    public float slowdown = 0.5f;
    Vector3 lastPosition;
	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
        lastPosition = Camera.main.transform.position;
    }
	// Update is called once per frame
	void Update () {
		
	}
    void LateUpdate()
    {
        Vector3 newPos = Camera.main.transform.position;
        Vector3 diff = newPos - lastPosition;
        lastPosition = newPos;
        Vector3 my_pos = this.transform.position;
        my_pos += slowdown * diff;
        this.transform.position = my_pos;

    }
}
