using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void PlayButton()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }

}

