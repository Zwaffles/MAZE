using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static Action<int> scoreEvent;
    public TMP_Text tmpScore;
    [SerializeField] [Tooltip("Current score")] 
    private int score;

    void Awake()
    {
        score = 0;
        tmpScore.SetText("Score: " + score);
    }
    void Start()
    {
        scoreEvent += AddScore;
    }
    
    void Update()
    {
        tmpScore.SetText("Score: " + score);
    }

    //Adds the score from the collider to the total
    private void AddScore(int colliderScore)
    {
        score += colliderScore;
    }
}
