using UnityEngine;



public class Level : MonoBehaviour
{
    public GameObject Level_item;
    public GameObject let_item;
    public Vector3 delta;
    private int N = 15;
    private float len_item = 100;
    private GameObject[] lewel = new GameObject[15];
    private GameObject[] let = new GameObject[15];
    private float speed = 20f;

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < N; i++)
        {
            lewel[i].transform.position = lewel[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
            let[i].transform.position = let[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
            if (lewel[i].transform.position.z <= -len_item)
            {
                int k = i - 1;
                if (k < 0) k = N - 1;
                Vector3 p = lewel[k].transform.position;
                p.z = p.z + len_item;
                lewel[i].transform.position = p;
            }
            if (let[i].transform.position.z <= -len_item)
            {
                int k = i - 1;
                if (k < 0) k = N - 1;
                Vector3 p = let[k].transform.position;
                p.z = p.z + len_item;
                let[i].transform.position = p;
                let[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180)));
            }
            speed = speed * (1 + 0.001f * Time.deltaTime);
        }

    }
    void Start()
    {
        for (int i = 0; i < N; i++) {
            lewel[i] = Instantiate(Level_item, new Vector3(0, 0, i * len_item), Quaternion.identity);
            let[i] = Instantiate(let_item, new Vector3(Random.Range(-delta.x, delta.x), Random.Range(-delta.y, delta.y), i * len_item + 0.5f * len_item + Random.Range(-delta.z, delta.z)), Quaternion.identity);
            let[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-180, 180)));
        }
    }
   
}
