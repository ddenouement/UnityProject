using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController {// : MonoBehaviour {

   public bool sound = true;//once
   public bool music = true;//long

    SoundController()
    {
        sound = PlayerPrefs.GetInt("sound", 1) == 1;
        music = PlayerPrefs.GetInt("music", 1) == 1;
    } 
    void update(){
        PlayerPrefs.SetInt ("sound", this.sound ? 1 : 0);
        PlayerPrefs.SetInt ("music", this.music ? 1 : 0);		
		PlayerPrefs.Save ();
    }
	public void setSound(bool val) {
        this.sound = val; PlayerPrefs.SetInt("sound", this.sound ? 1 : 0);
        PlayerPrefs.Save();
   
		//update();
	}

	public void setMusic(bool val) {
		this.music = val;
        PlayerPrefs.SetInt("music", this.music ? 1 : 0);
        PlayerPrefs.Save();
   
		//update();
	}
     
    public static SoundController soundControls = new SoundController();
}
