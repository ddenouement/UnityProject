using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;
public class ConnectButtons : MonoBehaviour {
    public MyButton playBtn = null;
    public MyButton settings = null;
    public GameObject sp = null;

    void Awake()
    {
        playBtn.signalOnClick.AddListener(this.PlayBtnClicked);  Debug.Log("play");
       
        settings.signalOnClick.AddListener(this.SettingsClicked);
		
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SettingsClicked()
    {
        sp.layer = LayerMask.NameToLayer("UI");
    }
    public void PlayBtnClicked()
    {
         SceneManager.LoadScene("ChooseLevel");
    }
}
