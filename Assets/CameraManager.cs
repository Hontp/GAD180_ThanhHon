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

        
        transform.position = new Vector3(focusTarget.transform.position.x,focusTarget.transform.position.y,-10f);
    }
}
