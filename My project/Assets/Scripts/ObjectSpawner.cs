using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class ObjectSpawner : MonoBehaviour
{

    float cameraHeight;
    float cameraWidth;

    [SerializeField]
    GameObject objectToTeleport;

    GameObject objectToSpawnPrefab;
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        cameraHeight = cam.orthographicSize * 2f;
        cameraWidth = cameraHeight  * cam.aspect;

        TeleportObject();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            TeleportObject();
        }
    }


    void InstantiateObjectToSpawn()
    {

        Vector2 cameraBottomLeft = GetCameraBoundaries();
        Vector2 randomPosition = RandomSpawnPosition(cameraBottomLeft, cameraHeight, cameraWidth);

        objectToTeleport = Instantiate(objectToSpawnPrefab, randomPosition, Quaternion.identity);
    }
    public void TeleportObject()
    {

        if(objectToTeleport != null)
        {
            Vector2 cameraBottomLeft = GetCameraBoundaries();
            Vector2 randomPosition = RandomSpawnPosition(cameraBottomLeft, cameraHeight, cameraWidth);

            objectToTeleport.transform.position = randomPosition;
        }

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

        Collider2D[] colliders = Physics2D.OverlapPointAll(position);

        foreach (Collider2D collider in colliders)
        {
            if (collider != null && collider.gameObject != objectToTeleport)
            {
                Debug.Log("Destination invalid");
                return false;
            }

        }

        return true;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TeleportObject();
        }
    }

}
