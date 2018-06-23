using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsPanel : MonoBehaviour {
     public MyButton closeButton = null;
     public HeroRabbitGood rabb = null;
    // Use this for initialization
    void Awake()
    {
        closeButton.signalOnClick.AddListener( this.close );
        rabb = GetComponent<HeroRabbitGood>();
    }

  public  void close() {
        NGUITools.Destroy(this.gameObject);
        HeroRabbitGood.current.isPaused = false;
        //rabb.isPaused = false;
    }
	 
}
