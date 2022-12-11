using UnityEngine;

public class Baf_1 : Baf
{
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
    public override void Baffer()
    {
        Constants.GetComponent<Constants>().caunt += 1;
    }
}
