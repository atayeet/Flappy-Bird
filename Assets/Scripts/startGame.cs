using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public bool isDead; // default hali false

    public Rigidbody2D rb2D;

    bool isGameStarted = false;

    public GameObject TapToFlap;

    public GameObject DeathScreen;


    private void Start()
    {
        rb2D.gravityScale = 0;
        Time.timeScale = 1;
    }

    void StartGame()
    {
        isGameStarted = true;
        rb2D.gravityScale = 1; // Yerçekimini aktif et
    }
    void Update()
    {
        if (!isGameStarted && Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) // Ýlk týklama
        {
            StartGame();
            TapToFlap.SetActive(false);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "DeathArea")
        {
            isDead = true;
            Time.timeScale = 0;

            DeathScreen.SetActive(true);
            TapToFlap.SetActive(false);
        }
    }
}
