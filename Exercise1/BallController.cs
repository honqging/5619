using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// We’ll attach this script to the *Ball* object
public class BallController : MonoBehaviour
{
    // Instance variables
    // ‘public‘ ones will be accessible via the Unity interface
    // Represents the controller position (the same one that the board is
    // attached to)
    public TextMesh scoreText;
    public AudioClip collectClip;
    public AudioSource collectSource;

    public AudioClip winClip;
    public AudioSource winSource;

    private int count = 0;

    // Use this for initialization
    void Start()
    {
        collectSource.clip = collectClip;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            scoreText.text = "You have scored:" + count;
            if(count < 7)
            {
                collectSource.Play();
            }

            if (count == 7)
            {
                scoreText.text = "You win!";

                winSource.clip = winClip;
                winSource.Play();
            }
        }
    }
}