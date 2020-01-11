using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerDotsLights : MonoBehaviour
{
    public Color idleColor, activeColor;

    List<Image> myDots = new List<Image>();

    const int lightsCount = 15;

    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
			{
                myDots.Add(transform.GetChild(i).GetComponent<Image>());
                transform.GetChild(i).GetComponent<Image>().color = idleColor;
			}
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (Manager6.clickCount)
            {
                case 1: StartCoroutine(lightSomeDots()); break;
                case 3: StartCoroutine(lightSomeDots()); break;
                case 5: StartCoroutine(lightSomeDots()); break;
                case 7: StartCoroutine(lightSomeDots()); break;
                case 9: StartCoroutine(lightSomeDots()); break;
            }
        }
    }

    IEnumerator lightSomeDots()
    {
        List<Image> activatedDots = new List<Image>(); 
        int randomIndex;
        for (int i = 0; i < lightsCount; i++)
        {
            randomIndex = Random.Range(0, myDots.Count);
            myDots[randomIndex].color = activeColor;
            activatedDots.Add(myDots[randomIndex]);
            
        }

        foreach (Image i in activatedDots)
        {
            i.color = idleColor;
            yield return new WaitForSeconds(Random.Range(0, 0.1f)); 
        }


    }

    

}
