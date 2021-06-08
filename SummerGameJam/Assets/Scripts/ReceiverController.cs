using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRuby.LightningBolt;

public class ReceiverController : MonoBehaviour
{
    public LevelManager.Color color;
    public LightningBoltScript yellowLightning;
    public LightningBoltScript redLightning;
    public LightningBoltScript blueLightning;
    public LightningBoltScript greenLightning;
    public LightningBoltScript orangeLightning;
    public LightningBoltScript purpleLightning;

    public GameObject sphere;
    private Renderer sphereRenderer;

    public Material neutralMaterial;
    public Material yellowMaterial;
    public Material redMaterial;
    public Material blueMaterial;
    public Material greenMaterial;
    public Material orangeMaterial;
    public Material purpleMaterial;

    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = sphere.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeColor(LevelManager.Color newColor)
    {
        if (newColor != color)
        {
            color = newColor;
            if (color == LevelManager.Color.Yellow)
            {
                sphereRenderer.material = yellowMaterial;
            }
            else if (color == LevelManager.Color.Red)
            {
                sphereRenderer.material = redMaterial;
            }
            else if (color == LevelManager.Color.Blue)
            {
                sphereRenderer.material = blueMaterial;
            }
            else if (color == LevelManager.Color.Green)
            {
                sphereRenderer.material = greenMaterial;
            }
            else if (color == LevelManager.Color.Orange)
            {
                sphereRenderer.material = orangeMaterial;
            }
            else if (color == LevelManager.Color.Purple)
            {
                sphereRenderer.material = purpleMaterial;
            }
            return true;
        }
        return false;
    }
    public void TriggerLightning()
    {
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
}
