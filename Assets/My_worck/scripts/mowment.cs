using UnityEngine;

public class mowment : MonoBehaviour {
    public float speed = 2f;
    public bool Mowe = false;
    void Update()
    {
        
        if (Mowe){
            transform.position = transform.position + new Vector3( 0,0,speed * Time.deltaTime);
            if (transform.position.z < 0 || transform.position.z > 10){
                speed = -speed;
            }
        }
    }
    public void mowe() {
        Mowe = !Mowe;
    }
}
