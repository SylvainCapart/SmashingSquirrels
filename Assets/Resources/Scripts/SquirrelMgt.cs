using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SquirrelMgt : MonoBehaviour {

    private float lastPop;
    [SerializeField]
    private int squirrelInternalCount;
    [SerializeField]
    static public int squirrelCount;
    public int maxSquirrelAllowed = 12;
    public float poppingSpeed = 0.2f;
    private GameObject squirrel;
    private GameObject burstLeaves;
    private Vector3 lastSquirrelPos;

    public float MAX_X = 500f;
    public float MIN_X = -500f;
    public float MAX_Y = 90f;
    public float MIN_Y = -180f;
    public float GAP = 100.0f;
    private List<GameObject> squirrelList;
    public bool popActive;

    // Use this for initialization
    void Start () {
        lastPop = 0;
        squirrelCount = 0;
        popActive = false;
        squirrelInternalCount = 0;
        squirrel = (GameObject)Resources.Load("Prefab/PoppingSquirrel", typeof(GameObject));
        burstLeaves = (GameObject)Resources.Load("Prefab/BurstLeaves", typeof(GameObject));
        lastSquirrelPos = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
		if (popActive && (Time.time - lastPop) > poppingSpeed && squirrelCount < maxSquirrelAllowed)
        {
            GameObject tempSquirrel;
            int whileSecurity = 0;
            Transform backTransform = GameObject.Find("BackgroundMain").transform;

            Vector3 targetPos = new Vector3(Random.Range(MIN_X, MAX_X), Random.Range(MIN_Y, MAX_Y), 0);
            while (Mathf.Abs((backTransform.position.x + targetPos.x) - lastSquirrelPos.x) < GAP && whileSecurity < 15)
            {
                targetPos.x = Random.Range(MIN_X, MAX_X);
                whileSecurity++;
            }

            whileSecurity = 0;

            while (Mathf.Abs((backTransform.position.y + targetPos.y) - lastSquirrelPos.y) < GAP && whileSecurity < 15)
            {
                targetPos.y = Random.Range(MIN_Y, MAX_Y);
                whileSecurity++;
            }

            tempSquirrel = Instantiate(squirrel, Vector3.zero, Quaternion.identity, backTransform);
            tempSquirrel.transform.position = tempSquirrel.transform.parent.transform.position + targetPos;
            //squirrelList.Add(tempSquirrel);

            lastPop = Time.time;
            squirrelCount++;

            lastSquirrelPos.x = tempSquirrel.transform.position.x;
            lastSquirrelPos.y = tempSquirrel.transform.position.y;
        }
        squirrelInternalCount = squirrelCount;
        
    }

    public void RemoveSquirrels()
    {
        foreach (Transform child in GameObject.Find("BackgroundMain").transform)
        {
            if (child.tag == "PoppingSquirel" || child.tag == "FastSquirrel" || child.tag == "GoldSquirrel")
            GameObject.Destroy(child.gameObject);
        }
    }

}
