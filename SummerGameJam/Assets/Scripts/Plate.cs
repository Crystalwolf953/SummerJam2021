using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public bool activated;
    public bool holeTrigger;
    public LevelManager.Color colorType;

    public GameObject activatingBall = null;
    public Vector3 ballPosition;

    public GameObject generator;
    public bool chargedGenerator;
    private ReceiverController receiver;

    // Start is called before the first frame update
    void Start()
    {
        if (generator != null)
        {
            receiver = generator.GetComponent<ReceiverController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        BallController ball = other.GetComponentInChildren<BallController>();
        if(ball != null && ValidActivation(ball))
        {
            activated = true;
            if(holeTrigger)
            {
                activatingBall = ball.gameObject;
            }
            else
            {
                if(generator.GetComponent<ReceiverController>().ChangeColor(ball.color))
                {
                    chargedGenerator = true;
                }
                if(chargedGenerator)
                {
                    receiver.TriggerLightning();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ball" && holeTrigger)
        {
            activated = false;
            activatingBall = null;
        }
        if(chargedGenerator)
        {
            chargedGenerator = false;
            BallController ball = other.GetComponentInChildren<BallController>();
            ball.Decharge();
            receiver.StopLightning();
        }
    }

    public bool isActive()
    {
        if(holeTrigger)
        {
            return activated && activatingBall != null;
        }
        else
        {
            return activated && receiver.color == receiver.requiredColor;
        }
    }

    public bool ValidActivation(BallController other)
    {
        if (holeTrigger)
        {
            return (this.colorType == other.color) && other.charged;
        }
        else
        {
            return other.charged;
        }
    }
}


