using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class HoverPlay : MonoBehaviour
{
    private GameObject vp;
    private VideoPlayer videoPlayer;
    private bool fadein_running;


    private void Update()
    {
        if (vp.activeSelf)
        {
            if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
            {
                StartCoroutine(FadeInPanel(true, vp));
            }
        }
    }

    public void VideoClicked(GameObject videoPanel)
    {
        videoPanel.SetActive(!videoPanel.activeSelf);
        vp = videoPanel;
        videoPlayer = videoPanel.GetComponentInChildren<VideoPlayer>();
        StartCoroutine(FadeInPanel(false, videoPanel));
    }

    public IEnumerator FadeInPanel(bool fadeAway, GameObject videoPanel)
    {
        if(fadeAway)
        {
            for(float i = 1; i >= 0; i -= Time.deltaTime)
            {
                videoPanel.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, i);
                yield return null;
            }
            videoPanel.SetActive(false);
        }
        else
        {
            fadein_running = true; 
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                videoPanel.GetComponentInChildren<RawImage>().color = new Color(1, 1, 1, i);
                yield return null; 
            }

            fadein_running = false;
        }
        Debug.Log("COROUTINE DONE");
    }


}
