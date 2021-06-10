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

    // For flat trigger
    public GameObject generator;
    public bool chargedGenerator;
    private ReceiverController receiver;

    // For hole trigger
    private Light holeLight;
    private float nextIntensity;
    public float lightChange;

    // Start is called before the first frame update
    void Start()
    {
        if (generator != null)
        {
            receiver = generator.GetComponent<ReceiverController>();
        }
        if(holeTrigger)
        {
            holeLight = GetComponent<Light>();
            nextIntensity = 0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(holeTrigger)
        {
            if(nextIntensity == 1f)
            {
                holeLight.intensity += lightChange;
                if(holeLight.intensity >= 1f)
                {
                    nextIntensity = 0f;
                }
            }
            else if(nextIntensity == 0f)
            {
                holeLight.intensity -= lightChange;
                if (holeLight.intensity <= 0f)
                {
                    nextIntensity = 1f;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BallController ball = other.GetComponentInChildren<BallController>();
        if (ball != null && ValidActivation(ball))
        {
            if (holeTrigger)
            {
                activatingBall = ball.gameObject;
                Debug.Log(activatingBall.name);
            }
            else
            {
                if (receiver.ChangeColor(ball.color))
                {
                    chargedGenerator = true;
                }
                if (chargedGenerator)
                {
                    receiver.TriggerLightning();
                }
            }
            activated = true;
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


