using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_baf : MonoBehaviour
{
    public GameObject[] baf_item;
    private int N;
    private GameObject Constants;
    private float len_item;
    private float speed;
    private GameObject[] baf = new GameObject[100];
    private bool[] baf_yhot = new bool[100];
    // Start is called before the first frame update
    void Start()
    {
        Constants = GameObject.Find("Constants");
        N = Constants.GetComponent<Constants>().N;
        len_item = Constants.GetComponent<Constants>().len_item;
        for (int i = 0; i < N; i++)
        {
            int type = Random.Range(0, baf_item.Length);
            baf[i] = Instantiate(baf_item[type], new Vector3(Random.Range(-28f, 28f), Random.Range(-28f, 28f), i * len_item + 0.5f + Random.Range(-len_item, len_item)), Quaternion.identity);
        }
    }
    public void ReStart()
    {
        for (int i = 0; i < N; i++)
        {
            Destroy(baf[i]);
        }
        Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (Constants.GetComponent<Constants>().play)
        {
            speed = Constants.GetComponent<Constants>().speed;
            for (int i = 0; i < N; i++)
            {
                baf[i].transform.position = baf[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);

                if (baf[i].transform.position.z <= -len_item || !baf[i].GetComponent<colision>().IsNoTouch)
                {
                    int k = i - 1;
                    int type = Random.Range(0, baf_item.Length);
                    if (k < 0) k = N - 1;
                    Vector3 p = new Vector3(0, 0, (k + 0.5f) * len_item);
                    p = p + new Vector3(Random.Range(-28f, 28f), Random.Range(-28f, 28f), i * len_item + 0.5f + Random.Range(-len_item, len_item));
                    if (!baf[i].GetComponent<colision>().IsNoTouch)
                        baf[i].GetComponent<Baf>().Baffer();
                    Destroy(baf[i]);
                    baf[i] = Instantiate(baf_item[type], p, Quaternion.identity);
                    baf[i].GetComponent<colision>().IsNoTouch = true;

                }
            }
        }
    }
}
