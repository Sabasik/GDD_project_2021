using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;

    public TextMeshProUGUI LivesText;
    public TextMeshProUGUI TimeText;

    public GameObject Worker;
    public GameObject[] Shapes;
    public int workerCount = 1;
    public int lives = 3;
    public float gameLength = 60f;
    private float endTime = 0;

    private void Awake()
    {
        spawner = this;
    }

    private void Start()
    {
        LivesText.text = "Lives: " + lives;
        TimeText.text = "Time: " + gameLength;
        endTime = Time.time + gameLength;
        for (int i = 0; i < workerCount; i++) SpawnWorker();
        spawnNext();
    }

    private void Update()
    {
        if (endTime <= Time.time) GameOver(true);
        if (lives <= 0) GameOver(false);
        TimeText.text = (int)(endTime - Time.time) + "";
    }

    public void GameOver(bool win, bool esc = false)
    {
        var message = "";
        if (win) message = "You Won!";
        else message = "You Lost!";
        if (esc) message = "";
        UI.mess = message;
        SceneManager.LoadScene("Menu");
        //Events.SetMessage(message);
    }

    public void SpawnWorker()
    {
        Instantiate(Worker, transform.position, Quaternion.identity);
    }

    public void spawnNext()
    {
        int i = Random.Range(0, Shapes.Length);

        Instantiate(Shapes[i], transform.position, Quaternion.identity);
    }
}
