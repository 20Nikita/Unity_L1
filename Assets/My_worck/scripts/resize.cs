using UnityEngine;

public class resize : MonoBehaviour {
    public float speed = 1f;
    public float maxsie = 2f;
    public float minsize = 0f;
    public bool Mowe = false;
    void Update() {
        if (Mowe){

            transform.localScale = transform.localScale + new Vector3( speed * Time.deltaTime,speed * Time.deltaTime,speed * Time.deltaTime);
            if (transform.localScale.y < minsize || transform.localScale.y > maxsie){
                speed = -speed;
            }
        }
    }
    public void mowe() {
        Mowe = !Mowe;
    }
}
