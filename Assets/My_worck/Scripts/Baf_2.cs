using UnityEngine;

public class Baf_2 : Baf
{
    // При столкновении с этим бонусом уменьшается скорость
    public override void Baffer()
    {
        Constants.GetComponent<Constants>().speed /= 1.1f;
    }
}
