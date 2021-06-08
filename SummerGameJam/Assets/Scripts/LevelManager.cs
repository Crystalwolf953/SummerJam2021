using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DigitalRuby.LightningBolt;

public class LevelManager : MonoBehaviour
{
    #region Singleton
    public static LevelManager instance;

    // Make sure there is only one instance of the level manager
    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one instance of LevelManager found!");
            return;
        }

        instance = this;
    }

    #endregion

    // For transitioning between scenes
    public Animator transition;
    public float transitionTime = 1f;

    public GameObject mainObject;
    public List<GameObject> balls;
    public Rotation rotation;
    public List<Plate> HolePlates;
    public List<Plate> FlatPlates;
    private bool hasActivated;
    public bool allActive;
    public bool allFlatPlatesActive;

    public AudioSource levelClear;
    public Light levelLight;

    public enum Color {Neutral, Red, Blue, Yellow, Green, Purple, Orange};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("RestartLevel") > 0f)
        {
            Restart();
        }

        bool active = true;

        if(HolePlates.Count > 0)
        {
            foreach(Plate plate in HolePlates)
            {
                if(!plate.isActive())
                {
                    active = false;
                }
            }
        }

        bool flatPlatesActive = true;

        if(FlatPlates.Count > 0)
        {
            foreach(Plate plate in FlatPlates)
            {
                if(!plate.isActive())
                {
                    flatPlatesActive = false;
                    active = false;
                }
            }
        }

        if(flatPlatesActive)
        {
            allFlatPlatesActive = true;
        }

        if (active)
        {
            allActive = true;
        }

        if (allActive && !hasActivated)
        {
            levelLight.color = new UnityEngine.Color(0f, .75f, 1f);
            StartCoroutine(AnimateRotationTowards(mainObject.transform, Quaternion.identity, 1f));
        }

        if(hasActivated)
        {
            mainObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
            foreach(Plate plate in HolePlates)
            {
                plate.activated = false;
            }
            foreach (Plate plate in FlatPlates)
            {
                plate.activated = false;
            }

            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1, false));
        }
    }

    private IEnumerator AnimateRotationTowards(Transform target, Quaternion rotateTo, float timeTaken)
    {
        Quaternion start = target.rotation;

        List<Vector3> from = new List<Vector3>();
        
        for(int i = 0; i < balls.Count; i++)
        {
            from.Add(HolePlates[i].activatingBall.transform.position);
        }

        Vector3[] to = new Vector3[balls.Count];

        for (float t = 0f; t < timeTaken; t += (Time.deltaTime / timeTaken))
        {
            for(int i = 0; i < balls.Count; i++ )
            {
                to[i] = HolePlates[i].gameObject.transform.position;
            }

            target.rotation = Quaternion.Slerp(start, rotateTo, t);

            for(int i = 0; i < balls.Count; i++)
            {
                balls[i].transform.position = Vector3.Lerp(from[i], new Vector3(to[i].x, to[i].y + 0.5f, to[i].z), t);
            }
            yield return null;
        }

        target.rotation = rotateTo;

        foreach(GameObject ball in balls)
        {
            ball.GetComponent<Rigidbody>().isKinematic = true;
            ball.transform.SetParent(mainObject.transform);
        }
        rotation.ResetCurrentRotation();
        hasActivated = true;
    }

    private IEnumerator LoadLevel(int levelIndex, bool restart)
    {
        transition.SetTrigger("Start");

        if(!restart && !levelClear.isPlaying)
        {
            levelClear.Play();
        }

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

    public void Restart()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex, true));
    }
}
