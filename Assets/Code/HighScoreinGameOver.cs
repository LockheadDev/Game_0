using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScoreinGameOver : MonoBehaviour
{
   
    
    public Text highScore;
    public Text score;
    public TextMeshProUGUI newhighScoreMess;


    // Start is called before the first frame update
    void Start()
    {
        highScore.text =  PlayerPrefs.GetInt("HighScore",0).ToString();
        newhighScoreMess.text = null;
    }

    void Update()
    {
        if (SceneMng.getgameOver())
        {
            highScore.text =  PlayerPrefs.GetInt("HighScore").ToString();
            if (highScore.text == score.text)
            {
                newhighScoreMess.text = "New Record!";
                newhighScoreMess.color = Color.yellow;
            }
        }
    }
    

}
