
using UnityEngine;
using UnityEngine.UI;
public class WhiteOutActivator : MonoBehaviour {

    public GameObject whiteOutSprite;
    public GameObject whiteOutPanel; //overlay used to deactivate buttons
    

    // Use this for initialization
    void Start () {
        /*whiteOutSprite = GameObject.Find("Panel").transform.Find("WhiteOutSprite").gameObject;
        if (!whiteOutSprite)
            Debug.Log("White Out Sprite not found in " + gameObject.name);

        whiteOutPanel = GameObject.Find("Panel").transform.Find("WhiteOutPanel").gameObject;
        if (!whiteOutPanel)
            Debug.Log("White Out Panel not found in " + gameObject.name);*/

    }
	

    public void WhiteOutActivate()
    {
        whiteOutSprite.SetActive(true);
        
        whiteOutPanel.SetActive(true);

    }
}
