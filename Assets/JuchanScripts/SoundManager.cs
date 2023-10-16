using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get => _instance; }

    private AudioSource _bgmSource;
    private GameObject _sfxOrigin;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(gameObject);

        _bgmSource = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        _sfxOrigin = Resources.Load<GameObject>("SFX");
    }

    public void PlayBGM(AudioClip clip)
    {
        if (_bgmSource.isPlaying)
            _bgmSource.Stop();

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX sfx = Instantiate(_sfxOrigin).GetComponent<SFX>();


    }
}
