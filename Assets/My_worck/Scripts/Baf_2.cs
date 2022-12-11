using UnityEngine;

public class Baf_2 : Baf
{
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
    public override void Baffer()
    {
        Constants.GetComponent<Constants>().speed /= 1.1f;
    }
}
