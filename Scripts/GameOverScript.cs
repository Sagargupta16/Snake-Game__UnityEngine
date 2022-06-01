using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{


    public Text pointsText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score "+ score.ToString();
    }

    public void RestartButton()
    {

        SceneManager.LoadScene("snake game");
    }
    public void QuitButton()
    {
        Application.Quit();
    }

}
