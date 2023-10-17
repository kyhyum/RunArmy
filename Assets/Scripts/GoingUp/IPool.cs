using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IPool<T>
{
    void Push(T t);
    T Pull();
}