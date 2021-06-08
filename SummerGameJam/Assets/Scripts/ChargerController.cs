using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class ChargerController : MonoBehaviour
{
    public Charger charger;
    public LightningBoltScript lightning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Here");
        BallController ball = other.GetComponentInChildren<BallController>();
        if (ball != null)
        {
            lightning.Trigger();
            charger.Charge(ball);
        }
    }
}
