using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.DpadUp) == true)
        {
            var player = GetComponentInChildren<OVRPlayerController>();
            player.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1);
            player.enabled = true;
        }
    }
}
