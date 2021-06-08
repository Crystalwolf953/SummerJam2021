using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class ChargerController : MonoBehaviour
{
    public LightningBoltScript lightning;
    public LevelManager.Color color;

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
        BallController ball = other.GetComponentInChildren<BallController>();
        if (ball != null)
        {
            lightning.Trigger();
            Charge(ball);
        }
    }

    public void Charge(BallController ball)
    {
        ball.ChangeChargeColor(color);
    }
}
