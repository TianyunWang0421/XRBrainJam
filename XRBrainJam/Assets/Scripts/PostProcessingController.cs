using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PostProcessingController : MonoBehaviour
{
    public PostProcessVolume volume;
    private Vignette vignette;
   
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out vignette);
    }

    // Update is called once per frame
    void Update()
    {
        vignette.intensity.value = slider.value; 
    }
}
