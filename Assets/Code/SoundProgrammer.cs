﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SoundProgrammer : MonoBehaviour
{
    private int flag;

    public static SoundProgrammer instance;

    public void setFlag(int num)
    {
        flag = num;
        MusicChange();
    }

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
            //We write return to make sure any code is called
            return;
        }
        MusicChange();
    }


    // Update is called once per frame
    
    public void MusicChange()
    {
        Debug.Log(flag);
        switch(flag)
        {
            case 0:
            playMainTheme();
            break;

            case 1:
            playGameTheme();
            break;
        }
    }

    void playMainTheme()
    {

        FindObjectOfType<SoundMng>().PlaySound("MainTheme");
        FindObjectOfType<SoundMng>().Stop("GameTheme");
    }
    void playGameTheme()
    {
        FindObjectOfType<SoundMng>().PlaySound("GameTheme");
        FindObjectOfType<SoundMng>().Stop("MainTheme");
    }

}
