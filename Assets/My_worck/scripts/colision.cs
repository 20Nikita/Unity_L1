using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    public bool IsNoTouch = true;
    public bool IsTouchBaff = false;
    public string stolknovenie;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)  {
        stolknovenie = other.gameObject.name;
        if (stolknovenie != "baf(Clone)")
        {
            Debug.Log(stolknovenie);
            IsNoTouch = false;
        }
        else
        {
            Debug.Log(stolknovenie);
            IsTouchBaff = true;
        }
    }
}
