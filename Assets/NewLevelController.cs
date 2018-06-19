using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewLevelController : MonoBehaviour {

    public static NewLevelController current = null;
  public  Vector3 startingPosition = new Vector3(0f, 0.5f, -6f);
    public UILabel coins; 
    void Awake()
    {
        current = this; 
     }

  
    public void onRabbitDeath(HeroRabbitGood rabbit)
    {  rabbit.death();
    StartCoroutine(RabbitNotDead(rabbit));
     }
    IEnumerator RabbitNotDead(HeroRabbitGood rabbit)
    {
        yield return new WaitForSeconds(1);

        rabbit.transform.position = this.startingPosition;
        rabbit.revive();
    }
    
}
