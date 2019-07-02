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

    [Header("Firing Timers")]
    public float fireCooldown;
    public float fireCooldownLength;

    // Start is called before the first frame update
    void Start()
    {

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

    }
}
