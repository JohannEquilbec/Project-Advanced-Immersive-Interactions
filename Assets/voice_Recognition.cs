using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Text;

public class voice_Recognition : MonoBehaviour

{
    [SerializeField]
    private string[] List_Keywords;

    private KeywordRecognizer m_Recognizer;

    public Material Blue;
    public Material Red;
    public Material Black;
    public Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        List_Keywords = new string[3];
        List_Keywords[0] = "Blue";
        List_Keywords[1] = "Red";
        List_Keywords[2] = "Black";

        m_Recognizer = new KeywordRecognizer(List_Keywords);
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;
        m_Recognizer.Start();

    }

    // Update is called once per frame
    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        if (args.text == List_Keywords[0])
        {
            //change brush tip
             collider.GetComponent<Renderer>().material = Blue;
            //change line material
            collider.SendMessageUpwards("SetLineMaterial", Blue, SendMessageOptions.DontRequireReceiver);
            Debug.Log("you have said blue");
        }
    }
}
