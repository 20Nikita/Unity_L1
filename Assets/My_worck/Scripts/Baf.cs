using UnityEngine;
// Абстрактный класс для обьектов с бонусными эффектами
public abstract class Baf : MonoBehaviour
{
    // Функция, вызываемая при столкновении с бонусным обьектом
    public abstract void Baffer();
    // Всем таким компонентам нужен доступ к  Constants
    protected GameObject Constants;
    void Start()
    {
        Constants = GameObject.Find("Constants");
    }
}
