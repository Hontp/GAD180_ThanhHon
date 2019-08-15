using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public Rigidbody2D focusTarget;
    private Vector2 lookOffset;

    public float maxHorizontalOffset;
    public float maxVerticalOffset;


    public float traumaDecrease;
    public float _trauma;
    public float maxOffset;
    public float Trauma
    {
        set
        {
             _trauma = Mathf.Clamp(value, 0, 1);
        }
        get
        {
            return Mathf.Clamp(_trauma, 0, 1);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setTrauma(float traumaIn)
    {
        Trauma = traumaIn;
    }

    private void LateUpdate()
    {
        Trauma -= traumaDecrease;
        float shake = Mathf.Pow(Trauma, 2);
        transform.Translate(new Vector3( (maxOffset * shake * (Mathf.PerlinNoise(Random.value, Random.value)-0.5f)) , (maxOffset * shake * (Mathf.PerlinNoise(Random.value, Random.value)-0.5f)) ,0f));
    }

    // Update is called once per frame
    void Update()
    {
        if(focusTarget != null)
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
}
