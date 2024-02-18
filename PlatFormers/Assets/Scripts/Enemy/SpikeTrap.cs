using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject trapTarget;
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collistion = collision.gameObject;
        if (collistion.CompareTag("Player"))
        {
            Debug.Log("daddy");
            PlayerHealth health =  player.GetComponent<PlayerHealth>();
            health.health -= 1;
            player.transform.position = trapTarget.transform.position;
        }
    }
}
