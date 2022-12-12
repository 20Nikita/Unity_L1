using UnityEngine;

// Вращающееся препядствие
public class Let_2 : Let
{
    private float speed = 20f; // Скорость вращения
    // Слкчайная начальная пазиция вращения
    public override void Reset_pozition()
    { 
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-90, 90))); 
    }
    // Постоянно врящаемся
    void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
