using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour
{

    public int ZombieHit = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("zombie hit something");
        var hit = collision.gameObject;
        var zombieHealth = this.GetComponent<ZombieHealth>();
        var health = hit.GetComponent<GameHealth>();

         if (health != null)
        {
            health.TakeDamage(ZombieHit);

            // Also tick damage off the zombie health
            zombieHealth.TakeDamage(ZombieHit);
        }

    }

}
