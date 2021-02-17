using UnityEngine;
using UnityEngine.Networking;


[RequireComponent(typeof(AudioSync))]
public class RandomZombieSounds : NetworkBehaviour
{
    private AudioSync audioSync;

    // Use this for initialization
    void Start()
    {
        audioSync = GetComponent<AudioSync>();
    }

    private void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
    }

    public void PlayRandomZombieDeathSound()
    {
        int clipPosition = Random.Range(0, audioSync.clips.Length);
        CmdPlayZombieSound(clipPosition);
    }

    [Command]
    public void CmdPlayZombieSound(int clipPosition)
    {
        audioSync.PlaySound(clipPosition);
    }


}
