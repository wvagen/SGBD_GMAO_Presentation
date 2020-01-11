using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager7 : MonoBehaviour
{
    public Camera cam;

    bool isHolding = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) onPointerDown();
        if (Input.GetMouseButtonUp(1)) onPointerUp();

        if (isHolding)
        {
            Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos /= 2;
            cam.transform.position = mousePos;
        }
        if (Input.GetMouseButtonDown(0))
        {
            moveOnToNextScene();

        }

    }
    void moveOnToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void onPointerDown()
    {
        isHolding = true;
        cam.orthographicSize = 3;
    }

    public void onPointerUp()
    {
        isHolding = false;
        cam.orthographicSize = 5;
        cam.transform.position = Vector2.zero;
    }
}
