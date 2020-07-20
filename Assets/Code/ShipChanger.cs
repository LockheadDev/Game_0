using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipChanger : MonoBehaviour
{
    private int shipID;
    public GameObject marker;
    public Sprite[] representations;
    public Image show;
    public Sprite locked;
    public Text lck;
    public Text infoUnlock;

    public int[] unlocks;
    



    void Start()
    {
        
        shipID=PlayerPrefs.GetInt("ship",0);
        show.sprite =representations[shipID];

    }

    void Update()
    {
        //Sprite selected
        if(shipID==PlayerPrefs.GetInt("ship"))
        {
            marker.SetActive(true);
        }
        else
        {
            marker.SetActive(false);
        }
        


        //Sprite locked
        if(Unlocked(shipID))
        {
        show.sprite =representations[shipID];
        lck.text = "";
        infoUnlock.text = "";
        }
        else
        {
        show.sprite = locked;
        lck.text = "locked";
        infoUnlock.text = "Unlock at: " + unlocks[shipID];
        }
    }

    public void plusID()
    {
        Debug.Log(shipID);
        if(shipID>=0 && shipID<representations.Length-1)
        {
           
        shipID++;
           
        }
    }

    public void lessID()
    {
        Debug.Log(shipID);
        if(shipID>0 && shipID<representations.Length)
        {
        shipID--;
        }
    }

    bool Unlocked(int ship)
    {
        switch(ship)
        {
            case 0:
            return true;

            case 1:
            if(PlayerPrefs.GetInt("HighScore")>=unlocks[ship])
            {
                return true;
            }
            else
            {
                return false;
            }

            case 2:
            if(PlayerPrefs.GetInt("HighScore")>=unlocks[ship])
            {
                return true;
            }
            else
            {
                return false;
            }
            case 3:
            if(PlayerPrefs.GetInt("HighScore")>=unlocks[ship])
            {
                return true;
            }
            else
            {
                return false;
            }
            case 4:
            if(PlayerPrefs.GetInt("HighScore")>=unlocks[ship])
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        return false;

    }

    public void Select()
    {
        if(Unlocked(shipID))
        {
        PlayerPrefs.SetInt("ship",shipID);
        }
        else
        {
            Debug.Log("Not unlocked yet");
        }
    }

    

    
}
