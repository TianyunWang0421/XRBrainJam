using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timertext : MonoBehaviour
{
    private float currentTime = 0f;
    private float startingTime = 19f;
    [SerializeField] Text countdown;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;


   
            countdown.text = "Inhale through your nose for " + (4 - currentTime).ToString("0");
            if (currentTime >= 4)
            { countdown.text = "Hold for " + (11 - currentTime).ToString("0");
                if(currentTime >= 11)
                    countdown.text = "Exhale through your mouth for " + (19 - currentTime).ToString("0");
            }
        

  
            
        if (currentTime >= 19)
            currentTime = 0; 


           
    }
}
