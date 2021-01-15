using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneHandler : MonoBehaviour
{
    public Animator loadAnimator;

    public void LoadNextScene() {
        loadAnimator.SetTrigger("End");
        float animTime = loadAnimator.GetCurrentAnimatorStateInfo(0).length;
        StartCoroutine(_LoadNextScene(animTime));
    }

    IEnumerator _LoadNextScene(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
