using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    public float moveDuration1 = 2f; // The duration of each move in seconds
    public float moveSpeed = 1f; // The speed of the movement
    public int numMoves = 3; // The number of random moves to make
    public float timeBetweenMoves = 1f; // The time between each move in seconds



    public float wiggleDuration = 1f; // The duration of the wiggle in seconds
    public float wiggleIntensity = 0.1f; // The intensity of the wiggle
    public float moveAmount = 1f; // The amount to move the object down
    public float moveDuration = 1f; // The duration of the move in seconds

    public bool isMoving = true;
    public bool isAttacking = false;

    public Sprite angry;
    public Sprite normal;

    private Vector2 startPos;

    private void Start()
    {
        startPos = transform.position;
        StartCoroutine(MoveRandomly());
    }

    private IEnumerator MoveRandomly()
    {
        while (isMoving)
        {
            // Move randomly
            for (int i = 0; i < numMoves; i++)
            {
                Vector3 randomDirection = Random.insideUnitCircle.normalized;
                Vector3 targetPos = transform.position + randomDirection * moveSpeed * moveDuration1;
                float elapsedTime = 0f;
                while (elapsedTime < moveDuration1)
                {
                    transform.position = Vector2.Lerp(transform.position, targetPos, elapsedTime / moveDuration1);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }
                yield return new WaitForSeconds(timeBetweenMoves);
            }

            // Return to starting position
            float returnDuration = Vector2.Distance(transform.position, startPos) / moveSpeed;
            float returnElapsedTime = 0f;
            while (returnElapsedTime < returnDuration)
            {
                transform.position = Vector2.Lerp(transform.position, startPos, returnElapsedTime / returnDuration);
                returnElapsedTime += Time.deltaTime;
                yield return null;
            }

            // Wait before starting again
            yield return new WaitForSeconds(timeBetweenMoves);

            isMoving = false;
            isAttacking = true;
            StartCoroutine(WiggleAndMove());

        }
    }




    private IEnumerator WiggleAndMove()
    {
        while (isAttacking)
        {

            GetComponent<SpriteRenderer>().sprite = angry;

            // Wiggle
            float elapsedTime = 0f;
            Vector2 startingPos = transform.position;
            while (elapsedTime < wiggleDuration)
            {
                float x = startingPos.x + Random.Range(-wiggleIntensity, wiggleIntensity);
                float y = startingPos.y + Random.Range(-wiggleIntensity, wiggleIntensity);
                transform.position = new Vector2(x, y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }



            // Move down
            elapsedTime = 0f;
            while (elapsedTime < moveDuration)
            {
                float y = transform.position.y - moveAmount * Time.deltaTime;
                transform.position = new Vector2(transform.position.x, y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Move back up to starting position
            elapsedTime = 0f;
            while (elapsedTime < moveDuration)
            {
                float y = Mathf.Lerp(transform.position.y, startPos.y, elapsedTime / moveDuration);
                transform.position = new Vector2(transform.position.x, y);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            GetComponent<SpriteRenderer>().sprite = normal;
            isMoving = true;
            isAttacking = false;
            StartCoroutine(MoveRandomly());
            // Go back to wiggling
        }
    }
}
