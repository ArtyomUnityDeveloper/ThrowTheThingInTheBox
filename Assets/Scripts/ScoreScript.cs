using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private Text scoreText;
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        count += score;
        scoreText.text = "Score : " + count;
    }
}
