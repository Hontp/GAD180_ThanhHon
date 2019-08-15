using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollide : MonoBehaviour
{
    private SoundManager _soundManager;

    // Start is called before the first frame update
    void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _soundManager._enemyCollision = 0;
            _soundManager._enemyCollide = true;
            Camera.main.gameObject.GetComponent<CameraManager>().setTrauma(1f);
        }
    }
}
