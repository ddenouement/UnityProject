using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public MyButton  nextBtn = null;
    public MyButton rest = null;
    public UILabel coins = null;
    public UILabel fruits = null;
    public CrystalManager cm = null;
  
    public MyButton closeButton = null;
 //   public HeroRabbitGood rabb = null;
    //chooselevel,restart,how many crystals
     void Awake()
    {
       //  timeScale
         rest.signalOnClick.AddListener(this.replay );      
        nextBtn.signalOnClick.AddListener(this.chlvl);
        closeButton.signalOnClick.AddListener(this.close);

        coins.text = "+" + LevelController.current.getCoins();
        fruits.text = LevelController.current.getFruits() + "/" + LevelController.current.getMaxFruits();
     
      showCrystals() ;
	
    }
     private void showCrystals()
     {
      UI2DSprite[]   crystalColours = LevelController.current.crystalMan.crystals;
      Debug.Log(crystalColours.Length);
     
      cm.crystals[1].sprite2D = crystalColours[1].sprite2D;
      cm.crystals[2].sprite2D = crystalColours[2].sprite2D;
      cm.crystals[3].sprite2D = crystalColours[3].sprite2D;

     }
     public void chlvl()
     {
         NGUITools.Destroy(this.gameObject);

         if (LevelController.current.level == Level.Level1)
             SceneManager.LoadScene("Level2");
         if (LevelController.current.level == Level.Level2)
             SceneManager.LoadScene("ChooseLevel");	    
     
     }
     public void replay()
     {
         NGUITools.Destroy(this.gameObject); 
        
        if( LevelController.current.level == Level.Level1)
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
