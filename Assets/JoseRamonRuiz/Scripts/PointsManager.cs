using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    public GameObject Point;
    public Transform player;
    public Text scoreText;
    public GameObject winText;
    public int totalPoints = 12;
    private int currentScore = 0;

    private static PointsManager instance;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        winText.SetActive(false);
        SpawnPoints();
        UpdateScoreText();
    }
    void SpawnPoints()
    {
        float radius = 3f;
        for (int i = 0; i < totalPoints; i++)
        {
            float angle = i * Mathf.PI * 2 / totalPoints;
            Vector3 position = new Vector3(Mathf.Cos(angle) * radius, 0.25f, Mathf.Sin(angle) * radius);
            GameObject pointInstance = Instantiate(Point, position, Quaternion.identity);
            pointInstance.AddComponent<RotateObject>();
        }
    }
    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore + "/" + totalPoints;
    }
    public static void AddPoint()
    {
        instance.currentScore++;
        instance.UpdateScoreText();

        if (instance.currentScore >= instance.totalPoints)
        {
            instance.winText.SetActive(true);
        }        
    }
}




