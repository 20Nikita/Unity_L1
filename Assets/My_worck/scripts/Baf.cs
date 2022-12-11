using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Baf : MonoBehaviour
{
    protected GameObject Constants;
    public abstract void Baffer();
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
}
