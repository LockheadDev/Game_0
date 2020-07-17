﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public string bulletType = "basic";
    public GameObject bulletPrefabBasic;
    public GameObject bulletPrefabPower;
    public GameObject bulletPrefabFast;

    //shoot types normal and triple available.
    public string shoottype = "normal";
    
    public static float baseFireRate;

    public float fireRate = 5f;

    private float lastFired;
     void Awake()
    {
        baseFireRate = fireRate;
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        //Fire rate shooting (automatic)
        if(Input.GetKey(KeyCode.Space))
        {
            if (Time.time - lastFired > 1 / fireRate)
            {
                lastFired = Time.time;
                Shoot(bulletType);
            }

        }
    }
    
    void Shoot(string blltype)
    {
        switch (blltype)
        {
            case "basic":
            FindObjectOfType<SoundMng>().PlaySound("Shootbasic");
            if(shoottype=="normal"){
                Instantiate(bulletPrefabBasic,firePoint.position,firePoint.rotation);
            }
            else if(shoottype=="triple")
            {
                TripleShoot(bulletPrefabBasic);
            }
                break;
                
            case "amped":
                FindObjectOfType<SoundMng>().PlaySound("Shootamped");

                if(shoottype=="normal"){
                Instantiate(bulletPrefabPower,firePoint.position,firePoint.rotation);
                }
                else if(shoottype=="triple")
                {
                TripleShoot(bulletPrefabPower);
                }

                break;

            case "fast":
                FindObjectOfType<SoundMng>().PlaySound("Shoottriple");
                if(shoottype=="normal"){
                Instantiate(bulletPrefabFast,firePoint.position,firePoint.rotation);
                }
                else if(shoottype=="triple")
                {
                TripleShoot(bulletPrefabFast);
                }
                break;

        }


            
        
    }
    void TripleShoot(GameObject bullet)
    {
        for(int i=0; i<3;i++ )
        {
        GameObject bllt1 = bullet;
        switch(i)
        {
            case 0:
                bllt1.GetComponent<Bullet>().bulletdirection= "default";
            break;

            case 1:
                bllt1.GetComponent<Bullet>().bulletdirection= "diagonaltop";
            break;

            case 2:
                bllt1.GetComponent<Bullet>().bulletdirection= "diagonalbot";
            break;
        }
        Instantiate(bllt1,firePoint.position,firePoint.rotation);
        bllt1.GetComponent<Bullet>().bulletdirection= "default";
        }
         
        
    }
}
