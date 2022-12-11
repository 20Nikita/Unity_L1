using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public GameObject player;
    public Text CauntText;
    public GameObject EndtBatton;
    public GameObject EndtBatton2;
    private float speed_player = 50f;
    private GameObject Constants;
    // Update is called once per frame
    void Update()
    {
        if (Constants.GetComponent<Constants>().play)
        {
            transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed_player, Input.GetAxis("Vertical") * Time.deltaTime * speed_player, 0);
            CauntText.text = "Счет: " + Constants.GetComponent<Constants>().caunt.ToString();
        }
        else
        {
            CauntText.text = "Вы проиграли со счетом: " + Constants.GetComponent<Constants>().caunt.ToString();
            EndtBatton.SetActive(true);
            EndtBatton2.SetActive(true);
        }
    }
    void Start()
    {
        speed_player = Nastroiki.Speed_player;
        Constants = GameObject.Find("Constants");
        EndtBatton.SetActive(false);
        EndtBatton2.SetActive(false);
    }

    public void Restart()
    {
        Start();
        GameObject.Find("Spawn_let").GetComponent<Spawn_Let>().ReStart(); 
        transform.position = new Vector3(0, 0, 0);
        player.transform.position = new Vector3(0, -0.8f, 3);
        Constants.GetComponent<Constants>().Start();
    }

}
