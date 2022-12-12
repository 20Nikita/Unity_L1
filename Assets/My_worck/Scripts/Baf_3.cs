using UnityEngine;

public class Baf_3 : Baf
{
    // При столкновении с этим бонусом увеличивается скорость
    public override void Baffer()
    {
        Constants.GetComponent<Constants>().speed *= 1.1f;
    }
}
