using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerController : MonoBehaviour
{
    public Charger charger;

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
            charger.Charge(ball);
        }
    }
}
