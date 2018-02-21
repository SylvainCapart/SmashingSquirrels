
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft = Globals.AVAILABLE_TIME;
    public Text timeText;
    public bool active = false;

    public float TimeLeft
    {
        get
        {
            return timeLeft;
        }

        set
        {
            timeLeft = value;
        }
    }

    // Use this for initialization
    void Start () {

        timeText.text = "Time left :\n " + timeLeft.ToString("0");
	}
	
	// Update is called once per frame
	void Update () {

        if (!active) return;

        if (timeLeft > 0f && active)
            timeLeft = (timeLeft - Time.deltaTime);
        else
        {
            timeLeft = 0f;
            GameObject.Find("GameMgt").GetComponent<GameMgt>().SetGameState(GameMgt.GameStateEnum.IDLE);
        }
        timeText.text = "Time left :\n " + timeLeft.ToString("0");

    }
}
