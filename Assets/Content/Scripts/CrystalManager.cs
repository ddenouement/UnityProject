using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour {

    public Sprite  blue = null;
    public Sprite green = null;
    public Sprite  red = null;
    bool r, g, b = false;
    public CrystalManager cm = null;
    public UI2DSprite[] crystals = null;
	// Use this for initialization
	void Start () {
        crystals = this.GetComponentsInChildren<UI2DSprite>();

	}
	
	// Update is called once per frame
    void Update()
    {

    }
      public  void addColor( string c){
           if(c == "blue"){
                    crystals[1].sprite2D =  blue;
                    b = true;
                    return;}
                if(c == "green"){
                    crystals[2].sprite2D = green;
                    g = true;
                    return;
                }
               if(c == "red"){
                    crystals[3].sprite2D = red;
                    r = true;
                    return;}

            }
        public bool allFound(){
            bool a = r && g;
            return (a&&b);
        }
}
