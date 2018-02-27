using System.Collections;
using UnityEngine;

public class SizeChanger : MonoBehaviour
{

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
    public SizeChangeMode sizeChangeMode = SizeChangeMode.DECREASE;
    private int timeLeft;
    private int previousTimeLeft;
    public PrecountTimer timer;


    // Use this for initialization
    void Start()
    {
        sizeX = gameObject.transform.localScale.x;
        sizeY = gameObject.transform.localScale.y;
        originalScale.x = gameObject.transform.localScale.x;
        originalScale.y = gameObject.transform.localScale.y;
        increase = true;
        lastIncreaseTime = 0f;
        creationTime = Time.time;
        timeLeft = 0;
        previousTimeLeft = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft = (int)timer.TimeLeft;
        Debug.Log(timeLeft + " " + previousTimeLeft);
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
                    if (/*timeLeft != previousTimeLeft ) ||*/ (Time.time - lastIncreaseTime) > sizeChangePeriod)
                    {
                        //delayIncrease(framerateDelay);
                        //lastIncreaseTime = Time.time;
                        sizeX = originalScale.x;
                        sizeY = originalScale.y;
                        lastIncreaseTime = Time.time;
                    }
                    if (sizeX > 0  && sizeY > 0)
                    sizeX -= changeAmount;
                    sizeY -= changeAmount;
                    
                }
                break;
            default:
                Debug.Log("Error getting size change mode in " + gameObject.name);
                break;
        }
        previousTimeLeft = timeLeft;
    }


    private void FixedUpdate()
    {
        gameObject.transform.localScale = new Vector3(sizeX, sizeY, gameObject.transform.lossyScale.z);
    }

    IEnumerator delayIncrease(float delay)
    {
        yield return (new WaitForSeconds(delay));
        sizeX = originalScale.x;
        sizeY = originalScale.y;
        
    }

}
