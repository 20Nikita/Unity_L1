using UnityEngine;

public class Baf_1 : Baf
{
    // При столкновении с этим бонусом увеличивается счет на 1
    public override void Baffer()
    {
        Constants.GetComponent<Constants>().caunt += 1;
    }
}
