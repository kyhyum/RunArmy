using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : ObjectPoolerBase<Obstacle>
{
    public ObstaclePooler(int spawnInitAmount) : base(spawnInitAmount)
    {
    }

    public override Obstacle Pull()
    {
        throw new System.NotImplementedException();
    }

    public override void Push(Obstacle t)
    {
        
    }
}
