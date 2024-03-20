using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().enabled = false;
    }

    // Método chamado quando o Collider2D do jogador entra em colisão com este objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se a colisão foi com o jogador (ou qualquer outro objeto com a tag "Player")
        if (collision.gameObject.CompareTag("Player"))
        {
            // Ativa o Renderer do objeto para torná-lo visível
            GetComponent<Renderer>().enabled = true;
            SceneManager.LoadScene("SampleScene");
        }
    }
}
