using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BGM
{
    GoingUp,
}

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get => _instance; }

    [SerializeField] private AudioMixerGroup _bgmGroup;
    private AudioSource _bgmSource;
    private GameObject _sfxOrigin;

    private const string BGM_PATH = "Sounds/BGM/";
    private const string SFX_PATH = "Sounds/SFX/";

    private Dictionary<string, AudioClip> _bgms = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            _bgmSource = gameObject.AddComponent<AudioSource>();
            _bgmSource.outputAudioMixerGroup = _bgmGroup;
            _bgmSource.playOnAwake = false;
            _bgmSource.loop = true;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _sfxOrigin = Resources.Load<GameObject>(SFX_PATH);

        string[] names = Enum.GetNames(typeof(BGM));
        foreach (string name in names)
        {
            _bgms.Add(name, Resources.Load<AudioClip>($"{BGM_PATH}{name}"));
        }
    }

    public void PlayBGM(BGM bgm)
    {
        if (_bgmSource.isPlaying)
            _bgmSource.Stop();

        _bgmSource.clip = _bgms[bgm.ToString()];
        _bgmSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX sfx = Instantiate(_sfxOrigin).GetComponent<SFX>();
        sfx.Play(clip);
    }
}
