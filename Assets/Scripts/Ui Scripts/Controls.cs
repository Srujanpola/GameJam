using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controls : MonoBehaviour
{
    [SerializeField]GameObject controlspanel;
    [SerializeField] GameObject soundIcon;
    [SerializeField] Sprite img;
    [SerializeField] Sprite unMute;
    /*[SerializeField] GameObject musicIcon;
    [SerializeField] Sprite unMutemusic;
    [SerializeField] Sprite Mutemusic;*/
    public void PanelActive()
    {
        controlspanel.SetActive(true);
    }

    public void Backbutton()
    {
        controlspanel.SetActive(false);
    }

    public void MuteButton()
    {
        if(soundIcon.GetComponent<Image>().sprite != img)
        {
            soundIcon.GetComponent<Image>().sprite = img;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().music.Stop();
        }
        else
        {
            soundIcon.GetComponent<Image>().sprite = unMute;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().music.Play();
        }

    }


    /* public void MusicButton()
     {
         if (musicIcon.GetComponent<Image>().sprite != unMutemusic)
         {
             musicIcon.GetComponent<Image>().sprite = unMutemusic;
         }
         else
         {
             musicIcon.GetComponent<Image>().sprite = Mutemusic;
         }

     }*/
}
