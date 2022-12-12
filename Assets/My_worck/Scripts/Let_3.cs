using UnityEngine;

// Смещающееся препядствие (вверх-вниз, влево-вправо)
public class Let_3 : Let
{
    private float speed_const = 20f;    // Скорость
    private float speed = 20f;          // Текущая скорость
    private float delta = 22f;          // Растояние движения
    private int type;                   // Тип движения
    // Выбрать тип смешения (вверх-вниз, влево-вправо)
    public override void Reset_pozition()
    {
        type = Random.Range(0, 2);
        if (type == 1)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        }
    }
    void Update() 
    {
        if (type == 0)      // Вверх-вниз
        {
            if (transform.position.x > delta)
                speed = -speed_const;
            else if (transform.position.x < -delta)
                speed = speed_const;
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (type == 1) // Влево-вправ
        {
            if (transform.position.y > delta)
                speed = -speed_const;
            else if (transform.position.y < -delta)
                speed = speed_const;
            transform.position = transform.position + new Vector3(0,speed * Time.deltaTime, 0);
        }
    }
}
