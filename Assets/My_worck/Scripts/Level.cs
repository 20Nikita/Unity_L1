using UnityEngine;
using UnityEngine.UI;

// Работа с меню и перемещение
public class Level : MonoBehaviour
{
    public GameObject player;           // Шарик символизирующий игрока
    public Text CauntText;              // Отображаемый текст
    public GameObject EndtBatton;       // Кнопка меню
    public GameObject EndtBatton2;      // Кнопка заного
    private float speed_player = 50f;   // Скорость игрока
    private GameObject Constants;       // Игровые константы

    void Update()
    {
        // Если живы
        if (Constants.GetComponent<Constants>().play)
        {
            // Управление
            transform.position = transform.position + new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speed_player, Input.GetAxis("Vertical") * Time.deltaTime * speed_player, 0);
            // Отображение счета
            CauntText.text = "Счет: " + Constants.GetComponent<Constants>().caunt.ToString();
        }
        else
        {
            // Сообщение проигрыща
            CauntText.text = "Вы проиграли со счетом: " + Constants.GetComponent<Constants>().caunt.ToString();
            // Сделать кнопки видимыми
            EndtBatton.SetActive(true);
            EndtBatton2.SetActive(true);
        }
    }
    void Start()
    {
        // Получить скорость из настроек
        speed_player = Nastroiki.Speed_player;
        // Доступ к информации о жизни игрока
        Constants = GameObject.Find("Constants");
        // Сделать кнопки невидимыми
        EndtBatton.SetActive(false);
        EndtBatton2.SetActive(false);
    }

    public void Restart()
    {
        Start();
        GameObject.Find("Spawn_let").GetComponent<Spawn_Let>().ReStart();   // Поменять препядствия
        transform.position = new Vector3(0, 0, 0);
        player.transform.position = new Vector3(0, -0.8f, 3);
        Constants.GetComponent<Constants>().Start();
    }

}
