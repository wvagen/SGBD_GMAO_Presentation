﻿
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager3 : MonoBehaviour
{
    public Animator myAnim;
    int frameCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            frameCount++;
            myAnim.SetInteger("frameCount", frameCount);
            if (frameCount >= 3) moveOnToNextScene();
        }
    }

    void moveOnToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void DropAngryFace()
    {
        myAnim.Play("AngryFaceDrop");
    }
    public void DropConfusedFace()
    {
        myAnim.Play("ConfusedFaceDrop");
    }
}
