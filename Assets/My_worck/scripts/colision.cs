using UnityEngine;

public class Colision : MonoBehaviour
{
    public bool IsNoTouch = true;
    public string stolknovenie;
    public string self_tupe;
    private GameObject Constants;
    void OnCollisionEnter(Collision other)
    {
        stolknovenie = other.gameObject.name;
        if (self_tupe == "baf")
        {
            if (stolknovenie == "Player")
                IsNoTouch = false;
        }
        else if (stolknovenie.Substring(0, 3) != "baf")
        {
            Constants.GetComponent<Constants>().play = false;
        }
    }
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
}
