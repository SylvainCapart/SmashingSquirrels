using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroSquirrelController : MonoBehaviour {

    public float returnTime = 2f;
    public float lastReturnTime;
    [SerializeField]
    private bool switchDirection;
    public float squirrelSpeed = 200f;
    private Animator anim;

    // Use this for initialization
    void Start () {
        lastReturnTime = 0f;
        switchDirection = true;
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - lastReturnTime) > returnTime)
        {
            switchDirection = !switchDirection;
            lastReturnTime = Time.time;
        }
    }

    private void FixedUpdate()
    {
        if(switchDirection)
        {
            transform.Translate(Vector2.left * Time.deltaTime * squirrelSpeed);
            anim.SetBool("goLeft", true);
            anim.SetBool("goRight", false);
            anim.SetBool("goUp", false);
            anim.SetBool("goDown", false);
        }
        else
        {
            transform.Translate(Vector2.right * Time.deltaTime * squirrelSpeed);
            anim.SetBool("goLeft", false);
            anim.SetBool("goRight", true);
            anim.SetBool("goUp", false);
            anim.SetBool("goDown", false);
        }
    }
}
