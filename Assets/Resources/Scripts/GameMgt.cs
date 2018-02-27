
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMgt : MonoBehaviour
{

    public enum GameStateEnum
    {
        IDLE,
        PRECOUNT,
        GAMEON,
        COUNT
    }


    public GameStateEnum m_gameState;

    public GameStateEnum GameState
    {
        get
        {
            return m_gameState;
        }

        set
        {
            m_gameState = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public SquirrelMgt squirrelMgt;
    public FastSquirrelMgt fastSquirrelMgt;
    public Timer timer;
    public ScoreMgt scoreMgt;
    private int score;

    // Use this for initialization
    void Start()
    {

        GameState = GameStateEnum.COUNT; // Dummy value for initialization
        SetGameState(GameStateEnum.IDLE);

    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameState)
        {
            case GameStateEnum.IDLE:

                break;
            case GameStateEnum.PRECOUNT:

                break;
            case GameStateEnum.GAMEON:

                break;
            case GameStateEnum.COUNT:
                //Do nothing, number of possible states
                break;
            default:
                Debug.Log("Error in setting game state : default case");
                break;
        }
        Score = scoreMgt.Score;

    }

    public void SetGameState(GameStateEnum newGameState)
    {

        switch (newGameState)
        {
            case GameStateEnum.IDLE:
                //Debug.Log(GameState);
                //if (GameState == GameStateEnum.IDLE) break;
                //GameObject.Find("GameMgt").SetActive(false);
                //GameObject.Find("Timer").SetActive(false);
                squirrelMgt.GetComponent<SquirrelMgt>().RemoveSquirrels();
                squirrelMgt.popActive = false;
                fastSquirrelMgt.popActive = false;
                timer.active = false;
                break;
            case GameStateEnum.PRECOUNT:
                if (GameState == GameStateEnum.PRECOUNT) return;
                break;
            case GameStateEnum.GAMEON:
                //if (GameState == GameStateEnum.GAMEON) return;
                timer.active = true;
                fastSquirrelMgt.popActive = true;
                squirrelMgt.popActive = true;
                //squirrelMgt.SendMessage("SetActive", true);
                break;
            case GameStateEnum.COUNT:
                if (GameState == GameStateEnum.COUNT) return;
                //Do nothing, number of possible states
                break;
            default:
                Debug.Log("Error in setting game state : default case");
                break;
        }
        GameState = newGameState;
    }



}
