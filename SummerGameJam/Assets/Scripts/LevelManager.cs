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

    private System.Collections.IEnumerator AnimateRotationTowards(Transform target, Quaternion rot, float dur)
    {
        float t = 0f;
        Quaternion start = target.rotation;
        while (t < dur)
        {
            target.rotation = Quaternion.Slerp(start, rot, t / dur);
            yield return null;
            t += Time.deltaTime;
        }
        target.rotation = rot;
        rotation.ResetCurrentRotation();
    }
}
