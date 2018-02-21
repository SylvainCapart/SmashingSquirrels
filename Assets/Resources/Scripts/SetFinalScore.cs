using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SetFinalScore : MonoBehaviour {
    private GameObject gameMgt;
	// Use this for initialization
	void Start () {
        gameMgt = GameObject.Find("GameMgt");
        if (gameMgt)
            this.GetComponent<Text>().text = "SCORE : " + gameMgt.GetComponent<GameMgt>().Score.ToString();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
