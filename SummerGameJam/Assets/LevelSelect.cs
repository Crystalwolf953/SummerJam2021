using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public void Select (string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
