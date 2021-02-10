using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voice_Recognition : MonoBehaviour
{
    [SerializeField]
    private string[] m_Keywords;

    private KeywordRecognizer m_Recognizer;

    void Start()
    {
        m_Keywords = new string[3];
        m_Keywords[1] = "Lofi";
        m_Keywords[2] = "Rock";
        m_Keywords[3] = "Classical";

        m_Recognizer = new KeywordRecognizer(m_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
      if( args.text == m_Keywords[1]) {
            Debug.Log("Lofi");
        }
      else if (args.text == m_Keywords[2])
        {
            Debug.Log("Rock");
        }
      else if (args.text == m_Keywords[3])
        {
            Debug.Log("Classical");
        }
    }
}
