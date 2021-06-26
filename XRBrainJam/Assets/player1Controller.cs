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
    public Transform WaiterWaitArea;
    

    public GameObject[] noisyCrowd;
    public Transform[] noisyCrowdTargetLocations;

    public GameObject menuObject;




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
        if (Input.GetKeyDown(KeyCode.A))
        {
            fadeInOutAnimator.SetTrigger("fadeIn");
            scrCounter = 2;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            waiterAgent.SetDestination(WaiterWaitArea.position);
            scrCounter = 3;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            for(int i=0; i<=noisyCrowd.Length; i++)
            {
                noisyCrowd[i].GetComponent<NavMeshAgent>().SetDestination(noisyCrowdTargetLocations[i].position);
                
            }

            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            //RadioVolume

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            //PetitionSigning
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            //TryToCompleteMenu Ordering
           
        }

        if (Input.GetKey(KeyCode.H))
        {
            //Your Vision Blurs
            if (vignette.intensity.value<1)
            {
                vignette.intensity.value = vignette.intensity.value + Time.deltaTime / 4;
                bloom.intensity.value = bloom.intensity.value + Time.deltaTime *5;
            }
                

        }
    }
}
