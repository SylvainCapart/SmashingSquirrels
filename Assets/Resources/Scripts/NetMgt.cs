
using UnityEngine;

public class NetMgt : MonoBehaviour
{

  private Animator anim;
    private Vector2 spriteSize;
    private bool animation_started;
    private bool caughtASquirrel;
    private float m_lastTime;

    public bool Animation_started
    {
        get
        {
            return animation_started;
        }

        set
        {
            animation_started = value;
        }
    }

    public bool CaughtASquirrel
    {
        get
        {
            return caughtASquirrel;
        }

        set
        {
            caughtASquirrel = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        spriteSize = GameObject.Find("SquirrelNet").GetComponentInChildren<SpriteRenderer>().size;
        transform.position = transform.parent.transform.position;
        //Cursor.visible = false;
        anim = gameObject.GetComponent<Animator>();
        Animation_started = false;
        CaughtASquirrel = false;
        m_lastTime = 0f;


    }

    // Update is called once per frame
    void Update()
    {
        if (!Animation_started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Animation_started = true;
                anim.SetTrigger("Active");
                //Debug.Log("Animation set to TRUE");
            }
        }

        if ((Time.time - m_lastTime) >= Globals.NET_ANIM_DURATION)
        {
            CaughtASquirrel = false;
            m_lastTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        if (this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Idle"))
        {
            Animation_started = false;
            //Debug.Log("Animation set to false");
        }

    }



}
