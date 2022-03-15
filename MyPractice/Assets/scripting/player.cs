using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    [SerializeField] private Transform CheckingGrounded = null;
    [SerializeField] private LayerMask palyerMask;
    private bool jumpkey;
    private float horizontalinput;
    private Rigidbody RigidibodyComponent;
    bool isgrounded;
    // Start is called before the first frame update
    void Start()
    {
        RigidibodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpkey = true;
        }
        horizontalinput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {

        RigidibodyComponent.velocity = new Vector3(0, RigidibodyComponent.velocity.y, horizontalinput);

        if (Physics.OverlapSphere(CheckingGrounded.position, 0.1f).Length == 1)
        {
            return;
        }

        if (jumpkey)
        {
            RigidibodyComponent.AddForce(Vector3.up * 7, ForceMode.VelocityChange);
            jumpkey = false;

        } }
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer==7)
        {
            Destroy(other.gameObject);
        }
      }

    }