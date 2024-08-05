using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score instance;
    public int score = 0;
    public TMP_Text scoreText;

    void Awake()
    {
        // Singleton Pattern'in uygulanması
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Sahneden sahneye geçişlerde yok olmasın
        }
        else
        {
            Destroy(gameObject); // Eğer başka bir instance varsa bunu yok et
        }
        Debug.Log("Score instance set to: " + instance);
    }
    void Start()
    {
        UpdateScore();
    }
    public void UpdateScore()
    {
        if(scoreText != null){
            scoreText.text = "Score: " + score.ToString();
        }
    }



}



