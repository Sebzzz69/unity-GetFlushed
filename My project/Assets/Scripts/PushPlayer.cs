using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    [SerializeField] float pushForce;

    [SerializeField] KeyCode pushKey;

    [SerializeField] float pushCooldown = 0.5f;

    private bool canPush;
    private float lastPushTime;


    private void Start()
    {
        canPush = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(pushKey) && canPush)
        {
            TryPush();
        }
    }

    private void Update()
    {
        if (!canPush && Time.time - lastPushTime >= pushCooldown)
        {
            canPush = true;
        }
    }

    void TryPush()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(new Vector2(transform.localPosition.x + (transform.localScale.x / 2), transform.localPosition.y), 0.5f, LayerMask.GetMask("Player"));

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != this.gameObject)
            {
                Rigidbody2D otherRb = collider.GetComponent<Rigidbody2D>();

                if (otherRb != null)
                {
                    Vector2 pushDirection = (collider.transform.position - transform.position).normalized;
                    //otherRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);

                    StartCoroutine(ApplyPushForceSmoothly(otherRb, pushDirection));
                    canPush = false;

                    /*Debug.Log("Pushed " + otherRb.gameObject.name);
                    Debug.Log(pushDirection * pushForce);*/
                }
            }
        }
    }

    IEnumerator ApplyPushForceSmoothly(Rigidbody2D rb, Vector2 pushDirection)
    {
        float duration = 0.2f;
        float elapsed = 0f;

        while(elapsed < duration)
        {
            rb.AddForce(pushDirection * (pushForce / duration), ForceMode2D.Force);
            elapsed += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    private void OnDrawGizmos()
    {
        float radius = 0.5f;
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(new Vector3(transform.localPosition.x + (transform.localScale.x / 2), transform.localPosition.y), radius);
    }


}

