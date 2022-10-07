using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject spawnPoint;
    private int N = 15;
    public float let_item = 100;
    private GameObject[] lewel = new GameObject[100];
    private float speed = 20f;

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < N; i++) {
            lewel[i].transform.position = lewel[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
            if (lewel[i].transform.position.z <= -100) {
                int k = i - 1;
                if (k < 0) k = N - 1;
                Vector3 p = lewel[k].transform.position;
                p.z = p.z + let_item;
                lewel[i].transform.position = p;

            }

        }

    }
    void Start()
    {
        for(int i = 0; i < N; i++)
            lewel[i] = Instantiate(spawnPoint, new Vector3(0, 0, i * let_item), Quaternion.identity);
    }
   
}
