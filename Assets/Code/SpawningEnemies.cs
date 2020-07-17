﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningEnemies : MonoBehaviour
{
    public static bool onOff;
    public Enemy enemy;
    public float spawnRate = 1f;
    private Vector3 screenBounds;
    private float toplim, bottlim;
    private float lastSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        toplim = screenBounds.y;
        bottlim = -screenBounds.y;
     
    }

    // Update is called once per frame
    void Update()
    {
        if (onOff == true)
        {
            Vector3 pos = new Vector3(screenBounds.x+5f, Random.Range(bottlim+0.7f, toplim-0.7f), 0);
            if (Time.time - lastSpawn > 1 / spawnRate)
            {
                lastSpawn = Time.time;
                Instantiate(enemy, pos, Quaternion.identity);
            }
        }else{}
    }
}
