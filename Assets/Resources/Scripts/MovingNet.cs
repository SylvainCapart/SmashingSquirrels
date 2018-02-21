
using UnityEngine;

public class MovingNet : MonoBehaviour
{
    private Vector2 spriteSize;
    // Use this for initialization
    void Start()
    {
        spriteSize = GameObject.Find("SquirrelNet").GetComponentInChildren<SpriteRenderer>().size;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = 10.0f; //distance of the plane from the camera
        //Debug.Log(Camera.main.ScreenToWorldPoint(screenPoint)  + " AND " + new Vector3(spriteSize.x / 2, spriteSize.y / 2, 0)); 
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

       
    }
}
