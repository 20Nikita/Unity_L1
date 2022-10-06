using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReceiver : MonoBehaviour, IPointerClickHandler {
    public spawn spawnPoint;
    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("123");
        spawnPoint.stoptSpawn(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
