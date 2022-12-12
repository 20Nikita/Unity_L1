using UnityEngine;
// Замена "Level" для уровня с настройками
public class Starter : MonoBehaviour
{
    public GameObject player;               // 
    private GameObject Constants;           // 
    public GameObject scrollbar;            // 
    public float speed_player;              // 
    private float speed_player_def = 80f;   //  

    void Start()
    {
        Constants = GameObject.Find("Constants");
    }

    void Update()
    {
        if (Constants.GetComponent<Constants>().play) // Жив
        {
            // Настройка скорости
            speed_player = speed_player_def * scrollbar.GetComponent<Center_ToItem>().Value + 10f;
            Nastroiki.Speed_player = speed_player;
            // Управление
            transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed_player, Input.GetAxis("Vertical") * Time.deltaTime * speed_player, 0);
        }
        else
        {
            // Вернутся в центр трубы
            transform.position = new Vector3(0, 0, 0);
            player.transform.position = new Vector3(0, -0.8f, 3);
            Constants.GetComponent<Constants>().play = true;
        }
    }
}
