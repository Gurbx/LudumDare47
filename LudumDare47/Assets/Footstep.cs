using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    [SerializeField] private AudioSource footstepSound;
    [SerializeField] private ParticleSystem footstepEffect;

    public void PlayFootstep()
    {
        footstepSound.pitch = Random.Range(0.8f, 1.2f);
        footstepSound.Play();
        footstepEffect.Play();
    }
}
