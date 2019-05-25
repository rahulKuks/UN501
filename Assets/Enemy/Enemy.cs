using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    private Player player;
    public float speed;
    public float attackForce = 10f;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();
        if(player == null)
        {
            Debug.LogError("Cannot find player! Error!");
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        transform.LookAt(player.transform);
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rigidbody = player.GetComponent<Rigidbody>();
            rigidbody.AddForce(attackForce * transform.forward, ForceMode.Impulse);
        }
    }
}
