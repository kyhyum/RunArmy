using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum BGM
{

}

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager Instance { get => _instance; }

    [SerializeField] private AudioMixerGroup _bgmGroup;
    private AudioSource _bgmSource;
    private GameObject _sfxOrigin;

    private const string BGM_PATH = "BGM/";

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
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _sfxOrigin = Resources.Load<GameObject>("SFX");

        string[] names = Enum.GetNames(typeof(BGM));
        foreach (string name in names)
        {
            _bgms.Add(name, Resources.Load<AudioClip>($"{BGM_PATH}{name}"));
        }
    }

    // TODO
    // BGM ¿¬°á ·Îµù¾À ÂÊ¿¡¼­ ¾À¸¶´Ù ¹Ù²Ù°Ô²û
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
