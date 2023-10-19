using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : Drop
{
    EnterSFX entersfx;
    public override void Start()
    {
        base.Start();
        entersfx = GetComponent<EnterSFX>();
    }
    public override void OnCollisionEnter(Collision target)
    {
        base.OnCollisionEnter(target);
        if (target.gameObject.tag == "Player" && !CatchTheSupplyGameManager.Instance.gameEndCheck)
        {
            entersfx.SoundClipStart();
            CatchTheSupplyGameManager.Instance.ScorePlusUpdate();
            //먹는 효과음? 넣으면 좋을듯 ??
            spawn.InsertQueue(gameObject);
            gameObject.SetActive(false);

        }
    }
}
