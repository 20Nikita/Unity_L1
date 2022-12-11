using UnityEngine;
using UnityEngine.UI;

public class Center_ToItem : MonoBehaviour
{
    public float Value;
    void Update()
    {
        Value = GetComponent<Scrollbar>().value;
    }
}

