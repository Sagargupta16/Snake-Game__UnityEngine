using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class SpawnFood : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public Slider foodGenerationSpeed;

    [SerializeField] public Text foodGenerationValue;



    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;

    public GameObject foodPrefab;

    public float foodspawnspeed = 6.00f ;
    void Start()
    {
        Spawn();
        
        foodGenerationSpeed.onValueChanged.AddListener((q) => {
            CancelInvoke();
            InvokeRepeating("Spawn", q, q);
            foodGenerationValue.text = (10.00f-q).ToString("0.00");
        });
        InvokeRepeating("Spawn",foodspawnspeed,foodspawnspeed );
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        // x position between left & right border
        int x = (int)Random.Range(borderLeft.position.x+2,
                                  borderRight.position.x-2);

        // y position between top & bottom border
        int y = (int)Random.Range(borderBottom.position.y+2,
                                  borderTop.position.y-2);

        // Instantiate the food at (x, y)
        Instantiate(foodPrefab,
                    new Vector2(x, y),
                    Quaternion.identity); // default rotation
    }

}

