using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class FruitManager : MonoBehaviour {

	public SpriteRenderer[] fruits = null;
	List<int> gathered = null;
	void Awake () {
        if (LevelController.current.level == Level.Level1)
            gathered = JsonUtility.FromJson<LevelStat>(PlayerPrefs.GetString("Level1stats")).collectedFruits;
        else
        {
            gathered = JsonUtility.FromJson<LevelStat>(PlayerPrefs.GetString("Level2stats")).collectedFruits;
       
        }
        //add to the fruitmanager in inspector
        fruits = this.GetComponentsInChildren<SpriteRenderer>();
		StartCoroutine(hide ());
	}

	IEnumerator hide () {
		yield return new WaitForSeconds (1);
		int max = LevelController.current.getMaxFruits ();
		for (int i = 1; i <= max; i++) {
			if (gathered.Contains (i)) {
				fruits [i-1].color = new Color (1f, 1f, 1f, 0.5f);
                CollectableFruit fruit = fruits[i - 1].GetComponentInParent<CollectableFruit>();
				fruit.hidden = true;
			}
		}
	} 
	void Update () {
		
	}
}
