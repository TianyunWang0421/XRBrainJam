using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterActions : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip[] waiterClips;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playClip(int clipNo)
    {
        audioSrc.PlayOneShot(waiterClips[clipNo]);
    }
}
