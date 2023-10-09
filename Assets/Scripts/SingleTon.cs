using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon : MonoBehaviour
{
    public static SingleTon ins;
    [SerializeField] public int point = 0;
    private void Start()
    {
        ins = this;
    }
}
