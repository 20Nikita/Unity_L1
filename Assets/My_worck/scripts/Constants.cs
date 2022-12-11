using UnityEngine;

public class Constants : MonoBehaviour
{
    public int N = 15;
    public int caunt = 0;
    public float len_item = 100;
    public float speed = 30f;
    public float yskorenie = 0.001f;
    public bool play = true;
    private float defolt_speed = 30f;

    public void Start()
    {
        speed = defolt_speed;
        play = true;
        caunt = 0;
    }
        void Update()
    {
        speed = speed * (1 + yskorenie * Time.deltaTime);
    }
}
