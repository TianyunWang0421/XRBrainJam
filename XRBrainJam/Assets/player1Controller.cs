using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class player1Controller : MonoBehaviour
{
    public int scrCounter = 0;
    public static GameObject gazingObject;
    public Animator fadeInOutAnimator;
    public Animator waiterAnimator;
    public NavMeshAgent waiterAgent;
    public WaiterActions waiterAction;
    public Transform WaiterWaitArea;
    

    public GameObject[] noisyCrowd;
    public Transform[] noisyCrowdTargetLocations;

    public GameObject menuObject;
    public AudioSource audioSource;
    public AudioSource bell;
    public AudioSource radio;
    public AudioSource noisyGuest;
    public AudioSource petition;
    public AudioSource ambientSound;
    public AudioClip[] interactionClips;
    public PostProcessVolume volume;
    private Vignette vignette;
    private Bloom bloom;
    // Start is called before the first frame update
    void Start()
    {
        
        scrCounter = 1;
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out bloom);
    }

    // Update is called once per frame
    void Update()
    {




        if (scrCounter == 1 && Input.GetKeyDown(KeyCode.A))
        {
            waiterAction.playClip(0);
            fadeInOutAnimator.SetTrigger("fadeIn");
            scrCounter = 2;
        }

        else if (scrCounter == 2 && Input.GetKeyDown(KeyCode.A))
        {
            waiterAgent.SetDestination(WaiterWaitArea.position);
            scrCounter = 3;
        }

        else if (scrCounter == 3 && Input.GetKeyDown(KeyCode.A))
        {
            bell.Play();
            for (int i = 0; i < noisyCrowd.Length; i++)
            {

                noisyCrowd[i].GetComponent<NavMeshAgent>().SetDestination(noisyCrowdTargetLocations[i].position);
            }

            scrCounter = 4;
        }

        else if (scrCounter == 4 && Input.GetKeyDown(KeyCode.A))
        {
            noisyGuest.Play();
            scrCounter = 5;
        }
        else if (scrCounter == 5 && Input.GetKeyDown(KeyCode.A))
        {
            waiterAction.playClip(1);
            scrCounter = 6;
        }

        else if (scrCounter == 6 && Input.GetKeyDown(KeyCode.A))
        {
            radio.volume = 1f;
            scrCounter = 7;
            //RadioVolume
        }
        else if (scrCounter == 7 && Input.GetKey(KeyCode.A))
        {
            petition.Play();
            scrCounter = 8;
            //Petition

        }
        else if (scrCounter == 8 && Input.GetKey(KeyCode.A))
        {
            ambientSound.volume = 1;
            //Your Vision Blurs
            if (vignette.intensity.value < 1)
            {
                vignette.intensity.value = vignette.intensity.value + Time.deltaTime / 5;
                bloom.intensity.value = bloom.intensity.value + Time.deltaTime * 4;
            }
            else
            {
                scrCounter = 9;
            }
        }

        else if (scrCounter == 9 && Input.GetKey(KeyCode.B))
        {

        }
    
    }

}
