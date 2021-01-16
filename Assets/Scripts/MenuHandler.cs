using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{

    public void RegisterEvent(string name) {
        switch (name) {
            case "One Player":
                Debug.Log("one player");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;
            case "Quit":
                Debug.Log("quit");
                Application.Quit();
                break;
        }
    }

}
