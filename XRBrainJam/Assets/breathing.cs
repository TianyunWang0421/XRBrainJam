using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class breathing : MonoBehaviour
{
    public GameObject breathingSphere;
    public GameObject otherSphere;

    public float breathingVal = 0;
    public int direction;

    public float userVal;
    public Slider breathingSlider;
    public TextMesh text;
    public static bool isComplete;
    //0 is stay
    //1 is inhale
    //2 is exhale

    private float difference;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(breathingExercise());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(direction == 0)
        {
            text.text = "Hold";
        }
        if(direction ==1)
        {
            text.text = "Inhale";
            breathingVal += Time.deltaTime * (1 - breathingVal);
        }
        if(direction ==2)
        {
            text.text = "Exhale";
            breathingVal -= Time.deltaTime * (breathingVal)/6;
        }
        breathingSphere.transform.localScale = new Vector3(breathingVal/4, breathingVal/4, breathingVal/4);

        if(Input.GetKey(KeyCode.W))
        {
            userVal+= Time.deltaTime * (1 - userVal);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            userVal -= Time.deltaTime * (userVal)/6;
        }
        otherSphere.transform.localScale = new Vector3(userVal / 4, userVal / 4, userVal / 4);
        difference = userVal - breathingVal;

        if (difference<0.1f && difference >-0.1f)
        {
            breathingSlider.value += Time.deltaTime/40;
            if (breathingSlider.value>0.99)
            {
                isComplete = true;
            }
        }
        
    }

    IEnumerator breathingExercise()
    {   //inhale
        direction = 1;
        yield return new WaitForSeconds(4f);


        direction = 0;
        yield return new WaitForSeconds(7f);

        direction = 2;
        yield return new WaitForSeconds(8f);

        direction = 0;
        StartCoroutine(breathingExercise());
    }
}
