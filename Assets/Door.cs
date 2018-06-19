using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public enum Level
{
    Level1,
    Level2 
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
 
	}

	void OnTriggerEnter2D (Collider2D collider) { 
		HeroRabbitGood rabbit = collider.GetComponent<HeroRabbitGood> ();
		if (rabbit != null) {			 
				SceneManager.LoadScene (scene);
		} 
	}
     
}
