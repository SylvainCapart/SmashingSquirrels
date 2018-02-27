
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PrecountTimer : MonoBehaviour {

    public float timeLeft = Globals.PRECOUNT_DURATION;
    public Text timeText;
    public enum SizeChangeMode
    {
        DOUBLE,
        INCREASE,
        DECREASE
    }


    private float sizeX;
    private float sizeY;
    private bool increase;
    public float sizeChangePeriod = 1f;
    public float changeAmount = 0.01f;
    public float startDelay = 0.2f;
    public float framerateDelay = 0.1f;
    private float lastIncreaseTime;
    private float creationTime;
    Vector2 originalScale;
    private int intTimeLeft;
    public SizeChangeMode sizeChangeMode = SizeChangeMode.DECREASE;
    
    private int previousTimeLeft;
    //public PrecountTimer timer;

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
        sizeX = gameObject.transform.localScale.x;
        sizeY = gameObject.transform.localScale.y;
        originalScale.x = gameObject.transform.localScale.x;
        originalScale.y = gameObject.transform.localScale.y;
        increase = true;
        lastIncreaseTime = 0f;
        creationTime = Time.time;
        intTimeLeft = 0;
        previousTimeLeft = 0;
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

        intTimeLeft = (int) timeLeft;
        Debug.Log(intTimeLeft + " " + previousTimeLeft);
        switch (sizeChangeMode)
        {
            case SizeChangeMode.DOUBLE:
                if ((Time.time - lastIncreaseTime) > sizeChangePeriod)
                {
                    increase = !increase;
                    lastIncreaseTime = Time.time;
                }

                if (increase)
                {
                    sizeX += changeAmount;
                    sizeY += changeAmount;
                }
                else
                {
                    sizeX -= changeAmount;
                    sizeY -= changeAmount;
                }
                break;
            case SizeChangeMode.INCREASE:

                break;
            case SizeChangeMode.DECREASE:
                if ((Time.time - creationTime) > startDelay)
                {
                    if (/*intTimeLeft != previousTimeLeft )*/(Time.time - lastIncreaseTime) > sizeChangePeriod)
                    {
                        //delayIncrease(framerateDelay);
                        //lastIncreaseTime = Time.time;
                        sizeX = originalScale.x;
                        sizeY = originalScale.y;
                        lastIncreaseTime = Time.time;
                    }
                    if (sizeX > 0 && sizeY > 0)
                        sizeX -= changeAmount;
                    sizeY -= changeAmount;

                }
                break;
            default:
                Debug.Log("Error getting size change mode in " + gameObject.name);
                break;
        }
        previousTimeLeft = intTimeLeft;

    }

    private void FixedUpdate()
    {
        gameObject.transform.localScale = new Vector3(sizeX, sizeY, gameObject.transform.lossyScale.z);
    }

    IEnumerator destroy()
    {

        yield return (new WaitForSeconds(10f));
        Destroy(gameObject.transform.parent);
    }

   
}
