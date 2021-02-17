using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSync))]
public class PlayerShooting : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed;
    private AudioSync audioSync;

    void Start() {
        audioSync = GetComponent<AudioSync>();
    }


    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

      // transform.Rotate(0, x, 0);
       transform.Translate(0, 0, z);
    
        if (Input.GetKeyDown(KeyCode.Space))
        {   
            CmdFire();
            
        }
    }


    [Command]
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.up * bulletSpeed;
        NetworkServer.Spawn(bullet);
        audioSync.PlaySound(0);
        // GetComponent<AudioSource>().Play(0);
        Debug.Log("Bullet shot");
        // Destroy the bullet after 2 seconds
        //Destroy(bullet, 2.0f);
    }
}