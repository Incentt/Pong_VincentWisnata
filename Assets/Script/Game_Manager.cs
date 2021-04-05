using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    public int score1;
    public int score2;
    public Text TextScore1;
    public Text TextScore2;
    public Trajectory trajectory;
    public Rigidbody2D Ball;
    public Player_Controller Player1;
    public Player_Controller Player2;
    private bool isDebugWindowShown = false;
    public GameObject pausebutton;
    private bool isPaused = false;
    public int maxscore;
    public GameObject restartbutton;

    private void Start()
    {
        trajectory.enabled = false;
        pausebutton.SetActive(false);
        restartbutton.SetActive(false);
    }
    public void AddScoreLeft()
    {
        score1 += 1;
    }
    public void AddScoreRight()
    {
        score2 += 1;
    }
    void Update()
    {
        TextScore1.text = score1.ToString();
        TextScore2.text = score2.ToString();
        if (score1 >= 10)
        {

            //resetgame
        }
        else if (score2 >= 10)
        {
            //resetgame
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!pausebutton.activeInHierarchy)pausebutton.SetActive(true);
            else pausebutton.SetActive(false);

            if (Time.timeScale == 0) Time.timeScale = 1;
            else if (Time.timeScale == 1) Time.timeScale = 0;
            
        }
        

    }
    void OnGUI()
    {
        if (isDebugWindowShown)
        {
            GUIStyle guistyle = new GUIStyle();
            guistyle.fontSize = 5;
            float impulsePlayer1X = Player1.LastContactPoint.normalImpulse;
            float impulsePlayer1Y = Player1.LastContactPoint.tangentImpulse;
            float impulsePlayer2X = Player2.LastContactPoint.normalImpulse;
            float impulsePlayer2Y = Player2.LastContactPoint.tangentImpulse;

            string debugText =
                  "Ball mass = " + Ball.mass + "\n" +
                  "Ball velocity = " + Ball.velocity + "\n" +
                  "Ball speed = " + Ball.velocity.magnitude + "\n" +
                  "Ball momentum = " + Ball.mass * Ball.velocity + "\n" +
                  "Last impulse from player 1 = (" + impulsePlayer1X + ", " + impulsePlayer1Y + ")\n" +
                  "Last impulse from player 2 = (" + impulsePlayer2X + ", " + impulsePlayer2Y + ")\n";

            // Tampilkan debug window
            GUIStyle guiStyle = new GUIStyle(GUI.skin.textArea);
            guiStyle.alignment = TextAnchor.UpperCenter;
            GUI.TextArea(new Rect(Screen.width / 2 - 200, Screen.height - 200, 400, 110), debugText, guiStyle);
            trajectory.enabled = !trajectory.enabled;
        }
        
        
        
        if (score1 == maxscore)
        {
            GUI.Label(new Rect(Screen.width / 6, Screen.height / 2 - 10, 2000, 1000), "PLAYER ONE WINS");
            restartbutton.SetActive(true);
            Ball.gameObject.SetActive(false);

        }

        else if (score2 == maxscore)
        {
            GUI.Label(new Rect(Screen.width / 2 + 170, Screen.height / 2 - 10, 2000, 1000), "PLAYER TWO WINS");
            restartbutton.SetActive(true);
            Ball.gameObject.SetActive(false);
        }

    }
    public void debugON()
    {
        isDebugWindowShown = !isDebugWindowShown;
        trajectory.enabled = !trajectory.enabled;
        GameObject BOC = GameObject.Find("BallAtCollision");
        if (!BOC.activeInHierarchy) BOC.SetActive(true);
        else BOC.SetActive(false);
    }
    public void restartGame()
    {
        SceneManager.LoadScene(1);
    }
}
