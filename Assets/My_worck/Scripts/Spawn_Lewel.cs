using UnityEngine;

// Спавн и управление стенами
public class Spawn_Lewel : MonoBehaviour
{
    public GameObject lewel_item;   // Элемент стены
    private int N;                  // Количество стен
    private GameObject Constants;   // Игровые константы
    private float len_item;         // Длинна элемента стены
    private float speed;            // Скорость движения

    private GameObject[] lewel = new GameObject[100]; // Стены

    void Start()
    {
        // Получить параметры из Constants
        Constants = GameObject.Find("Constants");
        N = Constants.GetComponent<Constants>().N;
        len_item = Constants.GetComponent<Constants>().len_item;
        // Заспавнить стены
        for (int i = 0; i < N; i++)
        {
            lewel[i] = Instantiate(lewel_item, new Vector3(0, 0, (i + 0.5f) * len_item), Quaternion.identity);
        }
    }

    void Update()
    {
        if (Constants.GetComponent<Constants>().play) // Жив
        {
            // Получить скорость
            speed = Constants.GetComponent<Constants>().speed; 
            // Пройтись по стенам
            for (int i = 0; i < N; i++)
            {
                // Смищение
                lewel[i].transform.position = lewel[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                if (lewel[i].transform.position.z <= -len_item) // Стена за играком
                {
                    // Перемещаем её
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
