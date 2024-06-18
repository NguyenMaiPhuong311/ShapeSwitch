

using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles, buttonPanels, player, ground;
    [SerializeField] private float timeBetweenSpawns;

    private Vector3 spawnPos;
    private int countOfSpawn = 0;
    private bool spawnChanged = false;

    public int spawnType = 0;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        buttonPanels[0].SetActive(true);

        Spawn();
    }

    void Spawn()
    {
        switch (spawnType)
        {
            case 0:
                Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
                break;
            case 1:
                if (!spawnChanged)
                {
                    spawnChanged = true;
                    PanelSwitch();
                    ActivePlayer();
                    ChangeCamera();
                }
                else
                {
                    spawnPos = transform.position;
                    Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);
                    spawnPos.x = 3f;
                    Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPos, Quaternion.identity);

                }
                break;
        }


        Invoke("Spawn", timeBetweenSpawns);

        ChangeSpawnType();
        countOfSpawn++;
    }
    void ChangeSpawnType()
    {
        if (countOfSpawn < 5)
        {
            spawnType = 0;
        }
        else
        {
            spawnType = 1;
        }
    }

    void PanelSwitch()
    {
        buttonPanels[0].SetActive(false);
        buttonPanels[1].SetActive(true);
        buttonPanels[2].SetActive(true);
    }
    void ActivePlayer()
    {
        player[1].SetActive(true);
        ground[1].SetActive(true);
        player[0].SetActive(true);
    }

    void ChangeCamera()
    {
        Camera.main.transform.position = new Vector3(1.21f, 5.9f, -9.4f);
    }
}
