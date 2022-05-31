using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MessageSystem : MonoBehaviour
{
    [SerializeField]
    string[] messages = new string[12];
    string outmessage;
    Queue<char> qmessage = new Queue<char>();
    float waitWordTime = 0.1f;
    float waitLineTime = 0.3f;
    [SerializeField]
    Text t;
    int readMsgCnt = 0;
    int rowMaxSize = 3;
    int rowNowSize = 0;
    bool textWriting=true;
    bool isSpeedup=false;
    float changeSceneWaitTime = 1.5f;
    [SerializeField]
    string nextSceneName;
    bool first=false;


    void Start()
    {
        StartCoroutine(MessageManager());
    }


    IEnumerator output()
    {
        while (qmessage.Count > 0)
        {
            char o = qmessage.Dequeue();
            outmessage += o;
            if (isSpeedup) yield return null;
            else yield return new WaitForSeconds(waitWordTime);
        }
        outmessage += "\n";
        qmessage.Clear();
    }

    IEnumerator WaitEndLine(string msgs)
    {
        foreach (var x in msgs)
        {
            qmessage.Enqueue(x);
        }
        yield return StartCoroutine(output());
        if (isSpeedup) yield return null;
        else yield return new WaitForSeconds(waitLineTime);
        readMsgCnt++;
    }

    IEnumerator MessageManager()
    {
        while (readMsgCnt < messages.Length)
        {            
            rowNowSize++;
            if (rowNowSize <= rowMaxSize)
            {
                yield return StartCoroutine(WaitEndLine(messages[readMsgCnt])); ;
            }
            else
            {
                textWriting = false;
                if (Input.GetMouseButtonDown(0))
                {
                    textWriting = true;
                }

                if (textWriting)
                {
                    MessageReset();
                }
                yield return null;
            }
        }

        yield return new WaitForSeconds(changeSceneWaitTime);
        if (!first) NowScene.SetScene(nextSceneName);
        SceneManager.LoadSceneAsync(nextSceneName);
        first = true;
    }

    void MessageReset()
    {
        outmessage = "";
        rowNowSize = 0;
        isSpeedup = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && textWriting)
        {
            isSpeedup = true;
        }
        t.text = outmessage;   
    }
}
