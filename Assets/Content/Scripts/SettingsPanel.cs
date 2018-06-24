using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsPanel : MonoBehaviour {
     public MyButton closeButton = null;
     public HeroRabbitGood rabb = null;
     

     bool music = true;
     bool sound = true;
     public MyButton soundBtn = null;
     public MyButton musicBtn = null;
     public UI2DSprite sBtn=null; public UI2DSprite mBtn=null;
   
      public Sprite soundOn, soundOff;
     public Sprite musicOn, musicOff;
    // Use this for initialization
    void Awake()
     {
         closeButton.signalOnClick.AddListener( this.close );
        rabb = GetComponent<HeroRabbitGood>();    
     	soundBtn.signalOnClick.AddListener (this.on_sound);
        musicBtn.signalOnClick.AddListener(this.on_music);

		sound = (SoundController.soundControls.sound);
        music = (SoundController.soundControls.music);

        sBtn.sprite2D = (sound ? soundOn : soundOff);
        mBtn.sprite2D = (music ? musicOn : musicOff);
	}
     
	void Update () {
        sBtn.sprite2D = (sound ? soundOn : soundOff);
        mBtn.sprite2D = (music ? musicOn : musicOff);
	}
  public  void close() {
        NGUITools.Destroy(this.gameObject);
        HeroRabbitGood.current.isPaused = false;
        //rabb.isPaused = false;
    }
 public void on_sound()
  {
        SoundController.soundControls.setSound(!sound);
      sound = !sound;

  //    soundBtn.GetComponent<SpriteRenderer>().sprite = (sound ? soundOn : soundOff);
       Sprite n = null;
       if (sound) n = soundOn;
       else n = soundOff;
       sBtn.sprite2D = n;
  // Debug.Log(n+" "+sound);
  }

 public void on_music()
  {
      SoundController.soundControls.setMusic(!music);
      music = !music;
      mBtn.sprite2D = (music ? musicOn : musicOff);
    //  musicBtn.GetComponent<SpriteRenderer>().sprite = (music ? musicOn : musicOff);
 
  }
	 
}
