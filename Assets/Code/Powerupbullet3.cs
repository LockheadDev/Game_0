using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerupbullet3 : MonoBehaviour
{
    public float speed = 3f;

    public GameObject pickupEffect;
    public float EffectTime = 5f;
    public float colorEffectTime = 0.2f;
    
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
        

        //Effects
       StartCoroutine(effectSprite(plyrsr));
       Instantiate(pickupEffect,transform.position,transform.rotation);
       FindObjectOfType<SoundMng>().PlaySound("PlayerArmor");
       speed =0f;

       yield return Apply();

       IEnumerator Apply()
       {

           if(!plyr.isPoweredA)
        {
        plyr.isPoweredA = true;
        plyr.wp.shoottype = "triple";
        

        yield return new WaitForSeconds(EffectTime);

        //Disabling power up
        plyr.isPoweredA = false;
        plyr.wp.shoottype = "normal";

        //Destroy object
        Destroy(gameObject);
        }
        else if(plyr.isPoweredA)
        {
            Debug.Log("waiting");
            yield return new WaitUntil(()=>plyr.isPoweredA==false);
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
