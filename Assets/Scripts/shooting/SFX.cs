using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterSFX1 : MonoBehaviour
{
   
        [SerializeField] private AudioClip SoundClip;

        public void SoundClipStart()
        {
                SoundManager.Instance.PlaySFX(SoundClip);
        }
    

}
