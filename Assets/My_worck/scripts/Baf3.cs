using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baf3 : Baf
{
    // Start is called before the first frame update
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
    public override void Baffer()
    {
        Constants.GetComponent<Constants>().speed *= 1.1f;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
