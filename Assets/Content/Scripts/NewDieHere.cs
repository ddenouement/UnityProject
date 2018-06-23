using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDieHere : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        HeroRabbitGood rab = collider.GetComponent<HeroRabbitGood>();
        if (rab != null)
        {
            NewLevelController.current.onRabbitDeath(rab);

        }

    }
}
