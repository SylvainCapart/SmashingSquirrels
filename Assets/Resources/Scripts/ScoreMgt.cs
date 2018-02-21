using UnityEngine;
using UnityEngine.UI;

public class ScoreMgt : MonoBehaviour {

    public Text scoreText;
    private int score;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    // Use this for initialization
    void Start () {
        scoreText.text = "SCORE : 0";
        Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "SCORE :" + Score.ToString();
	}

    public void IncrementScore(int addScore)
    {
        Score += addScore;
    }

}
