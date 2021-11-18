using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;

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
        endTime = Time.time + gameLength;
        for (int i = 0; i < workerCount; i++) SpawnWorker();
        spawnNext();
    }

    private void Update()
    {
        if (endTime <= Time.time) GameOver(true);
        if (lives <= 0) GameOver(false);
    }

    public void GameOver(bool win)
    {
        var message = "";
        if (win) message = "You Won!";
        else message = "You Lost!";
        SceneManager.LoadScene("Menu");
        print(message);
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
