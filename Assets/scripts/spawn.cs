using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject objToSpawn;
    public bool Spawn = false;
    public float timeSpawn = 1f;
    float time = 0;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (Spawn & time > timeSpawn) {
            time = 0;
            Instantiate(objToSpawn, spawnPoint.transform.position, Quaternion.identity);
        }
        
    }
    public void startSpawn() {
        Spawn = true;
    }
    public void stoptSpawn() {
        Spawn = false;
    }
}
