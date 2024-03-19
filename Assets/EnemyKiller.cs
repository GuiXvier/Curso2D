using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKiller : MonoBehaviour
{
    private bool isGrounded = false;
    public Transform GroundCheck1; 
    public LayerMask ground_layers;
    private Animator enemyAnimator;
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.gameObject;
        var enemyScript = enemy.GetComponent<EnemyPatrol>();
        enemyAnimator = enemy.GetComponent<Animator>();

        if (other.gameObject.CompareTag("Enemy") && !IsGrounded())
        {
            enemyAnimator.SetTrigger("Die");
            enemyScript.speed = 0f;
            StartCoroutine(DestroyObject(enemy));
        }
        else if (other.gameObject.CompareTag("Enemy") && IsGrounded())
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    private bool IsGrounded()
    {
        return isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 1, ground_layers);
    }

    IEnumerator DestroyObject(GameObject destroyMe)
    {
        yield return new WaitForSeconds(3f); // Espera por 3 segundos
        Destroy(destroyMe);
    }
}