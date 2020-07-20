using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    private int shipID;
    public GameObject[] ships;
    // Start is called before the first frame update
    void Start()
    {
        shipID = PlayerPrefs.GetInt("ship",0);
        Debug.Log(shipID);
        Vector3 pos = new Vector3(0, 0, 0);
        switch(shipID)
        {
            case 0:
            Instantiate(ships[0],pos,Quaternion.identity);
            break;
            case 1:
            Instantiate(ships[1],pos,Quaternion.identity);
            break;

        }
    }

    
}
