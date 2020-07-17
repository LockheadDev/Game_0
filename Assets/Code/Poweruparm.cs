using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poweruparm : MonoBehaviour
{
    public float speed = 3f;

    public GameObject pickupEffect;
    public float colorEffectTime = 0.2f;

void Update()
    {
        GetComponent<Transform>().Translate(Vector3.left*Time.deltaTime*speed);
    }
    
   void OnTriggerEnter2D(Collider2D other)
   {    
       if(other.CompareTag("Player"))
       {
           Pickup(other);
       }
   }

   void Pickup(Collider2D player)
   {
      
        Player plyr = player.GetComponent<Player>();
        SpriteRenderer plyrsr =player.GetComponent<SpriteRenderer>();

        if(plyr.getHealth() == 3 && plyr.getArmor() < 2)
        {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        StartCoroutine(effectSprite(plyrsr));
        FindObjectOfType<SoundMng>().PlaySound("PlayerArmor");
        plyr.GiveArmor(1);
        Instantiate(pickupEffect,transform.position,transform.rotation);
        }
       
   }
   

   IEnumerator effectSprite(SpriteRenderer sr)
    {
        sr.color = new Color(100,100,0);
         
        yield return new WaitForSeconds(colorEffectTime);
         
        sr.color = new Color(255,255,255);
        Destroy(gameObject);
    }
}
