using System;
using UnityEngine;

public interface IPoolingObject<T> where T : MonoBehaviour, IPoolingObject<T>
{
    void Init(Action<T> returnAction);
    void ReturnToPool(T t);
}