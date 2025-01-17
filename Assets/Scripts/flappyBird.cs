using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class flappyBird : MonoBehaviour
{
    public bool isDead; // default hali false

    public float velocity = 1f;

    public Rigidbody2D rb2D;

    public GameManager gameManager;

    public GameObject DeathScreen;

    void Flap()
    {
        // Havada kuþu sýçrat
        rb2D.velocity = Vector2.up * velocity;

    }

    void Update()
    {
        // rb2D = GetComponent<Rigidbody2D>(); (Rigidbody2D'nin önüne public yazmak yerine yapýlabilir)

        // Týklamayý al
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            Flap();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;

            DeathScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ScoreArea")
        {
            gameManager.UpdateScore();
        }
    }
}
