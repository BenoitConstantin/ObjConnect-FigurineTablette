using UnityEngine;
using System;
using UnityEngine.SceneManagement;


/// <summary>
/// Be aware this will not prevent a non singleton constructor
///   such as `T myT = new T();`
/// To prevent that, add `protected T () {}` to your singleton class.
/// 
/// As a note, this is made as MonoBehaviour because we need Coroutines.
/// </summary>
public class SimpleSingleton<T> : MonoBehaviour where T : SimpleSingleton<T>
{
    private static T _instance = null;

    public static T Instance
    {
        get
        {
            return _instance;
        }
    }

    protected virtual void Awake()
    {
         _instance = this as T;
    }
}