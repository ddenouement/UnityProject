using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LossPanel : MonoBehaviour {


    public MyButton ChooseLvlButton = null;
    public MyButton rest = null; 
    public CrystalManager cm = null;

    public MyButton closeButton = null;
    public AudioClip sound = null;
    AudioSource soundSource = null;
    //   public HeroRabbitGood rabb = null;
    //chooselevel,restart,how many crystals
    void Awake()
    {
        //  timeScale
        HeroRabbitGood.current.isPaused = true;
        rest.signalOnClick.AddListener(this.replay);
        ChooseLvlButton.signalOnClick.AddListener(this.chlvl);
        closeButton.signalOnClick.AddListener(this.close);
     showCrystals();

     soundSource = gameObject.AddComponent<AudioSource>();
     soundSource.clip = sound;
     if (SoundController.soundControls.sound)  soundSource.Play();
    }
    private void showCrystals()
    {
        UI2DSprite[] crystalColours = LevelController.current.crystalMan.crystals;
        Debug.Log(crystalColours.Length);

        cm.crystals[1].sprite2D = crystalColours[1].sprite2D;
        cm.crystals[2].sprite2D = crystalColours[2].sprite2D;
        cm.crystals[3].sprite2D = crystalColours[3].sprite2D;

    }
    public void chlvl()
    {
        NGUITools.Destroy(this.gameObject);

        SceneManager.LoadScene("ChooseLevel");
    }
    public void replay()
    {
        NGUITools.Destroy(this.gameObject);

        if (LevelController.current.level == Level.Level1)
            SceneManager.LoadScene("Level1");
        if (LevelController.current.level == Level.Level2)
            SceneManager.LoadScene("Level2");
    }
    public void close()
    {
        NGUITools.Destroy(this.gameObject);
        SceneManager.LoadScene("ChooseLevel");
    }
}
