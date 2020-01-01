
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager2 : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveOnToNextScene();
        }
    }
    void moveOnToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
