using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public int indexMusic;
    void Start()
    {
        if(GameObject.Find("ChangeMusic") != null)
        {
            AudioManager.instance.ChangeMusic(indexMusic);
        }
    }
}
