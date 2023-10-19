using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    [SerializeField] private AudioClip[] hitClips;

    public void PlayHitClip()
    {
        if (hitClips.Length > 0)
        {
            int index = UnityEngine.Random.Range(0, hitClips.Length);
            SoundManager.Instance.PlaySFX(hitClips[index]);
        }
    }
}
