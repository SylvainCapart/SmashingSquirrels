using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Simple fade animation, then destroys the object
/// </summary>
public class WhiteOut : MonoBehaviour
{

    private TextMesh m_textMesh;
    private IEnumerator m_co;
    private float m_fadeTime = 2f;

    public float FadeTime
    {
        get
        {
            return m_fadeTime;
        }

        set
        {
            m_fadeTime = value;
        }
    }

    void Start()
    {

    }

    public void fade(float fadeTime)
    {
        m_fadeTime = fadeTime;
        m_co = fadeOut();
        StartCoroutine(m_co);
        //Destroy(this.gameObject, m_fadeTime);
    }

    IEnumerator fadeOut()
    {


        Color originalColor = this.GetComponent<SpriteRenderer>().color;
        if (null == originalColor)
        {
            Debug.Log("Error finding Sprite renderer or its color in " + gameObject.name);
        }

        originalColor.a = 1.0f;
        for (float t = 0.0f; t < m_fadeTime; t += Time.deltaTime)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(originalColor.r, originalColor.g, originalColor.b, originalColor.a * ( t / m_fadeTime));
            //Debug.Log(this.GetComponent<SpriteRenderer>().color);
            yield return null;
        }


        yield return null;
    }

    private void Awake()
    {
        fade(m_fadeTime);
    }

}