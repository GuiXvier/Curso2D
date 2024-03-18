using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;  // O primeiro ponto de patrulha
    public GameObject pointB;  // O segundo ponto de patrulha
    private Rigidbody2D rb;    // Referência ao componente Rigidbody2D do inimigo
    private Transform currentPoint;  // O ponto de patrulha atual para o inimigo
    public float speed;     // Velocidade de movimento do inimigo

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtém o componente Rigidbody2D do inimigo
        currentPoint = pointB.transform;    // Define o ponto inicial de patrulha como o ponto B
    }

    // Update is called once per frame
    void Update()
    {
        // Calcula o vetor em direção ao ponto de patrulha atual
        Vector2 point = currentPoint.position - transform.position;

        // Move o inimigo na direção do ponto de patrulha atual com base na velocidade
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0); // Move para a direita
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0); // Move para a esquerda
        }

        // Verifica se o inimigo alcançou o ponto de patrulha atual e altera para o próximo ponto
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip(); // Inverte a direção do inimigo
            currentPoint = pointA.transform; // Altera para o ponto A
        }

        // Verifica se o inimigo alcançou o ponto de patrulha atual e altera para o próximo ponto
        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip(); // Inverte a direção do inimigo
            currentPoint = pointB.transform; // Altera para o ponto B
        }
    }

    // Inverte a direção do inimigo
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1; // Inverte o valor da escala x para inverter a direção
        transform.localScale = localScale;
    }

    // Desenha gizmos para representar visualmente os pontos de patrulha e a rota
    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f); // Desenha uma esfera para o ponto A
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f); // Desenha uma esfera para o ponto B
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position); // Desenha uma linha entre os pontos A e B
    }
}

