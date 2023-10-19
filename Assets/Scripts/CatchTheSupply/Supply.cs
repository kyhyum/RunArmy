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
            //�Դ� ȿ����? ������ ������ ??
            spawn.InsertQueue(gameObject);
            gameObject.SetActive(false);

        }
    }
}
