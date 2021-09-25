using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class BallsManager : MonoBehaviour
{
    #region Singleton

    private static BallsManager _instance;

    public static BallsManager Instance => _instance;

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
    [SerializeField]
    private Ball ballPrefab;
    private Ball initialBall;
    private Rigidbody2D initialBallRb;
    public float initialBallSpeed = 250;
    public List<Ball> Balls { get; set; }
    private void Start()
    {
        InitBall();
    }
    private void Update()
    {
        if (!GameManager.Instance.IsGameStarted)
        {
            // Align ball position to the paddle position
            Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
            Vector3 ballPosition = new Vector3(paddlePosition.x, paddlePosition.y + .27f, 0);
            initialBall.transform.position = ballPosition;
        }
        if (Input.GetMouseButtonDown(0))
        {
            initialBallRb.isKinematic = false;
            initialBallRb.AddForce(new Vector2(0, initialBallSpeed));
            GameManager.Instance.IsGameStarted = true;
        }
    }

    private void InitBall()
    {
        Vector3 paddlePosition = Paddle.Instance.gameObject.transform.position;
        Vector3 startingPosition = new Vector3(paddlePosition.x, paddlePosition.y + .27f, 0);
        initialBall = Instantiate(ballPrefab, startingPosition, Quaternion.identity);
        initialBallRb = initialBall.GetComponent<Rigidbody2D>();

        this.Balls = new List<Ball>
        {
            initialBall
        };

    }

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
            case "Brick (2)":
                Score.scoreAmount += 3;
                Destroy(collision.gameObject);
                break;
        }
    }

    
}

