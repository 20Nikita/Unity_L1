using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    public bool IsNoTouch = true;
    public string stolknovenie = "ctena";
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)  {
        stolknovenie = other.gameObject.name;
        IsNoTouch = false;
    }
}
