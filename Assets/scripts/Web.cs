using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    private TrailRenderer trailRenderer;
    private Collider2D trailCollider;
    float moveSpeedToReturn;

    private void Start()
    {
        // Get the TrailRenderer component
        trailRenderer = GetComponent<TrailRenderer>();

        // Create a child GameObject and attach the Collider2D component to it
        GameObject colliderObject = new GameObject("Trail Collider");
        colliderObject.transform.SetParent(transform);
        colliderObject.transform.localPosition = Vector3.zero;
        trailCollider = colliderObject.AddComponent<PolygonCollider2D>();

        // Set the Collider2D to be a trigger
        trailCollider.isTrigger = true;

        // Set the points of the Collider2D to match the points of the TrailRenderer
        UpdateColliderPoints();
    }

    private void Update()
    {
        // Update the points of the Collider2D every frame (in case the TrailRenderer has changed)
        UpdateColliderPoints();
    }

    private void UpdateColliderPoints()
    {
        // Get the points of the TrailRenderer and set them as the points of the Collider2D
        Vector3[] trailPoints = new Vector3[trailRenderer.positionCount];
        trailRenderer.GetPositions(trailPoints);
        Vector2[] colliderPoints = new Vector2[trailRenderer.positionCount];
        for (int i = 0; i < trailRenderer.positionCount; i++)
        {
            colliderPoints[i] = trailPoints[i];
        }
        ((PolygonCollider2D)trailCollider).SetPath(0, colliderPoints);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<PlayerMov>() != null)
        {
            moveSpeedToReturn = other.GetComponent<PlayerMov>().moveSpeed;
            if (other.GetComponent<PlayerMov>().moveSpeed != 3)
            {
                other.GetComponent<PlayerMov>().moveSpeed = 3;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMov>() != null)
        {
             other.GetComponent<PlayerMov>().moveSpeed = moveSpeedToReturn;

        }
    }

}
