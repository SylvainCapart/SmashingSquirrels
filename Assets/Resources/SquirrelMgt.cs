using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SquirrelMgt : MonoBehaviour {

    private float lastPop;
    [SerializeField]
    private int squirrelInternalCount;
    static public int squirrelCount;
    public int maxSquirrelAllowed;
    public float poppingSpeed;
    private GameObject squirrel;
    private Vector3 lastSquirrelPos;


    public const float MAX_X = 8.5f;
    public const float MIN_X = -8.5f;
    public const float MAX_Y = 1.2f;
    public const float MIN_Y = -4.0f;
    public const float GAP = 2.0f;

    // Use this for initialization
    void Start () {
        lastPop = 0;
        squirrelCount = 0;
        maxSquirrelAllowed = 1200;
        poppingSpeed = 1f;
        squirrelInternalCount = 0;
        squirrel = (GameObject)Resources.Load("PoppingSquirrel", typeof(GameObject));
        lastSquirrelPos = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - lastPop) > poppingSpeed && squirrelCount < maxSquirrelAllowed)
        {
            GameObject tempSquirrel;
            Transform backTransform = GameObject.Find("back").transform;
            Debug.Log("POP");

            Vector3 targetPos = new Vector3(Random.Range(MIN_X, MAX_X), Random.Range(MIN_Y, MAX_Y), 0);
            while (Mathf.Abs((backTransform.position.x + targetPos.x) - lastSquirrelPos.x) < GAP)
                targetPos.x = Random.Range(MIN_X, MAX_X);

            while (Mathf.Abs((backTransform.position.y + targetPos.y) - lastSquirrelPos.y) < GAP)
                targetPos.y = Random.Range(MIN_Y, MAX_Y);

            tempSquirrel = Instantiate(squirrel, Vector3.zero, Quaternion.identity, backTransform);
            tempSquirrel.transform.position = tempSquirrel.transform.parent.transform.position + targetPos;
            lastPop = Time.time;
            squirrelCount++;

            lastSquirrelPos.x = tempSquirrel.transform.position.x;
            lastSquirrelPos.y = tempSquirrel.transform.position.y;
        }
        squirrelInternalCount = squirrelCount;
        
    }
}
