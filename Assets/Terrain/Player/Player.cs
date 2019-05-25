using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour {

    public float speed = 3;
    public Rigidbody rigidbody;
    public float jumpForce = 5;
    public bool isGrounded;
    public Color rayColor;
    public Camera eyes;

    public float lookHorizontal = 0f;
    public float lookVertical;

    public GameObject bluePortalPrefab;
    public GameObject orangePortalPrefab;

   


    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (transform.right * -1 * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position +(transform.right * Time.deltaTime * speed);
        }


        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * Time.deltaTime * speed);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (transform.forward * Time.deltaTime * speed);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

        lookHorizontal += Input.GetAxis("Mouse X");
        lookVertical += Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(-lookVertical, lookHorizontal, 0f);

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray();
            ray.origin = eyes.transform.position;
            ray.direction = eyes.transform.forward;
            Debug.DrawRay(ray.origin, ray.direction * 100f, rayColor, 10f);

            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Debug.LogError(" Ray hit! Object: " + hit.transform.name + " Position: " + hit.point);
                Quaternion portalRotation = Quaternion.LookRotation(this.transform.position - hit.point, hit.normal);
                     //Quaternion.LookRotation(hit.normal, Vector3.up);
                Instantiate(orangePortalPrefab, hit.point, portalRotation);
            }


        }
    }
}
