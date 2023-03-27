using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class memoryPlayer : MonoBehaviour
{
    public GameObject myVideoObject;
    public Slider Myslider;
    public static bool isCompleted;
    // Start is called before the first frame update
    void Start()
    {
        myVideoObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerraycast.hitObject == this.gameObject)
        {
            myVideoObject.SetActive(true);
            Myslider.value += Time.deltaTime / 15;  
            
            if(Myslider.value>=0.98)
            {
                isCompleted = true;
            }
                }
        else
        {
            myVideoObject.SetActive(false);
        }
    }
}
