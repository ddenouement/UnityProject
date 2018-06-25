using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;
public class ConnectButtons : MonoBehaviour {
    public GameObject settpanelPrefab=null;
    public MyButton playBtn = null;
    public MyButton settings = null;
    public GameObject sp = null;
    public AudioClip backSound = null;
    public AudioSource backSource = null;
  
    void Awake()
    {
        playBtn.signalOnClick.AddListener(this.PlayBtnClicked);  Debug.Log("play");
       
        settings.signalOnClick.AddListener(this.SettingsClicked);
        backSource = gameObject.AddComponent<AudioSource>();
        backSource.clip = backSound;
        backSource.loop = true;
        if (SoundController.soundControls.music) backSource.Play();
     
    } 
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!SoundController.soundControls.music) backSource.Stop();
       
	}
    public void SettingsClicked()
    {
        NGUITools.AddChild(UICamera.first.transform.gameObject, settpanelPrefab);
    
    //    sp.layer = LayerMask.NameToLayer("UI");
    }
    public void PlayBtnClicked()
    {
         SceneManager.LoadScene("ChooseLevel");
    }
}
