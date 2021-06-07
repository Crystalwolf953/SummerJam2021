using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public LevelManager.Color color;
    public bool charged;
    private Rigidbody rigidBody;
    public AudioSource rollingBall;

    // Start is called before the first frame update
    void Start()
    {
        rollingBall = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rollingBall.pitch = Mathf.Clamp(rigidBody.velocity.magnitude, 0.1f, 1.0f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if(rigidBody.velocity.magnitude >= 0.2f && !rollingBall.isPlaying)
        {
            rollingBall.Play();
        }
        else if (rigidBody.velocity.magnitude < 0.2f && rollingBall.isPlaying)
        {
            rollingBall.Pause();
        }
    }

    public void ChangeChargeColor(LevelManager.Color color)
    {
        if(!charged)
        {
            charged = true;
        }
        this.color = color;
    }

    public void Decharge()
    {
        this.color = LevelManager.Color.Neutral;
    }
}
