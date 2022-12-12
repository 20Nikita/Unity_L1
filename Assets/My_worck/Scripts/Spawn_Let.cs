using UnityEngine;

// Спавн и управление препядствиями
public class Spawn_Let : MonoBehaviour
{
    public GameObject[] let_item;   // Типы препядствий
    private int N;                  // Количество препядствий
    private GameObject Constants;   // Игровые константы
    private GameObject player;      // Игрок
    private GameObject[] let = new GameObject[100]; // Препядствия
    private bool[] let_yhot = new bool[100];        // Костыль для счетчика
    private float len_item;         // Длинна элемента стены
    private float speed;            // Скорость движения

    void Start()
    {
        // Получить параметры из Constants
        Constants = GameObject.Find("Constants");
        N = Constants.GetComponent<Constants>().N;
        len_item = Constants.GetComponent<Constants>().len_item;
        // Заспавнить Препядствия
        for (int i = 0; i < N; i++)
        {
            int type = Random.Range(0, let_item.Length);    // Выбрать тип препядствия
            let[i] = Instantiate(let_item[type], new Vector3(0, 0, (i + 0.5f) * len_item), Quaternion.identity);
            let[i].GetComponent<Let>().Reset_pozition();
        }
    }
    // Поменять препядствия
    public void ReStart()
    {
        for (int i = 0; i < N; i++)
        {
            Destroy(let[i]);
            let_yhot[i] = false;
        }
        Start();
    }

    void Update()
    {
        if (Constants.GetComponent<Constants>().play)   // Жив
        {
            // Получить скорость
            speed = Constants.GetComponent<Constants>().speed;
            // Пройтись по препядствиям
            for (int i = 0; i < N; i++)
            {
                // Смищение
                let[i].transform.position = let[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                // Препядствие за играком и не было учтено
                if (let[i].transform.position.z <= 0 && !let_yhot[i])
                {
                    // Увеличить счет
                    Constants.GetComponent<Constants>().caunt += 1; 
                    // Запомнить что за это препядствие уже увеличен счет
                    let_yhot[i] = true;                             
                }
                // Препядствие далико за играком
                else if (let[i].transform.position.z <= -len_item)
                {
                    // Меняем и перемищаем его
                    let_yhot[i] = false;
                    int k = i - 1;
                    if (k < 0) k = N - 1;
                    Vector3 p = let[k].transform.position;
                    p.z = p.z + len_item + speed * 2; p.x = 0; p.y = 0;
                    Destroy(let[i]);
                    int type = Random.Range(0, let_item.Length);
                    let[i] = Instantiate(let_item[type], p, Quaternion.identity);
                    let[i].GetComponent<Let>().Reset_pozition();
                }
            }
        }
    }
}
