using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow : MonoBehaviour {
    public HeroRabbitGood rabbit;
	// Use this for initialization
	void Start () {
			}
	
	// Update is called once per frame
	void Update () {
        Transform rabit_transform = rabbit.transform;
        Transform camera_transform = this.transform;
        Vector3 rab_pos = rabit_transform.position;
        Vector3 cam_pos = camera_transform.position;
        cam_pos.x = rab_pos.x;
          cam_pos.y = rab_pos.y;
          camera_transform.position = rabit_transform.position;
	}
}
