using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager1 : MonoBehaviour
{
    public Animator myAnim;

    int sceneFrame = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sceneFrame++;
            myAnim.SetInteger("sceneFrame", sceneFrame);

        }
    }

    public void moveOnToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
