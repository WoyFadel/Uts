using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    private static GameManager _instance;
    public static GameManager Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);

        }
        else
        {
            _instance = this;
        }

    }

    #endregion



    public bool IsGameStarted { get; set; }

    public GameObject scoreText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.name)
        {
            case "Brick":
                Score.scoreAmount += 1;
                Destroy(collision.gameObject);
                break;
            case "Brick (1)":
                Score.scoreAmount += 2;
                Destroy(collision.gameObject);
                break;
            case "Brick ()":
                Score.scoreAmount += 2;
                Destroy(collision.gameObject);
                break;
        }
    }
}
