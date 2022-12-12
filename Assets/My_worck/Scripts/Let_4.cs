using UnityEngine;

// Качающееся препядствие
public class Let_4 : Let
{
    private float delta = 0.3f;         // Угол откланения
    private float speed = 20f;          // Текущая скорость
    private float speed_const = 20f;    // Скорость
    private float smishenie = 29.6f;    // Смищение от центра движения
    // Подвешиваем наверх трубы
    public override void Reset_pozition()
    { 
        transform.position = transform.position + new Vector3(0, smishenie, 0);
    }
    void Update()
    {
        if (transform.rotation.z > delta)
            speed = -speed_const;
        else if (transform.rotation.z < -delta)
            speed = speed_const;
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
