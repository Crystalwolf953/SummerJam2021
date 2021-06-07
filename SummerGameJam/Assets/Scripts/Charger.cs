using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Charger", menuName = "Charger")]
public class Charger : ScriptableObject
{
    public LevelManager.Color color;
    
    public void Charge(BallController ball)
    {
        ball.ChangeChargeColor(color);
    }
}
