using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineFire : MonoBehaviour
{
    
    [Header("Projectile Options")]
    public Transform firingPoint;
    // list of the possible projectiles this can fire
    public GameObject[] projectiles;
    // maximum projectiles in play
    public int maxProjectiles;
    // number of the projectiles that are in play
    private int projectileCount;
    
    public int projectileIndex;

    [Header("Sound Design")]
    private SoundManager _soundManager;

    [Header("Firing Timers")]
    public float fireCooldown;
    public float fireCooldownLength;

    public float fireCooldownPercent;


    // Start is called before the first frame update
    void Start()
    {
        _soundManager = FindObjectOfType<SoundManager>();
        //projectiles = new GameObject[maxProjectiles];
    }

    // Fire a projectile of type integer
    public void fireProjectile(Vector2 playerVelocity)
    {
        if(projectileCount < maxProjectiles && Time.time > fireCooldown + fireCooldownLength)
        {
            increaseProjCount();
            GameObject p = Instantiate(projectiles[projectileIndex],firingPoint);
            p.GetComponent<Projectile>().setParent(this);
            p.GetComponent<Projectile>().setPlayerVelocity(playerVelocity);
            fireCooldown = Time.time;
            //Sound Stuff
            _soundManager._firing = true;
            fireCooldownPercent = 0f;


//            Debug.Log("time.time=" + Time.time + "")
        }
    }

    public void reduceProjCount()
    {
        projectileCount -=1;
    }

    public void increaseProjCount()
    {
        projectileCount +=1;
    }

    // Update is called once per frame
    void Update()
    {
        

        projectileIndex = GetComponent<Submarine>().ship - 1;

        if (projectileIndex == 0)
        {
            maxProjectiles = 3;
            fireCooldownLength = 0.2f;
        }
        if (projectileIndex == 1)
        {
            maxProjectiles = 1;
            fireCooldownLength = 1.25f;
        }
        if (projectileIndex == 2)
        {
            maxProjectiles = 5;
            fireCooldownLength = 0.1f;
        }


        fireCooldownPercent += Time.deltaTime / (fireCooldownLength);
        if(fireCooldownPercent > 1)
        {
            fireCooldownPercent = 1f;
        }

    }
}
