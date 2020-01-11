using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager6 : MonoBehaviour
{
    public Image line;
    public string[] serverWordsToBeDisplayed;
    public string[] clientWordsToBeDisplayed;
    public Text serverWordDisplayed,clientWordDisplayed;
    public Animator myAnim;

    int serverWordsIndex = 0, clientWordsIndex;
    public static int clickCount = 0;
    bool foo = true,isServer;
    const float lineFillSpeed = 4f;

    void Start()
    {
        clickCounterManager();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickCounterManager();
            
        }
    }

    public void clickCounterManager()
    {
        clickCount++;
        
        switch (clickCount)
        {
            case 1: makeTransaction(); break;
            case 3: makeTransaction(); break;
            case 5: makeTransaction(); break;
            case 6: makeTransaction(); break;
            case 7: makeTransaction(); break;
            case 8: makeTransaction(); break;
            case 9: makeTransaction(); break;
            case 10: makeTransaction(); break;
            case 12: moveOnToNextScene(); break;

        }

        myAnim.SetInteger("clickCount", clickCount);
    }

    void moveOnToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void makeTransaction()
    {
        StartCoroutine(enableAndDisableLine(foo));
        foo = !foo;
    }


    IEnumerator displayWordByWord(Text wordDisplayed, int wordsIndex, bool isServer, string[] WordsToBeDisplayed)
    {
        if (wordsIndex < WordsToBeDisplayed.Length)
        {
            string wordToBeDisplayed = WordsToBeDisplayed[wordsIndex];
            wordDisplayed.text = "";
            int i = 0;
            while (i < wordToBeDisplayed.Length)
            {
                wordDisplayed.text += wordToBeDisplayed[i];
                yield return new WaitForSeconds(.02f);
                i++;
            }
            wordsIndex++;
            if (isServer)
            {
                serverWordsIndex = wordsIndex;
            }
            else clientWordsIndex = wordsIndex;

            yield return new WaitForSeconds(0.5f);
            if (isServer)
            {
                wordDisplayed.text = "";
                if (clickCount == 7 || clickCount == 9) wordDisplayed.text = "Fixing ...";

                if (clickCount == 9)
                {
                    yield return new WaitForSeconds(2);
                    wordDisplayed.text = "Done :)";
                }
            }

            
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

        if (isClientServer) StartCoroutine(displayWordByWord(serverWordDisplayed, serverWordsIndex, true, serverWordsToBeDisplayed));
        else StartCoroutine(displayWordByWord(clientWordDisplayed, clientWordsIndex, false, clientWordsToBeDisplayed));
        line.fillOrigin = isClientServer ? 0 : 1;

        while (line.fillAmount > 0)
        {
            line.fillAmount -= Time.deltaTime * lineFillSpeed;
            yield return new WaitForEndOfFrame();
        }

    }
}
