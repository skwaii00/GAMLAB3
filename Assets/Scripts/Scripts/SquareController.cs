using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SquareController : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
    public Text countdownText;
    public bool gameOver = false;
    void Start()
    {
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (timeRemaining > 0 && !gameOver)
        {
            yield return new WaitForSeconds(1);
            timeRemaining--;
            countdownText.text = "Time: " + timeRemaining.ToString();
        }
        if (!gameOver)
        {
            countdownText.text = "Game Over!";
            GameOver();
        }
    }
    void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
    }
    // Update is called once per frame
    void Update()

    {
        if (!gameOver)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 movement = new Vector3(horizontal, vertical, 0f).normalized;
            transform.Translate(movement * 5f * Time.deltaTime);
        }
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            Debug.Log("xxxx");
            Vector2 firstPosition = new Vector2(-8, 2);
            transform.position = firstPosition;
        }
        if (collision.gameObject.name.Equals("Box"))
        {
            Debug.Log("Win");
            LoadNextScene();
        }
    }
}
