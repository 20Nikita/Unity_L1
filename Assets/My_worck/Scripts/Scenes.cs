using UnityEngine;
using UnityEngine.SceneManagement;
// Переход между уровнями
public class Scenes : MonoBehaviour
{
    public void NextLevel(int _sceneNumber)
    {
        SceneManager.LoadScene(_sceneNumber);
    }
}
