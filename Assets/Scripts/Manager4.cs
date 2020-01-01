using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager4 : MonoBehaviour
{
    public Transform devicesParent;

    float scaleSpeed = 4f;
    bool isScaling = false;
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(scaleAllDevices());
    }

    IEnumerator scaleAllDevices()
    {
        for (int i = 0; i < devicesParent.childCount; i++)
        {
            StartCoroutine(scaleUpDevice(devicesParent.GetChild(i).transform));
            while (isScaling)
            {
                yield return new WaitForEndOfFrame();
            }
        }
    }

    IEnumerator scaleUpDevice(Transform device)
    {
        Vector2 myScale = Vector2.zero;
        device.localScale = myScale;
        isScaling = true;
        while (myScale.x < 1)
        {
            myScale.x += Time.deltaTime * scaleSpeed;
            myScale.y += Time.deltaTime * scaleSpeed;
            device.localScale = myScale;
            yield return new WaitForEndOfFrame();
        }
        isScaling = false;
    }

}
