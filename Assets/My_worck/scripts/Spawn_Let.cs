using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_let : MonoBehaviour
{
    public GameObject[] let_item;
    private int N;
    private GameObject Constants;
    private GameObject player;
    private GameObject[] let = new GameObject[100];
    private bool[] let_yhot = new bool[100];
    private float len_item;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        Constants = GameObject.Find("Constants");
        N = Constants.GetComponent<Constants>().N;
        len_item = Constants.GetComponent<Constants>().len_item;
        Debug.Log(N);
        for (int i = 0; i < N; i++)
        {
            int type = Random.Range(0, let_item.Length);
            let[i] = Instantiate(let_item[type], new Vector3(0, 0, (i + 0.5f) * len_item), Quaternion.identity);
            let[i].GetComponent<Let>().Reset_pozition();
        }
    }
    public void ReStart()
    {
        for (int i = 0; i < N; i++)
        {
            Destroy(let[i]);
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
                let[i].transform.position = let[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                if (let[i].transform.position.z <= 0 && !let_yhot[i])
                {
                    Constants.GetComponent<Constants>().caunt += 1;
                    let_yhot[i] = true;
                }
                else if (let[i].transform.position.z <= -len_item)
                {
                    let_yhot[i] = false;
                    int k = i - 1;
                    if (k < 0) k = N - 1;
                    Vector3 p = let[k].transform.position;
                    p.z = p.z + len_item + speed * 2; p.x = 0; p.y = 0;
                    let[i].transform.position = p;
                    let[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    let[i].GetComponent<Let>().Reset_pozition();
                }
            }

        }
    }
}
