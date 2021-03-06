using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int positionIndex = 0;
    public int previousPositionIndex;
    private int numberOfPositions = 4;

    // Used for rotating the camera
    private Quaternion currentRotation;
    private Quaternion rotateTo;
    public bool rotating;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("RotateCameraLeft") > 0f && !rotating)
        {
            rotating = true;
            previousPositionIndex = positionIndex;
            positionIndex = (positionIndex + 3) % numberOfPositions;
            StartCoroutine(RotateMe(Vector3.up * 90, 1f));
        }
        else if(Input.GetAxis("RotateCameraRight") > 0f && !rotating)
        {
            rotating = true;
            previousPositionIndex = positionIndex;
            positionIndex = (positionIndex + 1) % numberOfPositions;
            StartCoroutine(RotateMe(Vector3.up * -90, 1f));
        }
    }

    IEnumerator RotateMe(Vector3 rotateBy, float timeTaken)
    {
        currentRotation = transform.rotation;
        rotateTo = Quaternion.Euler(transform.eulerAngles + rotateBy);
        for (var t = 0f; t <= 1; t += Time.deltaTime / timeTaken)
        {
            transform.rotation = Quaternion.Slerp(currentRotation, rotateTo, t);
            yield return null;
        }

        transform.rotation = rotateTo;
        rotating = false;
    }

}
