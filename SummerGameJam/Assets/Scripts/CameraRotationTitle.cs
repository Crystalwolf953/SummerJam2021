using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationTitle : MonoBehaviour
{
    public float rotationSpeed;

    // Used for rotating the camera

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
