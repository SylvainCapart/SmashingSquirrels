using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class FastSquirrelMgt : MonoBehaviour {

    private float lastPop;
    [SerializeField]
    private int squirrelInternalCount;
    static public int squirrelCount;
    public int maxSquirrelAllowed = 12;
    public float poppingSpeed = 1f;
    private GameObject squirrel;
    private GameObject goldSquirrel;
    
    private Vector3 lastSquirrelPos;

    public float MAX_X = 500f;
    public float MIN_X = -500f;
    public float MAX_Y = 90f;
    public float MIN_Y = -180f;
    public float GAP = 100.0f;
    private List<GameObject> squirrelList;
    public bool popActive = false;
    private bool goldSquirrelPresent = false;

    // Use this for initialization
    void Start () {
        lastPop = 0;
        squirrelCount = 0;

        squirrelInternalCount = 0;
        squirrel = (GameObject)Resources.Load("Prefab/FastSquirrel", typeof(GameObject));

        goldSquirrel = (GameObject)Resources.Load("Prefab/GoldSquirrel", typeof(GameObject));
        
        lastSquirrelPos = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
        if (popActive && !goldSquirrelPresent)
        {
            GameObject tempSquirrel;
            tempSquirrel = Instantiate(goldSquirrel, Vector3.zero, Quaternion.identity, GameObject.Find("BackgroundMain").transform);
            tempSquirrel.transform.position = tempSquirrel.transform.parent.transform.position + new Vector3(1,0,0);
            goldSquirrelPresent = true;
        }

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
           // GameObject.Destroy(child.gameObject);
        }
    }

}
