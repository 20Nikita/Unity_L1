using UnityEngine;
// Главные игровые константы
public class Constants : MonoBehaviour
{
    public int N = 15;                  // Количество обьектов стены (длинна прорисовки)
    public int caunt = 0;               // Счет
    public float len_item = 100;        // Длинна 1 компонента уровня
    public float speed = 30f;           // Текущая скорость
    public float yskorenie = 0.005f;    // Ускорение
    public bool play = true;            // Флаг игры
    private float defolt_speed = 30f;   // Начальная скорость

    public void Start()
    {
        speed = defolt_speed;   // Установить начальную скорость
        play = true;            // Играем
        caunt = 0;              // Обнулить счет
    }
    void Update()
    {
        // Постепенно увеличиваем скорость
        speed = speed * (1 + yskorenie * Time.deltaTime);
    }
}
