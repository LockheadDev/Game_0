using UnityEngine;
using System.Collections;

public class csDestroyEffect : MonoBehaviour {
	
    public float time = 5.0F;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
        
    }
}