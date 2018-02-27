using System.Collections;
using UnityEngine;

public class FadeCanvasGroup : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    private CanvasGroup containerCanvasGroup;
    public float timeFade = 2f;
    void Awake()
    {
        canvasGroup = GameObject.Find("Canvas").GetComponent<CanvasGroup>();
    }

    void Start()
    {
        
    }

    public void Fade()
    {
        StartCoroutine("FadeOut", canvasGroup);
    }



    IEnumerator FadeOut(CanvasGroup canvasGroupArg)
    {
        canvasGroupArg.blocksRaycasts = false;
        while (canvasGroupArg.alpha > 0)
        {
            canvasGroupArg.alpha -= Time.deltaTime / timeFade;
            yield return null;
        }
    }


}