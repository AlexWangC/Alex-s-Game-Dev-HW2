using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public int scoreValue;
    public TMP_Text scoreText;
    public AudioClip scoreSound;
    private AudioSource audioSource;
    static int score
    {
        get { return PlayerPrefs.GetInt("score", 0); }
        set
        {
            PlayerPrefs.SetInt("score", value);
        }
    }
    void Start()
    {
        score = 0;
        scoreText.text = "Score:" + score;
        audioSource = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        score += scoreValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        score += scoreValue;
        audioSource.clip = scoreSound;
        audioSource.Play();
    }

    void Update() 
    {
        scoreText.text = "Score:" + score;
    }
}
