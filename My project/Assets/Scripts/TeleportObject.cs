using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class TeleportObject : MonoBehaviour
{

    float cameraHeight;
    float cameraWidth;

    Camera cam;


    private void Awake()
    {
        cam = Camera.main;
    }

    private void Start()
    {
        cameraHeight = cam.orthographicSize * 2f;
        cameraWidth = cameraHeight * cam.aspect;

        Teleport();
    }

    Vector2 GetCameraBoundaries()
    {
        Vector2 cameraBottomLeft = (Vector2)cam.transform.position - new Vector2(cameraWidth / 2f, cameraHeight / 2f);
        return cameraBottomLeft;
    }
    Vector2 RandomSpawnPosition(Vector2 cameraBottomLeft, float cameraHeight, float cameraWidth)
    {
        Vector2 randomPosition;

        do
        {
            randomPosition = new Vector2(
            Random.Range(cameraBottomLeft.x, cameraBottomLeft.x + cameraWidth),
            Random.Range(cameraBottomLeft.y, cameraBottomLeft.y + cameraHeight)
            );

        } while (!IsDesinationValid(randomPosition));

        return randomPosition;
    }

    bool IsDesinationValid(Vector2 position)
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, (this.gameObject.transform.localScale.y / 2));

        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.gameObject != this.gameObject)
            {
                Debug.Log("Destination invalid");
                return false;
            }

        }

        return true;

    }
    public void Teleport()
    {

        if (this.gameObject != null)
        {
            Vector2 cameraBottomLeft = GetCameraBoundaries();
            Vector2 randomPosition = RandomSpawnPosition(cameraBottomLeft, cameraHeight, cameraWidth);

            this.gameObject.transform.position = randomPosition;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Teleport();
        }
    }

}
