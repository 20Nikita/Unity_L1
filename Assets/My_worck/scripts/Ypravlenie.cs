using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ypravlenie : MonoBehaviour
{
    public float speed = 20f;
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * Time.deltaTime * speed, 0);
    }
}
