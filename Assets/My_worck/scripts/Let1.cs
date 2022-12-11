using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Let1 : Let
{
    public override void Reset_pozition()
    {
        int type = Random.Range(0, 6);
        if (type == 1)
        {
            transform.position = transform.position + new Vector3(25, 0, 0);
        }
        if (type == 2)
        {
            transform.position = transform.position + new Vector3(-25, 0, 0);
        }
        else if (type == 3)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
        else if (type == 4)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            transform.position = transform.position + new Vector3(0, 25, 0);
        }
        else if (type == 5)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            transform.position = transform.position + new Vector3(0, -25, 0);
        }
    }
}
