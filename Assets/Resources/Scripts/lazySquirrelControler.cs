using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazySquirrelControler : MonoBehaviour
{
    public float squirrelDuration = 2f;
    private float squirrelCreationTime;
    public bool isDisappearActive = true;
    private GameObject burstLeaves;

    // Use this for initialization
    void Start()
    {
        burstLeaves = (GameObject)Resources.Load("Prefab/BurstLeaves", typeof(GameObject));
        squirrelCreationTime = Time.time;
    }


    // Update is called once per frame
    void Update()
    {
        if (isDisappearActive)
        {
            if ((Time.time - squirrelCreationTime) > squirrelDuration)
            {
                SquirrelMgt.squirrelCount--;
                if (burstLeaves)
                {
                    GameObject explosion;
                    explosion = Instantiate(burstLeaves, transform.position, Quaternion.identity);
                    //explosion = Instantiate(m_explosionRed, transform.position, Quaternion.identity);
                    explosion.transform.SetParent(GameObject.Find("BackgroundMain").transform);
                    explosion.transform.localScale = new Vector3(2, 2, 2);
                }
                //explosion.transform.localScale = new Vector3(7, 7, 7);
                isDisappearActive = false;
                DestroyObject(gameObject);
                
            }
        }
    }
}
