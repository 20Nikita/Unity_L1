using UnityEngine;

// Спавн и управление бафами
public class Spawn_Baf : MonoBehaviour
{
    public GameObject[] baf_item;   // Типы бафов
    private int N;                  // Количество бафов
    private GameObject Constants;   // Игровые константы
    private float len_item;         // Длинна элемента стены
    private float speed;            // Скорость движения
    private GameObject[] baf = new GameObject[100]; // Бафы
    private bool[] baf_yhot = new bool[100];        // Флаг взаимодействия с бафом

    void Start()
    {
        // Получить параметры из Constants
        Constants = GameObject.Find("Constants");
        N = Constants.GetComponent<Constants>().N;
        len_item = Constants.GetComponent<Constants>().len_item;
        // Заспавнить бафы
        for (int i = 0; i < N; i++)
        {
            int type = Random.Range(0, baf_item.Length); // Выбрать тип бафа
            baf[i] = Instantiate(baf_item[type], new Vector3(Random.Range(-28f, 28f), Random.Range(-28f, 28f), i * len_item + 0.5f + Random.Range(-len_item, len_item)), Quaternion.identity);
        }
    }
    // Поменять бафы
    public void ReStart()
    {
        for (int i = 0; i < N; i++)
        {
            Destroy(baf[i]);
        }
        Start();
    }

    void Update()
    {
        if (Constants.GetComponent<Constants>().play) // Жив
        {
            // Получить скорость
            speed = Constants.GetComponent<Constants>().speed;
            // Пройтись по бафам
            for (int i = 0; i < N; i++)
            {
                // Смищение
                baf[i].transform.position = baf[i].transform.position + new Vector3(0, 0, -speed * Time.deltaTime);
                // Баф за играком или было столкновение с ним
                if (baf[i].transform.position.z <= -len_item || !baf[i].GetComponent<Colision>().IsNoTouch)
                {
                    // Кцда переместить
                    int k = i - 1;
                    int type = Random.Range(0, baf_item.Length);
                    if (k < 0) k = N - 1;
                    Vector3 p = new Vector3(0, 0, (k + 0.5f) * len_item);
                    p = p + new Vector3(Random.Range(-28f, 28f), Random.Range(-28f, 28f), i * len_item + 0.5f + Random.Range(-len_item, len_item));
                     // Если было взаимодействие - применяем баф
                    if (!baf[i].GetComponent<Colision>().IsNoTouch)
                        baf[i].GetComponent<Baf>().Baffer();
                    // Обновляем баф
                    Destroy(baf[i]);
                    baf[i] = Instantiate(baf_item[type], p, Quaternion.identity);
                    baf[i].GetComponent<Colision>().IsNoTouch = true;
                }
            }
        }
    }
}
