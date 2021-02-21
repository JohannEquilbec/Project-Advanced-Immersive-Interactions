using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSelection : MonoBehaviour
{
    public AudioSource biscuit;
    public AudioSource clair_de_lune;
    public AudioSource previous; // Used to know which song is currently playing, so it doesn't restart from the beginning

    // Boolean to know what sound to play
    public bool isBiscuit;
    public bool isClair;

    Dropdown musicSelector;

    // Start is called before the first frame update
    void Start()
    {
        biscuit = GetComponent<AudioSource>();
        clair_de_lune = GetComponent<AudioSource>();

        musicSelector = GetComponent<Dropdown>();
        musicSelector.onValueChanged.AddListener(delegate {
            MusicSelectorValueChanged(musicSelector);
        });

        // By default, the "chill" song is playing
        biscuit.Play();
        
        isBiscuit = true;
        isClair = false;

        previous = biscuit;
    }

    // Update is called once per frame
    void Update()
    {
        SetRightMusic();
    }

    public void SetRightMusic()
    {
        if (isBiscuit == true && previous != biscuit)
        {
            clair_de_lune.Stop();
            biscuit.Play();
            previous = biscuit;
        }
        else if (isClair == true && previous != clair_de_lune)
        {
            biscuit.Stop();
            clair_de_lune.Play();
            previous = clair_de_lune;
        }
    }

        // Clicking on the song changes which song is currently playing
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
