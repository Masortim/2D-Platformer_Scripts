using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    public float moveSpped;
    private bool canMove;

    private Rigidbody2D myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            myRigidBody.velocity = new Vector3(-moveSpped, myRigidBody.velocity.y, 0f);
        }
    }

    void OnBecameVisible()
    {
        canMove = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            //Destroy(gameObject);

            gameObject.SetActive(false);
        }
    }

    void OnEnable()
    {
        canMove = false;
    }
}
