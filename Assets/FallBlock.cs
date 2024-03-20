using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallBlock : MonoBehaviour
{
    private Rigidbody2D myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com o jogador (ou qualquer outro objeto com a tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Define o tipo do Rigidbody como "Dynamic"
            myRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    
}
