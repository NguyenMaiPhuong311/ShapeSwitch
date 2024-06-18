
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject start;
    

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<ObstacleSpawner>().enabled = false;
       
    }
    public void StartGame()
    {
        FindObjectOfType<ObstacleSpawner>().enabled = true;
        start.SetActive(false);
      
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
        Point.pointCount = 0;
        Collision.count = 0;
        Collision2.count = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
