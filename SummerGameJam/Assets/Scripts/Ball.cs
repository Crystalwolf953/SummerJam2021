using UnityEngine;

[CreateAssetMenu(fileName = "New Ball", menuName = "Ball")]
public class Ball : ScriptableObject
{
    public LevelManager.Color colorType;
    public bool charged;
}
