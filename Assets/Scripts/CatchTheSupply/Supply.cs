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
            //�Դ� ȿ����? ������ ������ ??
            spawn.InsertQueue(gameObject);
            gameObject.SetActive(false);

        }
    }
}
