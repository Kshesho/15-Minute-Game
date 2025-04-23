using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
   public GameObject bullet;
    int spawnInt, score;
    static int highScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector2(h, v) * 5 * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -9, 9),
            Mathf.Clamp(transform.position.y, -4.5f, 5.5f));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (spawnInt)
            {
                case 0:
                    Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0));
                    break;
                case 1:
                    Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, -90));
                    break;
                case 2:
                    Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 90));
                    break;
                case 3:
                    Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 180));
                    break;
            }
            spawnInt++;
            if (spawnInt > 3)
            {
                spawnInt = 0;
            }

            score++;
            if (score > highScore)
            {
                highScore = score;
                scoreText.text = "High Score: " + highScore;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
