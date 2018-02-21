
using UnityEngine;

public class MouseDetection : MonoBehaviour
{

    private GameObject m_explosionRed;
    private GameObject m_netObject;
    CapsuleCollider2D m_Collider, m_Collider2;
    private bool isTouchingNet;
    private GameObject explosion;
    private float m_lastClick;
    private float m_lastTime;
    // Use this for initialization
    void Start()
    {
        m_explosionRed = (GameObject)Resources.Load("Prefab/explosion_red", typeof(GameObject));

        //Check that the first GameObject exists in the Inspector and fetch the Collider
        if (gameObject != null)
            m_Collider = gameObject.GetComponent<CapsuleCollider2D>();

        //Check that the second GameObject exists in the Inspector and fetch the Collider
        m_netObject = GameObject.Find("SquirrelNet");
        if (m_netObject != null)
            m_Collider2 = m_netObject.GetComponent<CapsuleCollider2D>();
        else
            Debug.Log("Error : Net object not found");

        isTouchingNet = false;
        m_lastClick = 0f;
        m_lastTime = 0f;

    }

    // Update is called once per frame
    void Update()
    {

        if (m_Collider.IsTouching(m_Collider2))
        {
            isTouchingNet = true;
            //Debug.Log("TOUCH");
        }
        else
        {
            isTouchingNet = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            m_lastClick = Time.time;

        }

       

        //Debug.Log("Mouse down");
        if (isTouchingNet && ((Time.time - m_lastClick) <= Globals.NET_ANIM_DURATION) && !(m_netObject.GetComponent<NetMgt>().CaughtASquirrel))
        {
            if (m_explosionRed)
            {
                explosion = Instantiate(m_explosionRed, transform.position, Quaternion.identity);
                explosion.transform.SetParent(GameObject.Find("BackgroundMain").transform);
                explosion.transform.localScale = new Vector3(4, 4, 4);
            }

            GameObject.Find("SquirrelMgt").GetComponent<AudioSource>().Play();
            

            if (gameObject.tag == "PoppingSquirrel")
            {
                SquirrelMgt.squirrelCount--;
                GameObject.Find("Score").GetComponent<ScoreMgt>().IncrementScore(Globals.LAZY_SQUIRREL_PT);
            }
            else if (gameObject.tag == "FastSquirrel")
            {
                FastSquirrelMgt.squirrelCount--;
                GameObject.Find("Score").GetComponent<ScoreMgt>().IncrementScore(Globals.FAST_SQUIRREL_PT);
            }
            else if (gameObject.tag == "GoldSquirrel")
            {
                FastSquirrelMgt.squirrelCount--;
                GameObject.Find("Score").GetComponent<ScoreMgt>().IncrementScore(Globals.GOLD_SQUIRREL_PT);
            }
            else
            { /*Do nothing*/}

            DestroyObject(gameObject);
            m_netObject.GetComponent<NetMgt>().CaughtASquirrel = true;
            m_lastClick = Time.time;

        }

    }


    void OnMouseDown()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AAAAAAAAAAAA");
    }


}
