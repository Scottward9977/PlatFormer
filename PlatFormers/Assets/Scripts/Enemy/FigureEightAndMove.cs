using UnityEngine;

public class FigureEightAndMove : MonoBehaviour
{
    public float loopSpeed = 2f;
    public float moveSpeed = 5f; 
    public Vector2 targetPosition;
    public Transform playerTransform;
    private Vector2 startPosition; 
    private bool movingToTarget = false;
    private bool returningToStart = false; 
    private float timeCounter = 0f;
    private bool iSeePlayer = false;


    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        Vector2 directionToPlayer = Vector3.Normalize(playerTransform.position - transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer);
        Debug.DrawLine(transform.position, playerTransform.position);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                
                if(distance < 10)
                {
                    iSeePlayer = true;
                }

            } else
            {
                iSeePlayer = false;
            }
        }
        if (!movingToTarget && !returningToStart)
        {
            timeCounter += Time.deltaTime * loopSpeed;

            float x = Mathf.Sin(timeCounter) * 3f;
            float y = Mathf.Sin(timeCounter) * Mathf.Cos(timeCounter) * 2f;
            transform.position = new Vector2(startPosition.x + x, startPosition.y + y);

            //check ready to move
            if (timeCounter >= Mathf.PI * 2) // time of one cycle
            {
                if(iSeePlayer == true)
                {
                    timeCounter = 0f;
                    movingToTarget = true;
                    targetPosition = playerTransform.position;
                }
            }
        }
        else if (movingToTarget)
        { 
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if ((Vector2)transform.position == targetPosition)
            {
                movingToTarget = false;
                returningToStart = true;
            }
        }
        else if (returningToStart)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPosition, moveSpeed * Time.deltaTime);
            if ((Vector2)transform.position == startPosition)
            {
                returningToStart = false;
            }
        }
    }
}
