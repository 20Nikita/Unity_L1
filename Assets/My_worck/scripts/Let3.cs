using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Let3 : Let
{
    private float speed_const = 20f;
    private float speed = 20f;
    private float delta = 22f;
    private int type;
    void Start()
    {
    }
    public override void Reset_pozition()
    {
        type = Random.Range(0, 2);
        if (type == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
    }
    void Update() 
    {
        if (type == 0)
        {
            if (transform.position.x > delta)
                speed = -speed_const;
            else if (transform.position.x < -delta)
                speed = speed_const;
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (type == 1)
        {
            if (transform.position.y > delta)
                speed = -speed_const;
            else if (transform.position.y < -delta)
                speed = speed_const;
            transform.position = transform.position + new Vector3(0,speed * Time.deltaTime, 0);
        }
    }
}
