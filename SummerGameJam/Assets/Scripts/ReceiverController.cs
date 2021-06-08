using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class ReceiverController : MonoBehaviour
{
    public LevelManager.Color color;
    public LevelManager.Color requiredColor;

    public LightningBoltScript yellowLightning;
    public LightningBoltScript redLightning;
    public LightningBoltScript blueLightning;
    public LightningBoltScript greenLightning;
    public LightningBoltScript orangeLightning;
    public LightningBoltScript purpleLightning;

    public GameObject sphere;
    private Renderer sphereRenderer;
    private Light sphereLight;
    public bool isCharged;

    public Material neutralMaterial;
    public Material yellowMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    public Material greenMaterial;
    public Material orangeMaterial;
    public Material purpleMaterial;

    public AudioSource lightningEffect;

    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = sphere.GetComponent<Renderer>();
        sphereLight = sphere.GetComponent<Light>();
        sphereLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeColor(LevelManager.Color newColor)
    {
        if(!isCharged)
        {
            isCharged = true;
            sphereLight.enabled = true;
        }
        if (newColor != color)
        {
            color = newColor;
            if (color == LevelManager.Color.Yellow)
            {
                sphereRenderer.material = yellowMaterial;
                sphereLight.color = Color.yellow;
            }
            else if (color == LevelManager.Color.Red)
            {
                sphereRenderer.material = redMaterial;
                sphereLight.color = Color.red;
            }
            else if (color == LevelManager.Color.Blue)
            {
                sphereRenderer.material = blueMaterial;
                sphereLight.color = Color.blue;
            }
            else if (color == LevelManager.Color.Green)
            {
                sphereRenderer.material = greenMaterial;
                sphereLight.color = Color.green;
            }
            else if (color == LevelManager.Color.Orange)
            {
                sphereRenderer.material = orangeMaterial;
                sphereLight.color = new Color(1f, 0.5f, 0);
            }
            else if (color == LevelManager.Color.Purple)
            {
                sphereRenderer.material = purpleMaterial;
                sphereLight.color = new Color(1f, 0f, 1f);
            }
            return true;
        }
        return false;
    }
    public void TriggerLightning()
    {
        if (!lightningEffect.isPlaying)
        {
            lightningEffect.Play();
        }

        if (color == LevelManager.Color.Yellow)
        {
            yellowLightning.Trigger();
        }
        else if (color == LevelManager.Color.Red)
        {
            redLightning.Trigger();
        }
        else if (color == LevelManager.Color.Blue)
        {
            blueLightning.Trigger();
        }
        else if (color == LevelManager.Color.Green)
        {
            greenLightning.Trigger();
        }
        else if (color == LevelManager.Color.Orange)
        {
            orangeLightning.Trigger();
        }
        else if (color == LevelManager.Color.Purple)
        {
            purpleLightning.Trigger();
        }
    }

    public void StopLightning()
    {
        lightningEffect.Stop();
    }
}
