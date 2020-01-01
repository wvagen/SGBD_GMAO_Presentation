using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager1 : MonoBehaviour
{
    public Animator myAnim;

    int sceneFrame = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sceneFrame++;
            myAnim.SetInteger("sceneFrame", sceneFrame);

        }
    }
}
