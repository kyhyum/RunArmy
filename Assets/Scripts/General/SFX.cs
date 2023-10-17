using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField] private float destroyTime = 5f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Play(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);

        Destroy(gameObject, destroyTime);
    }
}
