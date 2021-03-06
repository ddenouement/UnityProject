﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {
    bool going_to_a = false;
    public float MoveSpeed = 1;
    public float time_to_wait = 1;
    public float time_to_pause = 1;

    public Vector3 moveBy;
    Vector3 pointA;
    Vector3 pointB;
	// Use this for initialization
	void Start () {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + moveBy;
	}
	
	// Update is called once per frame
	void Update () {
        time_to_wait -= Time.deltaTime;
        if (time_to_wait > 0)
        {
            return;
        }

        Vector3 my_pos = this.transform.position;
        Vector3 target;

        if (going_to_a) {
            target = this.pointA;
        }
        else {
            target = this.pointB;
        }
        Vector3 destination = target - my_pos;
        destination.z = 0;
        if (isArrived(my_pos, target))
        {
            going_to_a = !going_to_a;//return
            time_to_wait = time_to_pause;
        }
        else
        {//DO MOVE
            float move = MoveSpeed = Time.deltaTime; 
 Vector3 res = destination.normalized * Mathf.Min(move, Vector3.Distance(destination, my_pos));
            this.transform.position += res;
            


        }



	}
    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0; target.z = 0;

        return (Vector3.Distance(pos,target) < 0.02f);
    }
}
