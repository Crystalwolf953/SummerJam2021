using UnityEngine;

[CreateAssetMenu(fileName = "New Trigger", menuName = "Trigger")]
public class Trigger : ScriptableObject
{
    public bool activated;
    public LevelManager.Color colorType;

    public virtual bool ValidActivation(Ball other)
    {
        return (this.colorType == other.colorType) && other.charged;
    }
}
