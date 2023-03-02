using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lance : Attack
{
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    float minSpeed;
    [SerializeField]
    AudioSource soundEffect;
    public override int OnHit()
    {
        Debug.Log(player.GetSpeed() + " out of " + minSpeed);
        if(player.GetSpeed()> minSpeed)
            return 0;
        soundEffect.Play();
        player.Stop();
        return 1000;
    }
}
