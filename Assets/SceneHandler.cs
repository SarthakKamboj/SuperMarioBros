using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{

    public void LoadNextScene() {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
