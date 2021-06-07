using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public Trigger trigger;
    public GameObject activatingBall = null;
    public Vector3 ballPosition;

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
        if(ball != null && trigger.ValidActivation(ball.ball))
        {
            trigger.activated = true;
            activatingBall = ball.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ball")
        {
            trigger.activated = false;
        }
    }

    public bool isActive()
    {
        return trigger.activated;
    }
}
