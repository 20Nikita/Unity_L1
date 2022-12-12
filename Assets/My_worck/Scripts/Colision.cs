using UnityEngine;
// Обработчик столкновений
public class Colision : MonoBehaviour
{
    public bool IsNoTouch = true; // Флаг столкновения
    public string stolknovenie;   // С кем столкнулись
    public string self_tupe;      // Кто я?
    private GameObject Constants; // Здесь лежит флаг проигрыша
    void OnCollisionEnter(Collision other)
    {
        stolknovenie = other.gameObject.name;
        // Если я бонус
        if (self_tupe == "baf")
        {
            // И столкнулся с играком (Не препядствием)
            if (stolknovenie == "Player")
                IsNoTouch = false; // Фиксируем это 
        }
        // Если я (игрок) столкнулся не с бонусом
        else if (stolknovenie.Substring(0, 3) != "baf")
        {
            // Проиграл
            Constants.GetComponent<Constants>().play = false;
        }
    }
    // Получить доступ к флагу проигрыша
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
}
