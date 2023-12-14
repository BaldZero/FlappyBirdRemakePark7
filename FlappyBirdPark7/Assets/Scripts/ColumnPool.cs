using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColumnPool : MonoBehaviour
{
    private GameObject[] Columns;
    private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
    private float TimeSinceLastSpawned;
    private float spawnXposition = 10f;
    private int currentColumn = 0;

    public int columnPoolSize = 5;
    public GameObject columnPrefab;
    public float Spawnrate = 4f;
    public float columnMin = -1f;
    public float columnMax = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        Columns = new GameObject[columnPoolSize];
        for (int i = 0; i < columnPoolSize; i++)
        {
            Columns[i] = (GameObject) Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceLastSpawned += Time.deltaTime;

        if(ControllGame.instance.GameOver == false && TimeSinceLastSpawned >= Spawnrate) 
        {
            TimeSinceLastSpawned = 0;
            float spawnYposition = Random.Range(columnMin, columnMax);
            Columns[currentColumn].transform.position = new Vector2(spawnXposition, spawnYposition);
            currentColumn++;
            if(currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }
        }
    }
}
