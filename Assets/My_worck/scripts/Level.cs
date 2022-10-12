using UnityEngine;
using UnityEngine.UI;



public class Level : MonoBehaviour
{
    public GameObject Level_item;
    public GameObject let_item;
    public GameObject player;
    public Text CauntText;
    public float yskorenie = 0.001f;
    public GameObject EndtBatton;
    public Vector3 delta;
    private int N = 15;
    private float len_item = 100;
    private GameObject[] lewel = new GameObject[15];
    private GameObject[] let = new GameObject[15];
    private float speed = 30f;
    private float speed_player = 50f;
    private int caunt = 0;
    private float[] rotation = { 0, 45, 90, -45 };
    private float[] pasition = { 7.5f, 5f, 7.5f, -5f };

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<colision>().IsNoTouch)
        {
            transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed_player, Input.GetAxis("Vertical") * Time.deltaTime * speed_player, 0);
            for (int i = 0; i < N; i++)
            {
                lewel[i].transform.position = lewel[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                let[i].transform.position = let[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                let[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                let[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
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
                    int type = Random.Range(0, 4);
                    int k = i - 1;
                    if (k < 0) k = N - 1;
                    Vector3 p = let[k].transform.position;
                    p.z = p.z + len_item + (speed - 20f)*2;
                    if (type == 0)
                    {
                        p.x = Random.Range(-pasition[type], pasition[type]);
                        p.y = 0;
                    }
                    else if (type == 2)
                    {
                        p.x = 0;
                        p.y = Random.Range(-pasition[type], pasition[type]);
                    }
                    else if (type == 1)
                    {
                        float rand = Random.Range(-pasition[type], pasition[type]);
                        p.x = rand;
                        p.y = rand;
                    }
                    else if (type == 3)
                    {
                        float rand = Random.Range(-pasition[type], pasition[type]);
                        p.x = rand;
                        p.y = -rand;
                    }
                    let[i].transform.position = p;
                    let[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation[type]));
                    let[i].GetComponent<data>().IsYhot = true;
                }
                if (let[i].transform.position.z < player.transform.position.z)
                {
                    if (let[i].GetComponent<data>().IsYhot)
                    {
                        caunt = caunt + 1;
                        let[i].GetComponent<data>().IsYhot = false;
                    }
                }
                speed = speed * (1 + yskorenie * Time.deltaTime);
            }
            CauntText.text = "Счёт: " + caunt.ToString();
        }
        else
        {
            CauntText.text = "Вы погибли со счётом " + caunt.ToString();
            EndtBatton.SetActive(true);
        }
    }
    void Start()
    {
        EndtBatton.SetActive(false);
        for (int i = 0; i < N; i++) {
            int type = Random.Range(0, 4);
            lewel[i] = Instantiate(Level_item, new Vector3(0, 0, i * len_item), Quaternion.identity);
            if (type == 0)
                let[i] = Instantiate(let_item, new Vector3(Random.Range(-pasition[type], pasition[type]), 0, i * len_item + 0.5f * len_item), Quaternion.identity);
            else if (type == 2)
                let[i] = Instantiate(let_item, new Vector3(0, Random.Range(-pasition[type], pasition[type]), i * len_item + 0.5f * len_item), Quaternion.identity);
            else if (type == 1) {
                float rand = Random.Range(-pasition[type], pasition[type]);
                let[i] = Instantiate(let_item, new Vector3(rand, rand, i * len_item + 0.5f * len_item), Quaternion.identity);
            }
            else if (type == 3) {
                float rand = Random.Range(-pasition[type], pasition[type]);
                let[i] = Instantiate(let_item, new Vector3(rand, -rand, i * len_item + 0.5f * len_item), Quaternion.identity);
            }
            let[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotation[type]));
            let[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            let[i].GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);

        }
    }

    public void Restart()
    {
         for (int i = 0; i<N; i++) {
            Destroy(lewel[i]);
            Destroy(let[i]);
         }
        Start();
        transform.position = new Vector3(0, 0, 0);
        player.transform.position = new Vector3(0, -0.8f, 3);
        player.GetComponent<colision>().IsNoTouch = true;
        caunt = 0;
        speed = 20f;
    }
   
}
