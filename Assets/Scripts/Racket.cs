// using System.Transactions;
// using System.Threading.Tasks.Dataflow;
// using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public string axis = "Vertical";
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == "Vertical2" && GameData.instance.isSinglePlayer)
        {
            return;
        }

        float v = Input.GetAxis(axis);
        rb.velocity =  new Vector2(0, v) * speed;

        if (transform.position.y > 1.5f)
        {
            transform.position = new Vector2(transform.position.x, 1.5f);
        }

        if (transform.position.y < -1.5f)
        {
            transform.position = new Vector2(transform.position.x, -1.5f);
        }
    }

    private void OnCollisionEnter2D(Collision2D coll) 
    {
        if(coll.gameObject.tag == "Ball")
        {
            anim.SetTrigger("Shoot");
            anim.SetTrigger("ShootBlue");
        }
    }
}
