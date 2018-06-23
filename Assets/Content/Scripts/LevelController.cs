using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class LevelStat
{
    public bool hasCrystals = false;
    public bool hasAllFruits = false;
    public bool levelCompleted = false;
    public List<int> collectedFruits = new List<int>();
}
public class LevelController : MonoBehaviour {


    
    public UILabel coinsLabel;
    public UILabel fruitsLabel;
    public MyButton pauseButton;

    public LifeManager lifeMan ;
    public CrystalManager  crystalMan ;

    public GameObject settingsPrefab = null;
    public GameObject winPrefab = null;
    public GameObject losePrefab = null;

    int coins = 0;
    int fruits = 0;
    int overallfruits = 2;
   // int maxcoins = 10;   
    int lifes = 3;

    LevelStat stats;
    public Level level;//= Level.Level1;
    public static LevelController current=null;
    Vector3 startingPosition;
	// Use this for initialization
	void Start () {
		
	}
    string levelName()
    {
        if (level == Level.Level1)
            return "Level1";
        else if (level == Level.Level2)
            return "Level2";
        return "ChooseLevel";
    }
    void Awake()
    {
        current = this; 
       string str = PlayerPrefs.GetString(levelName() + "stats", null);
       this.stats = JsonUtility.FromJson<LevelStat>(str);
       if (this.stats == null)
       {
           this.stats = new LevelStat();
       }
       fruits = stats.collectedFruits.Count;
       overallfruits = FindObjectsOfType<CollectableFruit>().Length;


    }
	// Update is called once per frame
	void Update () {
		
	}
    public void setStartPosition(Vector3 p)
    {
        this.startingPosition = p;
      
    }
    public void addCoins(int coin)
    {
        this.coins += coin;
        coinsLabel.text = coins.ToString("D4");
    }

    public void addFruits(int fruit)
    {
        stats.collectedFruits.Add(fruit);
        this.fruits++;
        fruitsLabel.text = fruits + "/" + overallfruits;
    }

    public void addCrystal(HeroRabbitGood r, String colour)
    {
        this.startingPosition = r.transform.position;
        crystalMan.addColor(colour);
    }

    public int getCoins(){
        return coins;
    }

    public int getFruits(){
        return fruits;
    }

    public int getMaxFruits(){
        return overallfruits;
    }

    public int getLives(){
        return lifes;
    }

    IEnumerator RabbitNotDead(HeroRabbitGood rabbit)
    {
        yield return new WaitForSeconds(1);

        rabbit.transform.position = this.startingPosition;
        rabbit.revive();
    }
    public void onRabbitDeath(HeroRabbitGood rab)
    {
     //   rab.transform.position = this.startingPosition;
        rab.death();
//        Debug.Log(lifes);//321
       
        lifeMan.die(lifes);    

        lifes--;
           
        if (lifes != 0)
            StartCoroutine(RabbitNotDead(rab));
        else
        {
           // Debug.Log("lost");
            StartCoroutine(Loss());
        }

	
    }
    IEnumerator Loss()
    {
        yield return new WaitForSeconds(2);
         // losePrefab.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
          HeroRabbitGood.current.isPaused = true;
     
        NGUITools.AddChild(UICamera.first.transform.gameObject, losePrefab);
		
    }
    void saveStatistics()
    {
        stats.levelCompleted= true;
        bool ff = (stats.collectedFruits.Count == overallfruits);
        stats.hasAllFruits = ff;
        stats.hasCrystals = crystalMan.allFound();

        string str = JsonUtility.ToJson(this.stats);
        PlayerPrefs.SetString(levelName() + "stats", str);
        int c = PlayerPrefs.GetInt("coins")+this.coins;
        PlayerPrefs.SetInt("coins", c);
        PlayerPrefs.Save();
        
    }
   /* void onLose()
    {

    }*/
   public void onWin()
    {
        saveStatistics();
        HeroRabbitGood.current.isPaused = true;     
        StartCoroutine(winScreen());
    }
    IEnumerator winScreen()
    {
        yield return new WaitForSeconds(1);
          NGUITools.AddChild(UICamera.first.transform.gameObject, winPrefab);
		
    }
}
