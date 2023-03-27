using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerraycast : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource radio;
    public GameObject reticle;
    public static GameObject hitObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        Debug.DrawRay(this.gameObject.transform.position, this.gameObject.transform.rotation * Vector3.forward * 10, Color.yellow);
        RaycastHit hit;
        if(Physics.Raycast(this.gameObject.transform.position, this.gameObject.transform.rotation * Vector3.forward, out hit)){
            //Debug.Log(hit.transform.name);
            hitObject = hit.transform.gameObject;
            reticle.transform.position = hit.point;
            //if (hit.transform.name == "RetroElectronic_Boombox_prefab" && gamevariables.radioStop == false){
            //    radio.Stop();
            //    gamevariables.noiseLevel = gamevariables.noiseLevel - 50;
            //    gamevariables.radioStop = true;
            //    Debug.Log("Radio Stopped " + gamevariables.noiseLevel + " " + gamevariables.radioStop );
            //}
        }
    }
}
