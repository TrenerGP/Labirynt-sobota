using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public int timeToEnd;
    public int points;
    public float speedModifier;

    public int redKey;
    public int greenKey;
    public int blueKey;

    bool gamePaused = false;
    bool win = false;

    private void Start()
    {
        if (gameManager == null) gameManager = this;
        InvokeRepeating(nameof(Stopper), 1f, 1f);
    }

    private void ResetSpeed()
    {
        speedModifier = 1f;
    }

    public void SetSpeedModifier(float value, int time)
    {
        speedModifier = value;
        Invoke(nameof(ResetSpeed), time);
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke(nameof(Stopper));
        InvokeRepeating(nameof(Stopper), freeze, 1f);
    }

    public void AddPoints(int point)
    {
        points += point;
    }    

    public void AddKey(KeyColor color)
    {
        if (color==KeyColor.Red) redKey++;
        else if (color==KeyColor.Green) greenKey++;
        else blueKey++;
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log($"Time: {timeToEnd} s");
        if (timeToEnd<=0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        //Time.timeScale=0f;
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
        }
        else 
        {
            Debug.Log("You Lose!!! Reload?");
        }
    }

    private void ReloadScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseCheck();
        ReloadScene();
    }

    public void PauseCheck()
    {
        if (gamePaused) ResumeGame();
        else PauseGame();
    }

    public void PauseGame()
    {
        Debug.Log("Game Paused");
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Debug.Log("Game Resumed");
        gamePaused = false;
        Time.timeScale = 1f;
    }
}
