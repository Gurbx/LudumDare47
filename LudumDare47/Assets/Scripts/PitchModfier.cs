using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitchModfier : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private float minPitch, maxPitch;

    private void Awake()
    {
        source.pitch = Random.Range(minPitch, maxPitch);
    }
}
