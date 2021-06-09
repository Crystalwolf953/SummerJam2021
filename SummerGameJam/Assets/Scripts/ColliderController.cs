using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    public Plate plate;

    // Start is called before the first frame update
    void Start()
    {
        plate = GetComponentInParent<Plate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        BallController ball = other.GetComponentInChildren<BallController>();

        if(plate.holeTrigger) //&& LevelManager.instance.allFlatPlatesActive)
        {
            this.GetComponentInParent<CapsuleCollider>().isTrigger = (ball != null && plate.ValidActivation(ball));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(plate.holeTrigger)
        {
            this.GetComponentInParent<CapsuleCollider>().isTrigger = false;
        }
    }
}
