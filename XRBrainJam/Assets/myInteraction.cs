using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myInteraction : MonoBehaviour
{
    public bool isActive;
    public bool isCompleted;
    public float timeToComplete = 5f;
    private float currentTimer;
    public GameObject canvasUI;
    public Image fillImage;
    public bool isFirstMenu;
    // Start is called before the first frame update
    void Start()
    {
        canvasUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            if(playerraycast.hitObject == this.gameObject)
            {
               
                if(!isFirstMenu)
                {
                    fillImage.fillAmount = fillImage.fillAmount + Time.deltaTime * (1 - fillImage.fillAmount);
                    if (fillImage.fillAmount >= 0.96f)
                    {
                        isCompleted = true;
                        isActive = false;
                        canvasUI.SetActive(false);
                    }
                    currentTimer = currentTimer + Time.deltaTime;
                }
                else
                {
                    fillImage.fillAmount = fillImage.fillAmount + Time.deltaTime * (0.5f - fillImage.fillAmount);
                    if (fillImage.fillAmount >= 0.48f)
                    {
                        isCompleted = true;
                        isActive = false;
                        canvasUI.SetActive(false);
                    }
                    currentTimer = currentTimer + Time.deltaTime;
                }
                
                
            }
        }
    }

    public void activateMyItem()
    {
        canvasUI.SetActive(true);
        isActive = true;
    }
}



// start screen, panic attack, memories, player 2, raycast - 
// Change character to a female