using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float Rotation_Speed;
    public float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
    public float Rotation_Smoothness; //Believe it or not, adjusting this before anything else is the best way to go.

    public float horizontalRotationRestrictAngle;
    public float verticalRotationRestrictAngle;

    private float horizontalRotation;
    private float verticalRotation;
    private Quaternion currentRotation;
    private Quaternion rotateTo;

    // Update is called once per frame
    void Update()
    {
        // Get the input for rotation from the horizontal axis
        horizontalRotation += Input.GetAxis("Horizontal") * Rotation_Speed * Rotation_Friction;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -horizontalRotationRestrictAngle, horizontalRotationRestrictAngle);

        // Get the input for rotation from the vertical axis
        verticalRotation += Input.GetAxis("Vertical") * Rotation_Speed * Rotation_Friction;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationRestrictAngle, verticalRotationRestrictAngle);

        // Get the current rotation of the object
        currentRotation = transform.rotation;
        rotateTo = Quaternion.Euler(horizontalRotation, 0, verticalRotation);

        transform.rotation = Quaternion.Lerp(currentRotation, rotateTo, Time.deltaTime * Rotation_Smoothness);
    }
}
