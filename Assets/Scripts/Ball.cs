using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ball : MonoBehaviour
{
    public float initialForce;

    private Rigidbody2D rb;

    private int count = 0;

    float startX = -1.6f;
    float startY = 4.4f;

    private AudioSource audioSource;
    public AudioClip bouncingSound;
    public AudioClip ringSound;
    public AudioClip boardSound;
    public AudioClip deadSound;
    public AudioClip[] humanSound;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * initialForce);
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (count >= 3) 
        {
            SceneManager.LoadScene("DeadScene");
        }
        
        if (collision.gameObject)
        {
            audioSource.clip = bouncingSound;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Boundary")
        {
            gameObject.transform.position = new Vector3(startX, startY, 0);
            count++;
            audioSource.clip = deadSound;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Human")
        {
            audioSource.clip = humanSound[Random.Range(0, humanSound.Length)];
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Ring")
        {
            audioSource.clip = ringSound;
            audioSource.Play();
        }

        if (collision.gameObject.tag == "Board")
        {
            audioSource.clip = boardSound;
            audioSource.Play();
        }
    }
}
