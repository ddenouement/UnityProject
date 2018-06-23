using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControls : MonoBehaviour {
   // public MyButton closeSettings = null;
    public HeroRabbitGood HeroRabbit;
    MyButton resume = null;
    public MyButton pause = null;
    public GameObject settpanelPrefab = null;

    void Awake()
    {
     //   closeSettings.signalOnClick.AddListener(this.PlayBtnClicked); 
        pause.signalOnClick.AddListener(this.pauseClicked);
     }
  public  void pauseClicked()
    {
        HeroRabbit.isPaused = true;
        NGUITools.AddChild(UICamera.first.transform.gameObject, settpanelPrefab);
      
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
