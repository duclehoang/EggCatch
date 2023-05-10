using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class egg : MonoBehaviour
{
    // Start is called before the first frame update
    private float breakpoint=-6f;
    GameManager gameManager;
     Rigidbody2D rb;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
       //rb.gravityScale=2;
        rb.interpolation = RigidbodyInterpolation2D.None;
         
        gameManager=FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<breakpoint){
            gameManager.gameOver1();
            Destroy(gameObject);
        }
    }

 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("InsideBasket")){
                gameManager.addScroredEgg();
                Destroy(gameObject);
        }
    }
}
