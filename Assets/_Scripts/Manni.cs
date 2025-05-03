using System;
using UnityEngine;

public class Manni : MonoBehaviour, IItem
{
    public static event Action<int> OnManniCollect;
    public int value = 1;
    public void Collect()
    {
        OnManniCollect.Invoke(value);
        Destroy(gameObject);
    }

}
