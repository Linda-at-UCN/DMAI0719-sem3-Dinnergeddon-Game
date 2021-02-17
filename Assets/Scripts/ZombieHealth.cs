using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class ZombieHealth : NetworkBehaviour {

    [SyncVar]
    public int health = 1;
    public RectTransform healthBar;

    public void TakeDamage(int amount) {
        if (!isServer) {
            return;
        }

        health -= amount;
        if (health <= 0) {
            health = 0;
            Debug.Log("You be Deadedas!");
            GameObject.Find("ZOMBIE DEATH SOUND").GetComponent<RandomZombieSounds>().PlayRandomZombieDeathSound();
            Destroy(gameObject);
        }

        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
        // AS of now just print out the health to console
        Debug.Log("Player lost health, remaining health: " + health);
    }
}