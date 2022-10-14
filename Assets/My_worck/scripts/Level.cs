using UnityEngine;
using UnityEngine.UI;



public class Level : MonoBehaviour
{
    public GameObject Level_item;
    public GameObject baf_item;
    public GameObject player;
    public Text CauntText;
    public GameObject EndtBatton;
    private int N;
    private float len_item;
    private GameObject[] lewel = new GameObject[15];
    private GameObject[] baf = new GameObject[15];
    private float speed;
    private float speed_player = 50f;
    private int caunt = 0;
    private GameObject Constants;
    // Update is called once per frame
    void Update()
    {
        if (Constants.GetComponent<Constants>().play)
        {
            speed = Constants.GetComponent<Constants>().speed;
            transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed_player, Input.GetAxis("Vertical") * Time.deltaTime * speed_player, 0);
            for (int i = 0; i < N; i++)
            {
                lewel[i].transform.position = lewel[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                baf[i].transform.position = baf[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                if (lewel[i].transform.position.z <= -len_item)
                {
                    int k = i - 1;
                    if (k < 0) k = N - 1;
                    Vector3 p = lewel[k].transform.position;
                    p.z = p.z + len_item;
                    lewel[i].transform.position = p;
                }
                if (baf[i].transform.position.z <= -len_item || !baf[i].GetComponent<colision>().IsNoTouch)
                {
                    int k = i - 1;
                    if (k < 0) k = N - 1;
                    Vector3 p = lewel[k].transform.position;
                    p = p + new Vector3(Random.Range(-28f, 28f), Random.Range(-28f, 28f), i * len_item + 0.5f + Random.Range(-len_item, len_item));
                    baf[i].transform.position = p;
                    if (!baf[i].GetComponent<colision>().IsNoTouch)
                        Constants.GetComponent<Constants>().caunt += 1;
                    baf[i].GetComponent<colision>().IsNoTouch = true;
                }
                
            }
            
            CauntText.text = "Счёт: " + Constants.GetComponent<Constants>().caunt.ToString();
        }
        else
        {
            CauntText.text = "Вы погибли со счётом " + caunt.ToString();
            EndtBatton.SetActive(true);
        }
    }
    void Start()
    {
        Constants = GameObject.Find("Constants");
        N = Constants.GetComponent<Constants>().N;
        len_item = Constants.GetComponent<Constants>().len_item;
        EndtBatton.SetActive(false);
        for (int i = 0; i < N; i++) {
            lewel[i] = Instantiate(Level_item, new Vector3(0, 0, i * len_item), Quaternion.identity);
            baf[i] = Instantiate(baf_item, new Vector3(Random.Range(-28f, 28f), Random.Range(-28f, 28f), i * len_item + 0.5f + Random.Range(-len_item, len_item)), Quaternion.identity);
        }
    }

    public void Restart()
    {
         for (int i = 0; i<N; i++) {
            Destroy(lewel[i]);
            Destroy(baf[i]);
        }
        Start();
        GameObject.Find("Spawn_let").GetComponent<Spawn_Let>().ReStart();
        transform.position = new Vector3(0, 0, 0);
        player.transform.position = new Vector3(0, -0.8f, 3);
        Constants.GetComponent<Constants>().Start();

    }

}
