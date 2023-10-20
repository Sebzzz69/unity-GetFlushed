using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    CharacterMovement characterMovement;
    Vector2 spawnPosition;
    float respawnTime;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        characterMovement = GetComponent<CharacterMovement>();

        spawnPosition = transform.position;
        respawnTime = 0.8f;
    }

    IEnumerator Respawn()
    {
        spriteRenderer.enabled = false;
        characterMovement.enabled = false;
        transform.position = spawnPosition;

        yield return new WaitForSeconds(respawnTime);

        spriteRenderer.enabled = true;
        characterMovement.enabled = true;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("OutOfBounds"))
            StartCoroutine(Respawn());
            
    }
}
