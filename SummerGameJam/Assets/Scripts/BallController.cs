using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class BallController : MonoBehaviour
{
    public LevelManager.Color color;
    public bool charged;
    private Rigidbody rigidBody;
    public AudioSource rollingBall;

    private Renderer ballRenderer;
    public Material neutralMaterial;
    public Material yellowMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    public Material greenMaterial;


    // Start is called before the first frame update
    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
        rollingBall = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rollingBall.pitch = Mathf.Clamp(rigidBody.velocity.magnitude, 0.1f, 1.0f);
        if(color == LevelManager.Color.Neutral)
        {
            charged = false;
        }
        if(charged)
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        BallController ball = collision.gameObject.GetComponent<BallController>();
        
        if(ball != null)
        {
            if(!ball.charged)
            {
                ball.charged = charged;
                ball.color = color;
            }
            else if(charged)
            {
                // do something if both are charged
            }
        }
        
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

        if(color == LevelManager.Color.Yellow)
        {
            ballRenderer.material = yellowMaterial;
        }
        else if(color == LevelManager.Color.Red)
        {
            ballRenderer.material = redMaterial;
        }
        else if(color == LevelManager.Color.Blue)
        {
            ballRenderer.material = blueMaterial;
        }
        else if(color == LevelManager.Color.Green)
        {
            ballRenderer.material = greenMaterial;
        }
    }

    public void Decharge()
    {
        charged = false;
        this.color = LevelManager.Color.Neutral;
        ballRenderer.material = neutralMaterial;
    }
}
