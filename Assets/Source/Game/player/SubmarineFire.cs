using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineFire : MonoBehaviour
{
    public Transform firingPoint;
    // list of the possible projectiles this can fire
    public GameObject[] projectiles;
    // maximum projectiles in play
    public int maxProjectiles;
    // number of the projectiles that are in play
    private int projectileCount;
    
    // Start is called before the first frame update
    void Start()
    {
        projectiles = new GameObject[maxProjectiles];
    }

    // Fire a projectile of type integer
    void fireProjectile(int projectileIndex)
    {
        Instantiate(projectiles[projectileIndex],firingPoint);
    }

    public void reduceProjCount()
    {
        projectileCount -=1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
