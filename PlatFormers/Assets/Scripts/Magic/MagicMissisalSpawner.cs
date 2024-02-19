using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MagicMissisal : MonoBehaviour
{
    public GameObject Missile;
    private Vector2 spwanpoint;
    public GameObject Player;
    private GameObject afterspwan;
    public float cooldownTimerbase = 5;
    private float cooldownTime = 0;
    public float MoveDistance = 1;
    private Vector3 movePoint;
    public ProgressBar progress;
    List<GameObject> missileList = new List<GameObject>();
    GameObject[] targets;
    [SerializeField] public Animator ainimation;

    private void Start()
    {
        targets = GameObject.FindGameObjectsWithTag("enemy");
        progress.maxFill = cooldownTimerbase;
        rechecken();
    }

    void Update()
    {

        if (Missile != null)
        {
            targets = GameObject.FindGameObjectsWithTag("enemy");
            if (cooldownTime >= cooldownTimerbase &&  missileList.Count < targets.Length)
            {
        
                if (Input.GetKeyDown(KeyCode.J))
                {

                    ainimation.SetInteger("anima", 1);
                    spwanpoint.x = Player.transform.position.x;
                    spwanpoint.y = Player.transform.position.y + 4;
                    afterspwan = Instantiate(Missile, spwanpoint, Quaternion.identity);
                    missileList.Add(afterspwan);

                    cooldownTime = 0;
                    Invoke("SetWalking", 1);

                }
            }
            for (int g = 0; g < missileList.Count; g++)
            {


                MagicMissisalOperations op = missileList[g].GetComponent<MagicMissisalOperations>();


                if (op.closestObj == null)
                {
                    restraget(op);
                }
                if (op.dead)
                {
                    Destroy(missileList[g]);
                    missileList.RemoveAt(g);

                }
                if (op.dead == false)
                {
                    GameObject enemy = op.closestObj;
                    if (enemy != null)
                    {
                        movePoint = enemy.transform.position;
                        Rigidbody2D rb = missileList[g].GetComponent<Rigidbody2D>();
                        if (rb != null)
                        {
                            Vector2 newPosition = Vector2.MoveTowards(rb.position, movePoint, MoveDistance * Time.deltaTime);
                            rb.MovePosition(newPosition);
                        }
                    }
                }
            }



        }

        cooldownTime += Time.deltaTime;
        progress.currentFill = cooldownTime;

    }
    void restraget(MagicMissisalOperations op)
    {

        float detectionRadius = 100000.0f; 

        
        Vector2 missilePosition = op.transform.position;

        
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(missilePosition, detectionRadius);
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("enemy"))
            {
                float distance = Vector2.Distance(missilePosition, hitCollider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = hitCollider.gameObject;
                }
            }
        }

        if (closestEnemy != null)
        {
            op.closestObj = closestEnemy;
        }
        else
        {
            Debug.Log("No enemies found within detection radius.");
        }
    }

    void rechecken()
    {
        targets = GameObject.FindGameObjectsWithTag("enemy");
        Invoke("rechecken", 2f);
    }
    void SetWalking()
    {
        ainimation.SetInteger("anima", 0);
    }
}



