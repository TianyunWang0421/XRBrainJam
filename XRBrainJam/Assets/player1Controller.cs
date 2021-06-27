using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class player1Controller : MonoBehaviour
{
    public float scrCounter = 0;
    public static GameObject gazingObject;
    public Animator fadeInOutAnimator;
    public Animator waiterAnimator;
    public NavMeshAgent waiterAgent;
    public WaiterActions waiterAction;
    public Transform WaiterWaitArea;
    public Transform WaiterApproachLocation;

    public GameObject[] noisyCrowd;
    public Transform[] noisyCrowdTargetLocations;

    public GameObject menuObject;
    public GameObject focusObject;
    public GameObject memoryObject;
    public GameObject breathingObject;

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
    public GameObject[] speechIcons;

    public AudioSource heartBeat;
    public AudioClip[] heartSounds;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject speechIcon in speechIcons)
        {
            speechIcon.SetActive(false);
        }
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
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            speechIcons[1].SetActive(true);
            fadeInOutAnimator.SetTrigger("fadeIn");
            scrCounter = 2;
        }

        else if (scrCounter == 2 && Input.GetKeyDown(KeyCode.A))
        {
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            waiterAgent.SetDestination(WaiterWaitArea.position);
            waiterAgent.stoppingDistance = 0 ;
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
            heartBeat.clip = heartSounds[0];
            heartBeat.Play();
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            speechIcons[2].SetActive(true);
            scrCounter = 5;
        }
        else if (scrCounter == 5 && Input.GetKeyDown(KeyCode.A))
        {
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            speechIcons[1].SetActive(true);
            waiterAction.playClip(1);
            scrCounter = 6;
        }

        else if (scrCounter == 6 && Input.GetKeyDown(KeyCode.A))
        {
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            radio.volume = 0.6f;
            scrCounter = 7;
            //RadioVolume
        }
        else if (scrCounter == 7 && Input.GetKeyDown(KeyCode.A))
        {
            petition.Play();
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            speechIcons[3].SetActive(true);
            //Petition

            scrCounter = 8;
        }
        else if (scrCounter == 8 && Input.GetKeyDown(KeyCode.A))
        {
            heartBeat.clip = heartSounds[1];
            heartBeat.Play();
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            waiterAgent.SetDestination(WaiterApproachLocation.position);
            waiterAgent.stoppingDistance = 0;
            scrCounter = 9;

        }
        else if (scrCounter == 9 && Input.GetKeyDown(KeyCode.A))
        {
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            speechIcons[1].SetActive(true);
            waiterAction.playClip(2);
            menuObject.GetComponent<myInteraction>().activateMyItem();
            scrCounter = 10;

        }
        else if (scrCounter == 10 && Input.GetKey(KeyCode.A))
        {
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            
            ambientSound.volume = 1;
            //Your Vision Blurs
            if (vignette.intensity.value < 1)
            {
                vignette.intensity.value = vignette.intensity.value + Time.deltaTime / 5;
                bloom.intensity.value = bloom.intensity.value + Time.deltaTime * 4;
            }
            else
            {
                scrCounter =11;
                heartBeat.clip = heartSounds[2];
                heartBeat.Play();
            }
        }

        else if (scrCounter == 11 && Input.GetKeyDown(KeyCode.B))
        {
            audioSource.clip = interactionClips[0];
            audioSource.PlayOneShot(interactionClips[0]);
            scrCounter = 12;
        }

        else if (scrCounter == 12 && Input.GetKeyDown(KeyCode.B))
        {
            if(!audioSource.isPlaying)
            {
                audioSource.clip = interactionClips[1];
                foreach (GameObject speechIcon in speechIcons)
                {
                    speechIcon.SetActive(false);
                }
                speechIcons[4].SetActive(true);
                audioSource.PlayOneShot(interactionClips[1]);
                scrCounter = 13;
            }
            
        }

        else if (scrCounter == 13 && Input.GetKeyDown(KeyCode.B))
        {
            if (!audioSource.isPlaying)
            {
                foreach (GameObject speechIcon in speechIcons)
                {
                    speechIcon.SetActive(false);
                }
                audioSource.clip = interactionClips[2];
                audioSource.PlayOneShot(interactionClips[2]);
                scrCounter = 14;
            }

        }

        else if (scrCounter == 14 && Input.GetKeyDown(KeyCode.B))
        {
            if (!audioSource.isPlaying)
            {
                foreach (GameObject speechIcon in speechIcons)
                {
                    speechIcon.SetActive(false);
                }
                speechIcons[0].SetActive(true);
                radio.volume = 0.2f;
                audioSource.clip = interactionClips[3];
                audioSource.PlayOneShot(interactionClips[3]);
                breathingObject.SetActive(true);
                scrCounter = 15;
            }

        }
        else if (scrCounter == 15 && breathing.isComplete)
        {
            if (!audioSource.isPlaying)
            {
                breathingObject.SetActive(false);
                
                vignette.intensity.value = 0.75f;
                bloom.intensity.value = 20;

                heartBeat.clip = heartSounds[1];
                heartBeat.Play();

                scrCounter = 15.5f;
            }

        }
                            else if (scrCounter == 15.5f && Input.GetKeyDown(KeyCode.B))
                            {
                                if (!audioSource.isPlaying)
                                {
                                    foreach (GameObject speechIcon in speechIcons)
                                    {
                                        speechIcon.SetActive(false);
                                    }
                                    speechIcons[0].SetActive(true);
                                   
                                    audioSource.clip = interactionClips[4];
                                    audioSource.PlayOneShot(interactionClips[4]);
                                    breathingObject.SetActive(false);
                                    memoryObject.SetActive(true);
                                    scrCounter = 16;
                                }

                            }



        else if (scrCounter == 16 && memoryPlayer.isCompleted)
        {
            if (!audioSource.isPlaying)
            {
                memoryObject.SetActive(false);
                
                vignette.intensity.value = 0.4f;
                bloom.intensity.value = 15;
                heartBeat.clip = heartSounds[0];
                heartBeat.Play();

                scrCounter = 16.5f;
            }

        }
                        else if (scrCounter == 16.5 && Input.GetKeyDown(KeyCode.B))
                        {
                            if (!audioSource.isPlaying)
                            {
                                
                                foreach (GameObject speechIcon in speechIcons)
                                {
                                    speechIcon.SetActive(false);
                                }
                                speechIcons[0].SetActive(true);
                                
                                audioSource.clip = interactionClips[5];
                                audioSource.PlayOneShot(interactionClips[5]);
                                focusObject.GetComponent<myInteraction>().activateMyItem();
                                scrCounter = 17f;
                            }

                        }
        else if (scrCounter == 17 && focusObject.GetComponent<myInteraction>().isCompleted)
        {
            if (!audioSource.isPlaying)
            {
                foreach (GameObject speechIcon in speechIcons)
                {
                    speechIcon.SetActive(false);
                }
                    
                vignette.intensity.value = 0f;
                bloom.intensity.value = 0;
                heartBeat.Stop();

                scrCounter = 18;
            }

        }
        else if (scrCounter == 18 && Input.GetKeyDown(KeyCode.B))
        {
            
            audioSource.PlayOneShot(interactionClips[6]);
            scrCounter = 19;

        }

        else if (scrCounter == 19 && Input.GetKeyDown(KeyCode.B))
        {
            foreach (GameObject speechIcon in speechIcons)
            {
                speechIcon.SetActive(false);
            }
            speechIcons[1].SetActive(true);
            if (!audioSource.isPlaying)
            {
                waiterAction.playClip(2);
                scrCounter = 20;
            }

        }
        else if (scrCounter == 20 && Input.GetKeyDown(KeyCode.B))
        {
            if (!audioSource.isPlaying)
            {
                foreach (GameObject speechIcon in speechIcons)
                {
                    speechIcon.SetActive(false);
                }
                speechIcons[0].SetActive(true);
                audioSource.PlayOneShot(interactionClips[7]);
                scrCounter = 21;
            }

        }
    }

}
