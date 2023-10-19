using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : Drop
{
    public override void OnCollisionEnter(Collision target)
    {
        base.OnCollisionEnter(target);
        if (target.gameObject.tag == "Player" && !CatchTheSupplyGameManager.Instance.gameEndCheck)
        {
            CatchTheSupplyGameManager.Instance.ScorePlusUpdate();
            //먹는 효과음? 넣으면 좋을듯 ??
            spawn.InsertQueue(gameObject);
            gameObject.SetActive(false);

        }
    }
}
