using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinLoadController : MonoBehaviour
{
    public static GameObject skinToLoad;
    [SerializeField] private GameObject defaultSkin;

    private void Awake()
    {
        if (skinToLoad != null)
        {
            GameObject skinClone = Instantiate(skinToLoad, transform);
            Destroy(defaultSkin);
            CharacterController characterController = FindObjectOfType<CharacterController>();

            if (characterController != null)
            {
                Animator skinAnimator = skinClone.GetComponent<Animator>();
                characterController.animator = skinAnimator;
                characterController.characterBody = skinClone.transform;
            }
        }
    }
}
