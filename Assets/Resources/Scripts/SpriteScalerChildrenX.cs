using UnityEngine;
using UnityEngine.UI;

public class SpriteScalerChildrenX : MonoBehaviour
{
    private float oldObjectWidth;
    private float oldObjectHeight;
    private Vector2 referenceResolution;
    // Use this for initialization
    void Start()
    {

        foreach (Transform child in transform)
        {


            float newObjectWidth;
            float newObjectHeight;


            oldObjectWidth = child.transform.localScale.x;
            oldObjectHeight = child.transform.localScale.y;
            //Debug.Log(oldObjectWidth + " and " + oldObjectHeight);

            referenceResolution = GameObject.FindObjectOfType<Canvas>().GetComponent<CanvasScaler>().referenceResolution;

            if (null == referenceResolution) return;
            //Debug.Log(referenceResolution);

            newObjectWidth = oldObjectWidth * referenceResolution.y / referenceResolution.x * Screen.width / Screen.height;
            newObjectHeight = oldObjectHeight;// * referenceResolution.y / referenceResolution.x * Screen.width / Screen.height;
            //Debug.Log(newObjectWidth + " and " + newObjectHeight);
            child.transform.localScale = new Vector3(newObjectWidth, newObjectHeight, child.transform.localScale.z);


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
