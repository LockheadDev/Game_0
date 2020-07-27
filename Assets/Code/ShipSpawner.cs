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
        Vector3 pos = new Vector3(0, 0, 0);
         Instantiate(ships[shipID],pos,Quaternion.identity);
    }

    
}
