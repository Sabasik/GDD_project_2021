using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Worker;
    public GameObject[] Shapes;
    public int workerCount = 1;


    private void Start()
    {
        for (int i = 0; i < workerCount; i++) SpawnWorker();
        spawnNext();
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
