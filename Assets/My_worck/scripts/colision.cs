using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colision : MonoBehaviour
{
    public bool IsNoTouch = true;
    //public bool IsTouchBaff = false;
    public string stolknovenie;
    public string self_tupe;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision other)  {
        stolknovenie = other.gameObject.name;
        if (self_tupe == "baf")
        {
            if (stolknovenie == "Player")
                IsNoTouch = false;
        }
        else if (stolknovenie != "baf(Clone)")
        {
            Debug.Log(stolknovenie);
            IsNoTouch = false;
        }
        //else
        {
            //Debug.Log(stolknovenie);
            //IsTouchBaff = true;
        }
    }
}
