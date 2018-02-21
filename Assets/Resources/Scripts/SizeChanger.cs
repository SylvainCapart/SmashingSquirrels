using UnityEngine;

public class SizeChanger : MonoBehaviour {
    private float origSizeX;
    private float origSizeY;
    private bool increase;
    public float increaseTime = 1f;
    public float increaseAmount = 0.01f;
    private float lastIncreaseTime;
    // Use this for initialization
    void Start () {
        origSizeX = gameObject.transform.localScale.x;
        origSizeY = gameObject.transform.localScale.y;
        increase = true;
        lastIncreaseTime = 0f;
    }
	
	// Update is called once per frame
	void Update () {

        if ((Time.time - lastIncreaseTime) > increaseTime)
        {
            increase = !increase;
            lastIncreaseTime = Time.time;
        }

        if (increase)
        {
            origSizeX += increaseAmount;
            origSizeY += increaseAmount;
        }
        else
        {
            origSizeX -= increaseAmount;
            origSizeY -= increaseAmount;
        }
    }


    private void FixedUpdate()
    {
        gameObject.transform.localScale = new Vector3(origSizeX, origSizeY, gameObject.transform.lossyScale.z);
    }

}
