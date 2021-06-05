using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float Rotation_Speed;
    public float Rotation_Friction; //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].
    public float Rotation_Smoothness; //Believe it or not, adjusting this before anything else is the best way to go.

    // Used to restrict rotation of the object
    public float horizontalRotationRestrictAngle;
    public float verticalRotationRestrictAngle;

    // Used for rotating the main object of the scene
    private float horizontalRotation;
    private float verticalRotation;
    private Quaternion currentRotation;
    private Quaternion rotateTo;

    public CameraController cameraController;
    private int cameraPositionIndex;
    private int previousCameraPositionIndex;
    public bool cameraRotating;
    public bool wasRotating;

    // Update is called once per frame
    void Update()
    {
        cameraPositionIndex = cameraController.positionIndex;
        previousCameraPositionIndex = cameraController.previousPositionIndex;
        cameraRotating = cameraController.rotating;

        // Get the input for rotation from the horizontal axis
        horizontalRotation += Input.GetAxis("Horizontal") * Rotation_Speed * Rotation_Friction;
        horizontalRotation = Mathf.Clamp(horizontalRotation, -horizontalRotationRestrictAngle, horizontalRotationRestrictAngle);

        // Get the input for rotation from the vertical axis
        verticalRotation += Input.GetAxis("Vertical") * Rotation_Speed * Rotation_Friction;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationRestrictAngle, verticalRotationRestrictAngle);

        // Get the current rotation of the object
        currentRotation = transform.rotation;

        // Depending on the position of the camera and where the camera is coming from, change the control scheme of the rotation and the start rotation of the main object
        if(cameraPositionIndex == 0)
        {
            if(cameraRotating)
            {
                if(previousCameraPositionIndex == 1)
                {
                    rotateTo = Quaternion.Euler(-verticalRotation, 0, horizontalRotation);
                }
                else
                {
                    rotateTo = Quaternion.Euler(verticalRotation, 0, -horizontalRotation);
                }
                wasRotating = true;
            }
            else
            {
                if(wasRotating)
                {
                    if(previousCameraPositionIndex == 1)
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = -verticalRotation;
                        verticalRotation = temp;
                    }
                    else
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = verticalRotation;
                        verticalRotation = -temp;
                    }
                    wasRotating = false;
                }
                rotateTo = Quaternion.Euler(horizontalRotation, 0, verticalRotation);
            }
        }
        else if(cameraPositionIndex == 1)
        {
            if(cameraRotating)
            {
                if (previousCameraPositionIndex == 2)
                {
                    rotateTo = Quaternion.Euler(-horizontalRotation, 0, -verticalRotation);
                }
                else
                {
                    rotateTo = Quaternion.Euler(horizontalRotation, 0, verticalRotation);
                }
                wasRotating = true;
            }
            else
            {
                if(wasRotating)
                {

                    if(previousCameraPositionIndex == 2)
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = -verticalRotation;
                        verticalRotation = temp;
                    }
                    else
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = verticalRotation;
                        verticalRotation = -temp;
                    }
                    wasRotating = false;
                }
                rotateTo = Quaternion.Euler(-verticalRotation, 0, horizontalRotation);
            }
        }
        else if(cameraPositionIndex == 2)
        {
            if(cameraRotating)
            {
                if (previousCameraPositionIndex == 3)
                {
                    rotateTo = Quaternion.Euler(verticalRotation, 0, -horizontalRotation);
                }
                else
                {
                    rotateTo = Quaternion.Euler(-verticalRotation, 0, horizontalRotation);
                }
                wasRotating = true;
            }
            else
            {
                if(wasRotating)
                {
                    if(previousCameraPositionIndex == 3)
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = -verticalRotation;
                        verticalRotation = temp;
                    }
                    else
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = verticalRotation;
                        verticalRotation = -temp;
                    }
                    wasRotating = false;
                }
                rotateTo = Quaternion.Euler(-horizontalRotation, 0, -verticalRotation);
            }
        }
        else if(cameraPositionIndex == 3)
        {
            if(cameraRotating)
            {
                if (previousCameraPositionIndex == 0)
                {
                    rotateTo = Quaternion.Euler(horizontalRotation, 0, verticalRotation);
                }
                else
                {
                    rotateTo = Quaternion.Euler(-horizontalRotation, 0, -verticalRotation);
                }
                wasRotating = true;
            }
            else
            {
                if(wasRotating)
                {
                    if(previousCameraPositionIndex == 0)
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = -verticalRotation;
                        verticalRotation = temp;
                    }
                    else
                    {
                        float temp = horizontalRotation;
                        horizontalRotation = verticalRotation;
                        verticalRotation = -temp;
                    }
                    wasRotating = false;
                }
                rotateTo = Quaternion.Euler(verticalRotation, 0, -horizontalRotation);
            }
        }

        transform.rotation = Quaternion.Lerp(currentRotation, rotateTo, Time.deltaTime * Rotation_Smoothness);
    }

    public void ResetCurrentRotation()
    {
        currentRotation = Quaternion.identity;
        rotateTo = Quaternion.identity;
        verticalRotation = 0;
        horizontalRotation = 0;
    }
}
