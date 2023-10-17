using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPoolerBase<T> : IPool<T> where T : MonoBehaviour, IPoolingObject<T>
{
    private Queue<T> _pool = new Queue<T>();
    private int _spawnInitAmount;
    private int _poolCount;

    private Action<T> returnAction;

    public ObjectPoolerBase(int spawnInitAmount)
    {
        _spawnInitAmount = spawnInitAmount;
    }

    public abstract T Pull();

    public abstract void Push(T t);
}
