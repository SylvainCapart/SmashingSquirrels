using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMgt : MonoBehaviour {

    private Queue<string> sentences;
    public Text nameText;
    public Text dialogueText;
    public Animator animator;
    [SerializeField]
    private int clickNumber;
    private GameObject vanishWhite;
    private GameObject explosion;
    private GameObject lazySquirrel;
    private GameObject speedSquirrel;
    private bool lazySquirrelDestroyed;
    private bool speedSquirrelDestroyed;
    private bool dialogueReactivated;
    [SerializeField]
    private int squirrelsDestroyed;
    public WhiteOutActivator whiteOutActivator;


    // Use this for initialization
    void Start () {
        Debug.Log("test");
        sentences = new Queue<string>();
        squirrelsDestroyed = 0;
        dialogueReactivated = false;
        vanishWhite = (GameObject)Resources.Load("Prefab/vanish_white", typeof(GameObject));
        lazySquirrel = (GameObject)Resources.Load("Prefab/IntroPoppingSquirrel", typeof(GameObject));
        speedSquirrel = (GameObject)Resources.Load("Prefab/IntroSquirrelTouch", typeof(GameObject));
    }

    private void Update()
    {
        if(!dialogueReactivated && (2 == squirrelsDestroyed))
        {
            ActivateDialogue();
            GameObject.Find("ContinueText").GetComponent<TextBlinker>().Awake();
            dialogueReactivated = true;
        }
    }


    public void StartDialogue(Dialogue dialogue)
    {
        clickNumber = 0;
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        ++clickNumber;
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

        if (7 == clickNumber)
        {
            GameObject.Find("Weapons").transform.Find("Flak").gameObject.SetActive(true);
            GameObject.Find("Weapons").transform.Find("Jakobs").gameObject.SetActive(true);
        }
        else if (12 == clickNumber)
        {
            if (vanishWhite)
            {
                explosion = Instantiate(vanishWhite, GameObject.Find("Flak").transform.position, Quaternion.identity);
                explosion.transform.SetParent(GameObject.Find("Panel").transform);
                explosion.transform.localScale = new Vector3(7, 7, 7);

                explosion = Instantiate(vanishWhite, GameObject.Find("Jakobs").transform.position, Quaternion.identity);
                explosion.transform.SetParent(GameObject.Find("Panel").transform);
                explosion.transform.localScale = new Vector3(7, 7, 7);

            }
            GameObject.Find("Weapons").transform.Find("Flak").gameObject.SetActive(false);
            GameObject.Find("Weapons").transform.Find("Jakobs").gameObject.SetActive(false);
            GameObject.Find("NetLayer").transform.Find("SquirrelNet").gameObject.SetActive(true);

        }
        else if( 15 == clickNumber)
        {
            DeactivateDialogue();

            GameObject tempObject;
            tempObject = Instantiate(lazySquirrel, GameObject.Find("WoodFloor").transform.position, Quaternion.identity);
            

            tempObject = Instantiate(speedSquirrel, GameObject.Find("WoodFloor").transform.position, Quaternion.identity);
            tempObject.transform.Translate(new Vector3(-200, 0, 0));
        }



    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End Dialogue");
        whiteOutActivator.WhiteOutActivate();
        GameObject.Find("Canvas").GetComponent<FadeCanvasGroup>().Fade();
        GameObject.FindObjectOfType<SceneChanger>().goToScene();
    }

    void DeactivateDialogue()
    {
        GameObject.Find("ContinueButton").gameObject.SetActive(false);
        animator.SetBool("isOpen", false);
    }

    void ActivateDialogue()
    {
        GameObject.Find("DialogueBox").transform.Find("ContinueButton").gameObject.SetActive(true);
        animator.SetBool("isOpen", true);
    }

    public void incrementSquirrelsDestroyed()
    {
        squirrelsDestroyed++;
    }


}
