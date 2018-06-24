using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public enum Level
{
    Level1,
    Level2,
    ChooseLevel
}
public class Door : MonoBehaviour {
    
    public Level level;
string scene = null;

	public SpriteRenderer doorCrystal = null;
	public SpriteRenderer doorFruit = null;
	public SpriteRenderer doorChecked = null;

	public Sprite crystal = null;
	public Sprite fruit = null;
    public Sprite check = null;

	// Use this for initialization
	void Start () { 
	/*	  if (level == Level.Level1) {
				scene = "Level1"; 
			} else if (level == Level.Level2 ) {
				scene = "Level2"; 
			}*/
            if (level == Level.ChooseLevel)
          {
              scene = "ChooseLevel"; 

          }
          if (level == Level.Level1 || level == Level.Level2)
          { 
			LevelStat stats1 = JsonUtility.FromJson<LevelStat>(PlayerPrefs.GetString ("Level1stats"));
			LevelStat stats2 = JsonUtility.FromJson<LevelStat>(PlayerPrefs.GetString ("Level2stats"));
			Debug.Log (PlayerPrefs.GetString ("Level1stats"));
			if (level == Level.Level1) {
				scene = "Level1";
				createDoor (stats1);
                //щоб не зайшов 
			} else if (level == Level.Level2 && stats1.levelCompleted) {
				scene = "Level2";
				createDoor (stats2);
			}
		} 
 
	}

	void OnTriggerEnter2D (Collider2D collider) {
       
		HeroRabbitGood rabbit = collider.GetComponent<HeroRabbitGood> ();
		if (rabbit != null) {
            if (LevelController.current != null)
            {
                if (LevelController.current.level == Level.Level1 || LevelController.current.level == Level.Level2)
                {
                    LevelController.current.onWin();
                    //  Debug.Log("here");
                }
            }
            else SceneManager.LoadScene(scene);
		} 
	}
    void createDoor(LevelStat stats)
    {
        if (stats != null)
        {
            if (stats.hasCrystals)
            {
                doorCrystal.sprite = crystal; 
            }
            if (stats.hasAllFruits)
            {
                doorFruit.sprite = fruit;
             }
            if (stats.levelCompleted)
                doorChecked.sprite = check;

        }
    }
     
}
