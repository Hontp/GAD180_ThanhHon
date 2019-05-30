using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Rigidbody2D focusTarget;
    private Vector2 lookOffset;

    public float maxHorizontalOffset;
    public float maxVerticalOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalVelocity = focusTarget.velocity.x;
        float verticalVelocity = focusTarget.velocity.y;
        
        // Clamp the offset that the camera is horizontally
        if(horizontalVelocity > maxHorizontalOffset)
        {
            horizontalVelocity = maxHorizontalOffset;
        }
        else if(horizontalVelocity < -maxHorizontalOffset)
        {
            horizontalVelocity = -maxHorizontalOffset;
        }

        // Clamp the offset that the camera is vertical
        if(verticalVelocity > maxVerticalOffset)
        {
            verticalVelocity = maxVerticalOffset;
        }
        else if(verticalVelocity < -maxVerticalOffset)
        {
            verticalVelocity = -maxVerticalOffset;
        }
        
        transform.position = new Vector3(focusTarget.transform.position.x + horizontalVelocity ,
                                         focusTarget.transform.position.y +  verticalVelocity,
                                         -10f);
    }
}
