using UnityEngine;
using UnityEngine.UI;
// Вспомогательный класс для Scrollbar-а. Нужен чтобы получить значение в Scrollbar
public class Center_ToItem : MonoBehaviour
{
    public float Value;
    void Update()
    {
        Value = GetComponent<Scrollbar>().value;
    }
}

