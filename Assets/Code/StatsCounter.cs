using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatsCounter : MonoBehaviour
{
    public TextMeshProUGUI enemiesKO;

    public TextMeshProUGUI timesDead;
    
    public TextMeshProUGUI highScore;

    
    // Start is called before the first frame update
    void Start()
    {
        highScore.text =  PlayerPrefs.GetInt("HighScore",0).ToString();
        enemiesKO.text = PlayerPrefs.GetInt("enemiesKO",0).ToString();
        timesDead.text = PlayerPrefs.GetInt("timesDead",0).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesKO.text = PlayerPrefs.GetInt("enemiesKO").ToString();
        timesDead.text = PlayerPrefs.GetInt("timesDead").ToString();
        highScore.text = PlayerPrefs.GetInt("HighScore").ToString();


    }
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
        highScore.text = "0";
        enemiesKO.text = "0";
        timesDead.text = "0";
    }
}
