using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Point : MonoBehaviour
{
    public TMP_Text point;
    public TMP_Text highpoint;
    public static int pointCount;
    public static int highCount;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("High Point"))
        {
            highCount = PlayerPrefs.GetInt("High Point");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(pointCount > highCount)
        {
            highCount = pointCount;
            PlayerPrefs.SetInt("High Point", highCount);
        }

            pointCount = Collision.count + Collision2.count;
            point.text = "Point: " + pointCount.ToString();
            highpoint.text = "High Point: " + highCount;
        
    }
}