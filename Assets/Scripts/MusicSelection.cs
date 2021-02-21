using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelection : MonoBehaviour
{
    //public AudioSource biscuit;
    public AudioSource clair_de_lune;
    public AudioSource previous;

    public bool isBiscuit;
    public bool isClair;

    public bool isClairPlaying;

    Dropdown musicSelector;

    // Start is called before the first frame update
    void Start()
    {
        //biscuit = GetComponent<AudioSource>();
        clair_de_lune = GetComponent<AudioSource>();

        musicSelector = GetComponent<Dropdown>();
        musicSelector.onValueChanged.AddListener(delegate {
            MusicSelectorValueChanged(musicSelector);
        });

        //biscuit.Play();
        //clair_de_lune.Stop();
        //previous = biscuit;
    }

    // Update is called once per frame
    void Update()
    {
        SetRightMusic();
        //biscuit.Stop();
    }

    public void SetRightMusic()
    {
        if (isBiscuit == true)
        {
            //clair_de_lune.Stop();
            //biscuit.Play();
        }
        else if (isClair && isClairPlaying == false)
        {
            isClairPlaying = true;
            //biscuit.Stop();
            clair_de_lune.Play();
        }
    }

        public void MusicSelectorValueChanged(Dropdown change)
    {
        if (change.value == 0) // Biscuit
        {
            isBiscuit = true;
            isClair = false;
            /*
            if(previous != biscuit)
            {
                //previous.Stop();
                //clair_de_lune.Stop();
                biscuit.Play();
                previous = biscuit;
            }
            */
        }
        else if (change.value == 1) // Clair de lune
        {
            isBiscuit = false;
            isClair = true;
            /*
            if (previous != clair_de_lune)
            {
                //previous.Stop();
                //biscuit.Stop();
                clair_de_lune.Play();
                previous = clair_de_lune;
            }
            */
        }
    }
}
