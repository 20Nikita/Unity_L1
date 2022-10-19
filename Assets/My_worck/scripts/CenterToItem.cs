using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterToItem : MonoBehaviour
{
    public float Value;
    void Update()
    {
        Value = GetComponent<Scrollbar>().value;
    }
}

