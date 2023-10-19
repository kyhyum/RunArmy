using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Boom : Drop
{

    public override void OnCollisionEnter(Collision target)
    {
        base.OnCollisionEnter(target);
        if (target.gameObject.tag == "Player" && !CatchTheSupplyGameManager.Instance.gameEndCheck)
        {
            CatchTheSupplyGameManager.Instance.ScoreMinusUpdate();
            //�Դ� ȿ����? ������ ������ ??
            spawn.InsertQueue(gameObject);
            gameObject.SetActive(false);

        }
    }
}
