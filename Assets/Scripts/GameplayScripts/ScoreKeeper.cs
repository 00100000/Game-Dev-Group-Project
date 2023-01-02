using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    float score;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        score = 5000f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(Mathf.Floor(timer%60) >= 1)
        {
            int seconds = (int) Mathf.Floor(timer % 60);
            score -= seconds;
            timer = 0;
        }
        scoreDisplay.SetText((int)score + "");
    }
    public void addScore(int scoreAdd)
    {
        score += (float)scoreAdd;
    }
    public void removeScore(int scoreRemove)
    {
        score -= (float)scoreRemove;
    }

    
}
