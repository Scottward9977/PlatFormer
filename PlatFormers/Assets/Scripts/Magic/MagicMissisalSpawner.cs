using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MagicMissisal : MonoBehaviour
{
    //all of the script was writen but Scott
    // scritp hands the operation of chossing the bullets and moves them towards there target 
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
            // limits the number of bullets in the sence to the number of tagets in range 
            if (cooldownTime >= cooldownTimerbase &&  missileList.Count < targets.Length)
            {
        
                if (Input.GetKeyDown(KeyCode.J))
                {
                    //spawns the enemy on key press and added it to the list  
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
                        // moves the bullet towards the target enamy 
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
        
        // determans the closest target to the bullet and then sets it as the destnation target 
        targets = GameObject.FindGameObjectsWithTag("enemy");

        
        if (targets.Length > 0)
        {
            GameObject closestEnemy = null;
            float closestDistance = Mathf.Infinity;
            Vector2 missilePosition = op.transform.position;

 
            foreach (GameObject target in targets)
            {
                float distance = Vector2.Distance(missilePosition, target.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = target;
                }
            }

          
            if (closestEnemy != null)
            {
                op.closestObj = closestEnemy;
            }
        }
        else
        {
            Debug.Log("No enemies found.");
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



