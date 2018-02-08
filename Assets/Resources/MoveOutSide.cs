using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOutSide : MonoBehaviour {

    public int speed = 10;

    private bool left;
    private bool right;

	// Use this for initialization

	void Start () {
        left = false;
        right = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("a") || Input.GetKeyDown("q") || Input.GetKeyDown("left"))
        {
            left = true;
        }
        else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            right = true;
        }
        else
        {
            //Do nothing
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("q") || Input.GetKeyUp("left") )
        {
            left = false;
        }
        else if (Input.GetKeyUp("d") || Input.GetKeyUp("right") )
        {
            right = false;
        }
        else
        {
            //Do nothing
        }



    }

    private void FixedUpdate()
    {
        if (right && transform.position.x > -4.5f)
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        else if (left && transform.position.x < 4.5f)
             transform.Translate(Vector3.right * Time.deltaTime * speed);
        else
        {
            // Do nothing
        }
    }
}
