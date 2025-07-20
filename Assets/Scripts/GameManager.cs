using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    //PickUpPanel
    public Text timeText;
    public Text crystalText;
    public Text redKeyText;
    public Text greenKeyText;
    public Text blueKeyText;
    public Image snowFlake;

    //inGamePanel
    public Text useInfo;

    //InfoPanel
    public GameObject infoPanel;
    public Text infoText;
    public Text reloadText;


    public MusicScript musicScript;
    AudioSource audioSource;
    public AudioClip resumeClip;
    public AudioClip pauseClip;
    public AudioClip winClip;
    public AudioClip loseClip;

    public int timeToEnd;
    public int points;
    public float speedModifier;

    public int redKey;
    public int greenKey;
    public int blueKey;

    bool gamePaused = false;
    public bool win = false;
    bool lessTime = false;

    private void Start()
    {
        if (gameManager == null) gameManager = this;
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating(nameof(Stopper), 1f, 1f);
        infoPanel.SetActive(false);
        snowFlake.enabled = false;
        timeText.text = timeToEnd.ToString();
        useInfo.text = "";
        infoText.text = "Paused";
        crystalText.text = points.ToString();
        redKeyText.text = redKey.ToString();
        greenKeyText.text = greenKey.ToString();
        blueKeyText.text = blueKey.ToString();
    }

    public void PlayClip(AudioClip playClip)
    {
        audioSource.clip = playClip;
        audioSource.Play();
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
        timeText.text = timeToEnd.ToString();
    }

    public void FreezeTime(int freeze)
    {
        CancelInvoke(nameof(Stopper));
        snowFlake.enabled = true;
        InvokeRepeating(nameof(Stopper), freeze, 1f);
    }

    public void AddPoints(int point)
    {
        points += point;
        crystalText.text = points.ToString();
    }    

    public void AddKey(KeyColor color)
    {
        if (color==KeyColor.Red) redKey++;
        else if (color==KeyColor.Green) greenKey++;
        else blueKey++;

        redKeyText.text = redKey.ToString();
        greenKeyText.text = greenKey.ToString();
        blueKeyText.text = blueKey.ToString();
    }

    void Stopper()
    {
        timeToEnd--;
        timeText.text = timeToEnd.ToString();
        snowFlake.enabled = false;
        Debug.Log($"Time: {timeToEnd} s");
        if(timeToEnd<20 && !lessTime)
        {
            LessTimeOn();
            lessTime = true;
        }
        if (timeToEnd>=20 && lessTime)
        {
            LessTimeOff();
            lessTime = false;
        }
        if (timeToEnd<=0)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        CancelInvoke(nameof(Stopper));
        Time.timeScale=0f;
        infoPanel.SetActive(true);
        if (win)
        {
            Debug.Log("You Win!!! Reload?");
            infoText.text = "You Win!!!";
        }
        else 
        {
            Debug.Log("You Lose!!! Reload?");
            infoText.text = "You Lose!!!";
        }
        reloadText.text = "Reload?";
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
        infoPanel.SetActive(true);
        reloadText.text = "";
        musicScript.OnPauseGame();
        PlayClip(pauseClip);
        Debug.Log("Game Paused");
        gamePaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        infoPanel.SetActive(false);
        reloadText.text = "";
        musicScript.OnResumeGame();
        PlayClip(resumeClip);
        Debug.Log("Game Resumed");
        gamePaused = false;
        Time.timeScale = 1f;
    }

    public void LessTimeOn()
    {
        musicScript.PitchThis(1.58f);
    }

    public void LessTimeOff()
    {
        musicScript.PitchThis(1f);
    }
}
