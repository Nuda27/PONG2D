using System.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using Vector2 = UnityEngine.Vector2;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    Rigidbody2D rb;
    [Header ("Npc Setting")]
    public float speed;
    public float delayMove;
    
    private bool isMoveAI;
    private float randomPos;
    private bool isSingleTake;
    private bool isUp;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.instance.isSinglePlayer)
        {
            if (!isMoveAI && !isSingleTake)
            {
                Debug.Log("kepanggil");

                StartCoroutine("DelayAIMove");
                isSingleTake = true;
            }
            if(isMoveAI)
            {
                MoveAI();
            }
        }
    }

    private IEnumerator DelayAIMove()
    {
        yield return new WaitForSeconds(delayMove);
        randomPos = Random.Range(-1.5f, 1.5f);

        if(transform.position.y < randomPos)
        {
            isUp = true;
        }
        else 
        {
            isUp = false;
        }
        
        isSingleTake = false;
        isMoveAI = true;
    }

    private void MoveAI()
    {
        if (!isUp)
        {
            rb.velocity = new Vector2(0, -1) * speed;
            if(transform.position.y <= randomPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }

        if (isUp)
        {
            rb.velocity = new Vector2(0, 1) * speed;
            if(transform.position.y >= randomPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
    }
}
