using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public float score;
    string niceScore;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 1;
        niceScore = score.ToString("0000");
        scoreText.text = niceScore;
    }
}
