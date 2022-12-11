using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baf1 : Baf
{
    // Start is called before the first frame update
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
    public override void Baffer()
    {
        Constants.GetComponent<Constants>().caunt += 1;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
