using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject mainObject;
    public List<GameObject> balls;
    public Rotation rotation;
    public List<Plate> plates;
    private bool hasActivated;
    public bool allActive;
    public enum Color {Red, Blue, Yellow, Green};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool active = true;

        foreach(Plate plate in plates)
        { 
            if (!plate.isActive())
            {
                active = false;
            }
        }

        if(active)
        {
            allActive = true;
        }

        if (allActive && !hasActivated)
        {
            hasActivated = true;
            StartCoroutine(AnimateRotationTowards(mainObject.transform, Quaternion.identity, 1f));
        }

        if (hasActivated)
        {
            mainObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
            foreach(Plate plate in plates)
            {
                plate.trigger.activated = false;
            }
            
        }
    }

    private IEnumerator AnimateRotationTowards(Transform target, Quaternion rotateTo, float timeTaken)
    {
        Quaternion start = target.rotation;

        List<Vector3> from = new List<Vector3>();
        
        for(int i = 0; i < balls.Count; i++)
        {
            from.Add(plates[i].activatingBall.transform.position);
        }

        Vector3[] to = new Vector3[balls.Count];

        for (float t = 0f; t < timeTaken; t += (Time.deltaTime / timeTaken))
        {
            for(int i = 0; i < balls.Count; i++ )
            {
                to[i] = plates[i].gameObject.transform.position;
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
    }
}
