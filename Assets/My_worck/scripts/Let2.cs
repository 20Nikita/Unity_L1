using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Let2 : Let
{
    private float speed = 20f;
    void Start()
    {
    }
    public override void Reset_pozition()
    { transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-90, 90))); 
    }
        void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
