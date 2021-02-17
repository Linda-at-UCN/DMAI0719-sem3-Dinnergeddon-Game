using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public int BulletDamage = 1;

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("bullet hit something");
        var hit = collision.gameObject;
        var health = hit.GetComponent<ZombieHealth>();
        if (health != null) {
            health.TakeDamage(BulletDamage);
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }


}