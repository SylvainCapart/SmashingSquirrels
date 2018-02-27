using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneChanger : MonoBehaviour {
    public float m_delay = 2f;
    public Globals.SceneIndex m_sceneTarget;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void goToGame()
    {
        StartCoroutine(goToGameDelay());
        //SceneManager.LoadScene((int)Globals.SceneIndex.GAME);
    }

    public void goToScene()
    {
        StartCoroutine(goToSceneCo());
        
    }
    private IEnumerator goToSceneCo()
    {
        yield return (new WaitForSeconds(m_delay));
        SceneManager.LoadScene((int)m_sceneTarget);
        yield return null;
    }



    public void nextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void chooseSceneWithDelay(Globals.SceneIndex sceneIndex, float delay)
    {
        StartCoroutine(chooseSceneWithDelayCo(sceneIndex, delay));
    }


    private IEnumerator chooseSceneWithDelayCo(Globals.SceneIndex sceneIndex, float delay)
    {
        yield return (new WaitForSeconds(delay));
        SceneManager.LoadScene((int)sceneIndex);
        yield return null;
    }

    private IEnumerator goToGameDelay()
    {
        yield return (new WaitForSeconds(m_delay));
        SceneManager.LoadScene((int)Globals.SceneIndex.GAME);
        yield return null;
    }



    private IEnumerator nextSceneDelay()
    {
        yield return (new WaitForSeconds(m_delay));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        yield return null;
    }


}
