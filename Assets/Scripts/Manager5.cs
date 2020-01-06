﻿
using UnityEngine;
using UnityEngine.SceneManagement;


public class Manager5 : MonoBehaviour
{
    public Animator myAnim;

    int frameCount = 0;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            frameCount++;
            myAnim.SetInteger("frameCount", frameCount);
        }
    }
    public void moveOnToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}