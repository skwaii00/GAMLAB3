using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SquareController : MonoBehaviour

{
    // Start is called before the first frame update
    public float timeRemaining = 30;
    public Text countdownText;
    public bool gameOver = false;
    public GameObject bulletPrefab;
    public float bulletSpeed = 8f;
    private Vector2 shootDirection;
    public float moveSpeed = 3f;
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
            transform.Translate(movement * 3f * Time.deltaTime);



            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                shootDirection = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                shootDirection = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                shootDirection = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                shootDirection = Vector2.down;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
            Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, moveDirection, out hit, 1.0f))
            {
                Renderer renderer = hit.collider.GetComponent<Renderer>();

                if (renderer != null && renderer.material.color == Color.black)
                {
                    transform.Translate(-moveDirection * moveSpeed * Time.deltaTime);
                }
            }
        }
    }
    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if (bulletRb != null)
        {

            bulletRb.velocity = shootDirection * bulletSpeed;
        }
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapEdge"))
        {
            Debug.Log("xxxxxx");
            Vector2 firstPosition = new Vector2(-8, 2);
            transform.position = firstPosition;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Circle"))
        {
            Debug.Log("xxxx");
            Vector2 firstPosition = new Vector2(-8, 2);
            transform.position = firstPosition;
        }
        if (collision.gameObject.tag.Equals("Pinwheel"))
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
