using UnityEngine;

public class Let_4 : Let
{
    private float delta = 0.3f;
    private float speed = 20f;
    private float speed_const = 20f;
    void Start()
    {
    }
    public override void Reset_pozition()
    { 
        transform.position = transform.position + new Vector3(0, 29.6f, 0);
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
