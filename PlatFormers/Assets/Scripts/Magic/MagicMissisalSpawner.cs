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
    public PlayerMov mov;
    private GameObject afterspwan;
    public float cooldownTimerbase = 5;
    private float cooldownTime = 0;
    public float MoveDistance = 1;
    private Vector3 movePoint;
    public ProgressBar progress;
    List<GameObject> missileList = new List<GameObject>();
    GameObject[] targets;
    [SerializeField] public Animator anima;

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
            if (cooldownTime >= cooldownTimerbase && targets != null)
            {
                if (Input.GetKeyDown(KeyCode.J))
                {

                    anima.SetInteger("anima" ,1);
                    spwanpoint.x = Player.transform.position.x;
                    spwanpoint.y = Player.transform.position.y + 4;
                    afterspwan = Instantiate(Missile, spwanpoint, Quaternion.identity);
                    missileList.Add(afterspwan);

                    cooldownTime = 0;

                }
            }
            for (int g = 0; g < missileList.Count; g++)
            {


                MagicMissisalOperations op = missileList[g].GetComponent<MagicMissisalOperations>();


                if (op.closestObj == null)
                {
                    Debug.Log("Target Set called");
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


        if (targets.Length > 0)
        {
            int randomIndex = Random.Range(0, targets.Length);


            GameObject randomEnemy = targets[randomIndex];


            op.closestObj = randomEnemy;
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
}



