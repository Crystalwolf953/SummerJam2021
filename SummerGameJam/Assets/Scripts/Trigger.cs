using UnityEngine;

[CreateAssetMenu(fileName = "New Trigger", menuName = "Trigger")]
public class Trigger : ScriptableObject
{
    public bool activated;
    public bool holeTrigger;
    public LevelManager.Color colorType;

    public virtual bool ValidActivation(BallController other)
    {
        return (this.colorType == other.color) && other.charged;
    }
}
