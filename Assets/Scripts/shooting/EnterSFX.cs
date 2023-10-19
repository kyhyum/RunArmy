using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSFX : MonoBehaviour
{

    [SerializeField] private AudioClip SoundSource;

    public void SoundClipStart()
    {
        SoundManager.Instance.PlaySFX(SoundSource);
    }


}