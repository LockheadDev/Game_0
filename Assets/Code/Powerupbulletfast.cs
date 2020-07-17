using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerupbulletfast : MonoBehaviour
{
    public float speed = 3f;

    public float fireRate = 8f;

    public GameObject pickupEffect;
    public float EffectTime = 5f;
    public float colorEffectTime = 0.2f;

    private float baseFireRate; 
    
    void Update()
    {
        GetComponent<Transform>().Translate(Vector3.left*Time.deltaTime*speed);
    }

   void OnTriggerEnter2D(Collider2D other)
   {    
       if(other.CompareTag("Player"))
       {
           StartCoroutine(Pickup(other));
       }
   }

   IEnumerator Pickup(Collider2D player)
   {
       //counter which will enable/disable firrate storage

        //Getting data
        Player plyr = player.GetComponent<Player>();
        SpriteRenderer plyrsr= player.GetComponent<SpriteRenderer>(); 
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        baseFireRate = Weapon.baseFireRate;
        

        //Effects
       StartCoroutine(effectSprite(plyrsr));
       Instantiate(pickupEffect,transform.position,transform.rotation);
       FindObjectOfType<SoundMng>().PlaySound("PlayerPowerUp");

       yield return Apply();

       IEnumerator Apply()
       {

           if(!plyr.isPoweredB)
        {
        plyr.isPoweredB = true;
        plyr.wp.bulletType = "fast";
        plyr.wp.fireRate = fireRate;
        

        yield return new WaitForSeconds(EffectTime);

        //Disabling power up
        plyr.isPoweredB = false;
        plyr.wp.bulletType = "basic";
        plyr.wp.fireRate = baseFireRate;

        //Destroy object
        Destroy(gameObject);
        }
        else if(plyr.isPoweredB)
        {
            Debug.Log("waiting");
            yield return new WaitUntil(()=>plyr.isPoweredB==false);
            Debug.Log("aplying");
            yield return Apply();
        }
       }
   }

   IEnumerator effectSprite(SpriteRenderer sr)
    {
        sr.color = new Color(0,0,100);
         
        yield return new WaitForSeconds(colorEffectTime);
         
        sr.color = new Color(255,255,255);
    }
}
