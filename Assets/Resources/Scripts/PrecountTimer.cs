
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PrecountTimer : MonoBehaviour {

    public float timeLeft = Globals.PRECOUNT_DURATION;
    public Text timeText;

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
        timeText = gameObject.GetComponent<Text>();
        timeText.text = timeLeft.ToString("0");
	}
	
	// Update is called once per frame
	void Update () {
        if (timeLeft > 0f)
            timeLeft = (timeLeft - Time.deltaTime);
        else
        {
            GameObject.Find("GameMgt").GetComponent<GameMgt>().SetGameState(GameMgt.GameStateEnum.GAMEON);
            Destroy(gameObject);
        }
        timeText.text = timeLeft.ToString("0");

    }

    IEnumerator destroy()
    {

        yield return (new WaitForSeconds(1f));
        Destroy(gameObject.transform.parent);
    }
}
