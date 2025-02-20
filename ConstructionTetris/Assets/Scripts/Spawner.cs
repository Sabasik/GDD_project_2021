using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;

    public AudioClipGroup ThudAudio;
    public AudioClipGroup OwAudio;
    public AudioClipGroup SquashAudio;
    public AudioClipGroup ShuffleAudio;
    public AudioClipGroup LastThreeSeconds;
    public AudioClipGroup RemoveRow;
    // public AudioClipGroup GameplayAudio;

    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI RowsText;

    public GameObject Worker;
    public GameObject Zombie;

    public GameObject RowDisappear;

    public GameObject[] Shapes;

    public GameObject[] Shapes_original;
    public GameObject[] Shapes_dark;
    public GameObject[] Shapes_special;


    public int workerCount = 3;
    public int lives = 3;
    public float gameLength = 180f;

    public int rowsCleared = 0;

    private float endTime = 0;
    private bool countdown = false;
    private bool reversed = false;
    public float killed;

    public static string theme;

    private void Awake()
    {
        spawner = this;
        reversed = Events.reversed;
        workerCount = Events.workerCount;
        print(workerCount);
        lives = Events.lives;
        gameLength = Events.gameLength;
        //GameplayAudio.Play();
        
    }

    private void Start()
    {
        killed = 0;
        rowsCleared = 0;
        workerCount = Events.workerCount;
        lives = Events.lives;
        gameLength = Events.gameLength;
        if(!reversed) LivesText.text = "Lives: " + lives;
        else LivesText.text = "Killed: " + killed;
        TimeText.text = "Time: " + gameLength;
        RowsText.text = "Rows Cleared: " + rowsCleared;
        endTime = Time.time + gameLength;
        
        if (theme == "original")
        {
            Shapes = Shapes_original;
        }
        else if (theme == "dark"){
            Shapes = Shapes_dark;
        }
        else if (theme == "special")
        {
            Shapes = Shapes_special;
        }

        for (int i = 0; i < workerCount; i++) SpawnWorker();
        spawnNext();
        
        
    }

    private void Update()
    {
        if (endTime <= Time.time) GameOver(true);
        if (Time.time + 4 >= endTime && !countdown) {
            countdown = true;
            LastThreeSeconds.Play();
        }
        if (!reversed)
        {
            if (lives <= 0) GameOver(false);
            LivesText.text = "Lives: " + lives;
        }
        else
        {
            LivesText.text = "Killed: " + killed;
        }
        TimeText.text = (int)(endTime - Time.time) + "";
        RowsText.text = "Rows Cleared: " + rowsCleared;
    }

    public void GameOver(bool win, bool esc = false)
    {
        var message = "";
        if (win) message = "You Won!";
        else message = "You Lost!";
        if (Events.reversed) message = "Killed: " + killed;
        message += "\nRows Cleared: " + rowsCleared;
        if (esc) message = "";
        UI.mess = message;
        SceneManager.LoadScene("Menu");
        //Events.SetMessage(message);
    }

    public void SpawnWorker()
    {
        if(!reversed) Instantiate(Worker, transform.position, Quaternion.identity);
        else Instantiate(Zombie, transform.position, Quaternion.identity);
    }

    public void spawnNext()
    {
        int i = Random.Range(0, Shapes.Length);

        Instantiate(Shapes[i], transform.position, Quaternion.identity);
    }


}
