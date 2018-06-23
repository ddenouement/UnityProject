using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour {

    public Sprite heart;
    public Sprite used;

    UI2DSprite[] lifes = null; 
    void Start()
    {
        lifes = this.GetComponentsInChildren<UI2DSprite>();
    }

    public void die(int lifesCount)
    {
      //  Debug.Log(lifes.Length);       
        lifes[lifesCount].sprite2D = used;
    }
}
