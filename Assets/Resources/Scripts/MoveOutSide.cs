
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveOutSide : MonoBehaviour {

    public int speed = 500;

    private bool left;
    private bool right;
    private bool borderReached;
    public  float MAX_X = 650;
    public  float MIN_X = 20f;
    public  float MAX_Y = 90;
    public  float MIN_Y = -200f;
    private Button buttonLeft;
    private SpriteState spriteState;

    public bool Left
    {
        get
        {
            return left;
        }

        set
        {
            left = value;
        }
    }

    public bool Right
    {
        get
        {
            return right;
        }

        set
        {
            right = value;
        }
    }

    public bool BorderReached
    {
        get
        {
            return borderReached;
        }

        set
        {
            borderReached = value;
        }
    }

    // Use this for initialization

    void Start () {
        Left = false;
        Right = false;
        BorderReached = false;
        buttonLeft = GameObject.Find("ButtonLeft").GetComponent<Button>();
        spriteState = new SpriteState();
        
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown("a") || Input.GetKeyDown("q") || Input.GetKeyDown("left"))
        {
            Left = true;
            Right = false;
            buttonLeft.spriteState = spriteState;
            //buttonLeft.onClick.Invoke();
            //buttonLeft.GetComponent<Button>().OnSelect(null);
            //EventSystem.current.SetSelectedGameObject(buttonLeft.GetComponent<Button>().gameObject, null);
        }
        else if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            Right = true;
            Left = false;
        }
        else
        {
            //Do nothing
        }

        if (Input.GetKeyUp("a") || Input.GetKeyUp("q") || Input.GetKeyUp("left") )
        {
            Left = false;
        }
        else if (Input.GetKeyUp("d") || Input.GetKeyUp("right") )
        {
            Right = false;
        }
        else
        {
            //Do nothing
        }



    }

    private void FixedUpdate()
    {
        if (Right && transform.position.x > MIN_X)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            borderReached = false;
        }
        else if (transform.position.x <= MIN_X)
        {
            borderReached = true;
        }
        else
        {/* Do nothing */ }

        if (Left && transform.position.x < MAX_X)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            borderReached = false;
        }
        else if (transform.position.x >=  MAX_X)
        {
            borderReached = true;
        }
        else
        {/* Do nothing */ }

    }
}
