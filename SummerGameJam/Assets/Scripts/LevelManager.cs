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
    public GameObject ball;
    public Rotation rotation;
    public Plate plate1;
    private bool hasActivated;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(plate1.activated && !hasActivated)
        {
            hasActivated = true;
            StartCoroutine(AnimateRotationTowards(mainObject.transform, Quaternion.identity, 1f));
        }
        if(hasActivated)
        {
            mainObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private IEnumerator AnimateRotationTowards(Transform target, Quaternion rotateTo, float timeTaken)
    {
        Quaternion start = target.rotation;
        Vector3 from = ball.transform.position;
        Vector3 to;
        for(float t = 0f; t < timeTaken; t += (Time.deltaTime / timeTaken))
        {
            to = plate1.gameObject.transform.position;
            target.rotation = Quaternion.Slerp(start, rotateTo, t);
            ball.transform.position = Vector3.Lerp(from, new Vector3(to.x, to.y + 0.5f, to.z), t);
            yield return null;
        }

        target.rotation = rotateTo;

        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.transform.SetParent(mainObject.transform);
        rotation.ResetCurrentRotation();
    }
}
