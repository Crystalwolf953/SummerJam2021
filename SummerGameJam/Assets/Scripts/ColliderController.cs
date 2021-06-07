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

        this.GetComponentInParent<CapsuleCollider>().isTrigger = (ball != null && plate.trigger.ValidActivation(ball.ball));
    }

    private void OnTriggerExit(Collider other)
    {
        this.GetComponentInParent<CapsuleCollider>().isTrigger = true;
    }
}
