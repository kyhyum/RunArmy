using System;
using UnityEngine;

public abstract class ObjectPoolerBase<T> where T : MonoBehaviour, IPoolingObject<T>
{
    protected int spawnInitAmount;
    protected int poolCount;

    protected Action<T> returnAction;

    public ObjectPoolerBase(int spawnInitAmount)
    {
        this.spawnInitAmount = spawnInitAmount;
    }
}
