using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnMouseDown()
    {
        
        //Debug.Log("Mouse down");
        if (Input.GetMouseButtonDown(0))
        {
           // Debug.Log("Mouse 0 down");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Debug.Log("Mouse position : " + Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
               // Debug.Log("Raycast hit");
                if (hit.transform.tag == "Squirrel")
                {
                    Debug.Log("DestroYED");
                    GameObject.Find("SquirrelMgt").GetComponent<AudioSource>().Play();
                    SquirrelMgt.squirrelCount--;
                    DestroyObject(gameObject);
                }
            }
        }

    }
}
