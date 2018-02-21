
using System;
using UnityEngine;

public class fastSquirrelController : MonoBehaviour
{

    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    }
    public float MAX_X = 10;
    public float MIN_X = -500f;
    public float MAX_Y = 90f;
    public float MIN_Y = -180f;

    private bool goLeft;
    private bool goRight;
    private bool goUp;
    private bool goDown;
    [SerializeField]
    private Direction goWhere;
    private Animator anim;
    private bool changeDirection;
    private float lastChangeTime;
    public float squirrelSpeed;

    private float squirrelCreationTime;
    public float squirrelDuration = 2f;
 
    public bool changeDirectionActive;
    public bool disappearActive;

    public float changeDuration = 0.2f;

    [SerializeField]
    private bool isTouchingWall;

    CapsuleCollider2D m_Collider;
    GameObject[] m_walls;

    BoxCollider2D[] m_wallColliders;
    private MoveOutSide backScript;

    // Use this for initialization
    void Start()
    {

        goWhere = Direction.LEFT;
        goLeft = false;
        goRight = true;
        goUp = false;
        goDown = false;
        anim = gameObject.GetComponent<Animator>();
        lastChangeTime = 0;
        changeDirectionActive = true;


        isTouchingWall = false;
        disappearActive = true;
        squirrelCreationTime = Time.time;
        //Check that the first GameObject exists in the Inspector and fetch the Collider
        if (gameObject != null)
            m_Collider = gameObject.GetComponent<CapsuleCollider2D>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        m_walls = GameObject.FindGameObjectsWithTag("Wall");

        m_wallColliders = new BoxCollider2D[m_walls.Length];

        for (int i = 0; i < m_walls.Length; i++)
        {
            //Debug.Log(m_walls[i].name);
            m_wallColliders[i] = m_walls[i].GetComponent<BoxCollider2D>();
        }


        backScript = GameObject.Find("BackgroundMain").GetComponent<MoveOutSide>();

    }

    // Update is called once per frame
    void Update()
    {
        if (changeDirectionActive && (Time.time - lastChangeTime) > changeDuration)
        {
            //Debug.Log("changeDirection");
            changeSquirrelDirection(goWhere);
            lastChangeTime = Time.time;
        }

        if (disappearActive && (Time.time - squirrelCreationTime) > squirrelDuration)
        {
            FastSquirrelMgt.squirrelCount--;
            DestroyObject(gameObject);
        }
    }

    private void FixedUpdate()
    {

       
        switch (goWhere)
        {
            case Direction.LEFT:
                //transform.Translate(Vector2.left * Time.deltaTime * squirrelSpeed);
                GetComponent<Rigidbody2D>().velocity = - transform.right * squirrelSpeed;
                anim.SetBool("goLeft", true);
                anim.SetBool("goRight", false);
                anim.SetBool("goUp", false);
                anim.SetBool("goDown", false);
                /*if (backScript.Left && !backScript.BorderReached)
                    transform.Translate(Vector2.right * Time.deltaTime * backScript.speed);
                else if (backScript.Right && !backScript.BorderReached)
                    transform.Translate(Vector2.left * Time.deltaTime * backScript.speed);
               else { /*Do nothing*/

                break;
            case Direction.RIGHT:
                //transform.Translate(Vector2.right * Time.deltaTime * squirrelSpeed);
                GetComponent<Rigidbody2D>().velocity = transform.right * squirrelSpeed;
                anim.SetBool("goLeft", false);
                anim.SetBool("goRight", true);
                anim.SetBool("goUp", false);
                anim.SetBool("goDown", false);
               /* if (backScript.Right && !backScript.BorderReached)
                    transform.Translate(Vector2.left * Time.deltaTime * backScript.speed);
                else if (backScript.Left && !backScript.BorderReached)
                    transform.Translate(Vector2.right * Time.deltaTime * backScript.speed);
                else { /*Do nothing*/
                break;

            case Direction.UP:
                //transform.Translate(Vector2.up * Time.deltaTime * squirrelSpeed);
                GetComponent<Rigidbody2D>().velocity = transform.up * squirrelSpeed;
                anim.SetBool("goLeft", false);
                anim.SetBool("goRight", false);
                anim.SetBool("goUp", false);
                anim.SetBool("goDown", true);
                break;
            case Direction.DOWN:
                //transform.Translate(Vector2.down * Time.deltaTime * squirrelSpeed);
                GetComponent<Rigidbody2D>().velocity = -transform.up * squirrelSpeed;
                anim.SetBool("goLeft", false);
                anim.SetBool("goRight", false);
                anim.SetBool("goUp", true);
                anim.SetBool("goDown", false);
                break;
            default:
                Debug.Log("error fastsquirrel choosing direction");
                break;
        }

        for (int i = 0; i < m_wallColliders.Length; i++)
        {
            if (m_Collider.IsTouching(m_wallColliders[i]))
            {

                switch (goWhere)
                {
                    case Direction.LEFT:
                        transform.Translate(-3 * Vector2.left * Time.deltaTime * squirrelSpeed);
                        GetComponent<Rigidbody2D>().velocity = -transform.right * squirrelSpeed;
                        forceDirection(Direction.RIGHT);
                        break;
                    case Direction.RIGHT:
                        GetComponent<Rigidbody2D>().velocity = transform.right * squirrelSpeed;
                        transform.Translate(-3 * Vector2.right * Time.deltaTime * squirrelSpeed);
                        forceDirection(Direction.LEFT);
                        break;
                    case Direction.UP:
                        GetComponent<Rigidbody2D>().velocity = transform.up * squirrelSpeed;
                        transform.Translate(-5 * Vector2.up * Time.deltaTime * squirrelSpeed);
                        forceDirection(Direction.DOWN);
                        break;
                    case Direction.DOWN:
                        GetComponent<Rigidbody2D>().velocity = -transform.up * squirrelSpeed;
                        transform.Translate(-5 * Vector2.down * Time.deltaTime * squirrelSpeed);
                        forceDirection(Direction.UP);
                        break;
                    default:
                        Debug.Log("error fastsquirrel choosing direction");
                        break;
                }

                lastChangeTime = Time.time;
            }
        }

    }

    Direction hurtBorder()
    {
        return Direction.RIGHT;
    }


    void changeSquirrelDirection(Direction oldDirection)
    {
        int whileSecurity = 0;
        while (goWhere == oldDirection && whileSecurity < 100)
        {
            Array values = Enum.GetValues(typeof(Direction));
            System.Random random = new System.Random();
            goWhere = (Direction)values.GetValue(random.Next(values.Length));
            //Debug.Log("NEW DIR : " + (int)goWhere);
            whileSecurity++;
        }
    }

    void forceDirection(Direction newDir)
    {
        goWhere = newDir;
    }
}
