using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class changeColor : MonoBehaviour
{
    public Material newMaterial;
    public AudioClip splash;

    private void OnTriggerEnter(Collider other)
    {
        //change brush tip
        other.GetComponent<Renderer>().material = newMaterial;
        //change line material
        other.SendMessageUpwards("SetLineMaterial", newMaterial, SendMessageOptions.DontRequireReceiver);
        MakeSound(splash);
    }

    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }
}
