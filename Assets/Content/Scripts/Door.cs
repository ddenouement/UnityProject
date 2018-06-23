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

	// Use this for initialization
	void Start () { 
		  if (level == Level.Level1) {
				scene = "Level1"; 
			} else if (level == Level.Level2 ) {
				scene = "Level2"; 
			}
          else if (level == Level.ChooseLevel)
          {
              scene = "ChooseLevel"; 

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
     
}
