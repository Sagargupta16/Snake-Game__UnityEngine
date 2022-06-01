using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Snake : MonoBehaviour
{
    [SerializeField] private Slider snakeSpeedSlider;

    [SerializeField] private Text snakeSpeedValue;
    //Tail Prefab
    public GameObject tailPrefab;
    public GameOverScript GameOverScript;

    //Tail List
    List<Transform> tail = new List<Transform>();


    //Snake Movement
    Vector2 dir;

    bool ate = false;
    Vector2 a;

    public float SnakeMovementSpeed = 0.06f;

    void Start()
    {

        dir = Vector2.right;

        ScoreScript.scoreValue = 0;
        snakeSpeedSlider.onValueChanged.AddListener((q) =>
        {
            CancelInvoke();
            InvokeRepeating("Move", 0.06f, q);

            snakeSpeedValue.text = ((0.10f-q)*100).ToString("0.00");
        });
        InvokeRepeating("Move", 0.06f, SnakeMovementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (dir != Vector2.left)
                dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (dir != Vector2.right)
                dir = Vector2.left;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (dir != Vector2.down)
                dir = Vector2.up;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (dir != Vector2.up)
                dir = Vector2.down;
        }

    }

    void Move()
    {
        //Movement of snake
        this.transform.Translate(dir);

        //Tail Position
        Vector2 v = this.transform.position;


        if (ate) //if Snake eats something
        {
                GameObject g = Instantiate(tailPrefab, a, Quaternion.identity);
                tail.Insert(0, g.transform);
                Debug.Log("Snake ate the food");
                ate = false;
            // Add the List
            
        }
        else if (tail.Count >0)
        {
            
            // Move last Tail Element to where the Head was
            tail.Last().position = a;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1); 
        }
        a = v;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Some Collision");

        //food
        if (collision.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            //Destry it
            SoundManager.PlaySound("ding");
            ScoreScript.scoreValue += 1;
            Destroy(collision.gameObject);
        }
        else if (collision.name.StartsWith("border") || collision.tag.StartsWith("Obstacle"))
        {
            SoundManager.PlaySound("gameover");
            Destroy(gameObject);
            GameOverScript.Setup(ScoreScript.scoreValue);
        }
    }

}
