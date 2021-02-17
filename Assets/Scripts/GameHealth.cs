using UnityEngine;
using UnityEngine.Networking;

public class GameHealth : NetworkBehaviour {

   

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
            // que the game over sound
            GameObject.Find("ZOMBIE DEATH SOUND").GetComponent<AudioSource>().Play(0);

            // For now, to let know that the game has ended, destroy Z TABLEZ
            Destroy(gameObject);
        }

        //healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
        // AS of now just print out the health to console
        Debug.Log("Game got damage, remaining health: " + health);
    }
}
