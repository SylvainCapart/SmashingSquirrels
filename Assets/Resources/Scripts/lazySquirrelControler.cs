using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazySquirrelControler : MonoBehaviour {
    public float squirrelDuration = 2f;
    private float squirrelCreationTime;

    // Use this for initialization
    void Start () {

        squirrelCreationTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        if ((Time.time - squirrelCreationTime) > squirrelDuration)
        {
            SquirrelMgt.squirrelCount--;
            DestroyObject(gameObject);
        }
    }
}
