using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class MyButton : MonoBehaviour {
    public UnityEvent signalOnClick = new UnityEvent();
	// Use this for initialization
	void Start () {
		
	}
    public void _onClick(){
        this.signalOnClick.Invoke();
     }
	// Update is called once per frame
	void Update () {
		
	}
}
