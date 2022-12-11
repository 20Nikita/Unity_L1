using UnityEngine;

public class Spawn_Lewel : MonoBehaviour
{
    public GameObject lewel_item;
    private int N;
    private GameObject Constants;
    private float len_item;
    private float speed;

    private GameObject[] lewel = new GameObject[100];
    void Start()
    {
        Constants = GameObject.Find("Constants");
        N = Constants.GetComponent<Constants>().N;
        len_item = Constants.GetComponent<Constants>().len_item;
        for (int i = 0; i < N; i++)
        {
            lewel[i] = Instantiate(lewel_item, new Vector3(0, 0, (i + 0.5f) * len_item), Quaternion.identity);
        }
    }

    void Update()
    {
        if (Constants.GetComponent<Constants>().play)
        {
            speed = Constants.GetComponent<Constants>().speed;
            for (int i = 0; i < N; i++)
            {
                lewel[i].transform.position = lewel[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                if (lewel[i].transform.position.z <= -len_item)
                {
                    int k = i - 1;
                    if (k < 0) k = N - 1;
                    Vector3 p = lewel[k].transform.position;
                    p.z = p.z + len_item;
                    lewel[i].transform.position = p;
                }
            }
        }
    }
}
