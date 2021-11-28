using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class accelarator : MonoBehaviour
{
    Rigidbody2D rgb;
    public float ballSpeed;
    // for ball
    float posX, posY;
    //for coin
    float posXcoin, posYcoin;
    public GameObject coin;

    public static int Score;
    public TextMeshProUGUI score_Text;


    void Start()
    {

        rgb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        score_Text.text = "Score: " + Score.ToString();
        posX = Input.acceleration.x * ballSpeed;
        posY = Input.acceleration.y * ballSpeed;
    }

    void FixedUpdate(){
        rgb.velocity= new Vector2(rgb.velocity.x + posX, rgb.velocity.y + posY);
    }

    void OnTriggerEnter2D(Collider2D col){
        posXcoin = Random.Range(-13f,8f);
        posYcoin = Random.Range(-4.8f,4.8f);

        if(col.gameObject.tag=="coin"){
            Score+=5;
            Instantiate(coin, new Vector2(posXcoin,posYcoin), coin.transform.rotation);
            Destroy(col.gameObject);
        }
    
    }   
}
