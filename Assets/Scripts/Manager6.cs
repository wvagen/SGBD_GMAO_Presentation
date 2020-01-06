using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager6 : MonoBehaviour
{
    public Image line;
    public string[] serverWordsToBeDisplayed;
    public Text wordDisplayed;

    int wordsIndex = 0;
    bool foo = true;
    const float lineFillSpeed = 4f;
    void Start()
    {
        line.fillAmount = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) makeTransaction();
    }

    public void makeTransaction()
    {
        StartCoroutine(enableAndDisableLine(foo));
        foo = !foo;
    }


    IEnumerator displayWordByWord()
    {
        if (wordsIndex < serverWordsToBeDisplayed.Length)
        {
            string wordToBeDisplayed = serverWordsToBeDisplayed[wordsIndex];
            wordDisplayed.text = "";
            int i = 0;
            while (i < wordToBeDisplayed.Length)
            {
                wordDisplayed.text += wordToBeDisplayed[i];
                yield return new WaitForSeconds(.02f);
                i++;
            }
            wordsIndex++;

            yield return new WaitForSeconds(0.5f);
            wordDisplayed.text = "";
        }
    }

    IEnumerator enableAndDisableLine(bool isClientServer)
    {
        line.fillOrigin = isClientServer ? 1 : 0;
        while (line.fillAmount < 1)
        {
            line.fillAmount += Time.deltaTime * lineFillSpeed;
            yield return new WaitForEndOfFrame();
        }

        if (isClientServer) StartCoroutine(displayWordByWord());
        line.fillOrigin = isClientServer ? 0 : 1;

        while (line.fillAmount > 0)
        {
            line.fillAmount -= Time.deltaTime * lineFillSpeed;
            yield return new WaitForEndOfFrame();
        }

    }
}
