using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controls player movement,
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rbody;
    Animator anim;

    ///PLayer facing direction.
    Vector2 lookDirection = new Vector2(1,0);

    // Start is called before the first frame update
    void Start()
    {
          rbody = GetComponent<Rigidbody2D>();
          anim  = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!InventoryUI.craftingOpen)
        {
            float moveX = Input.GetAxisRaw("Horizontal"); //Control with A, D. A = -1, D = +1.
            float moveY = Input.GetAxisRaw("Vertical"); //Control with W, S. W = +1, S = -1.

            Vector2 moveVector = new Vector2(moveX, moveY);
            if (moveVector.x != 0 || moveVector.y != 0)
            {
                lookDirection = moveVector;
            }

            //
            anim.SetFloat("Look X", lookDirection.x);
            anim.SetFloat("Look Y", lookDirection.y);
            anim.SetFloat("Speed", moveVector.sqrMagnitude);

            //Player movement.
            Vector2 position = rbody.position;
            //position.x += moveX * speed * Time.deltaTime;
            //position.y += moveY * speed * Time.deltaTime;
            position += moveVector * speed * Time.deltaTime;
            rbody.MovePosition(position);

            //anim.SetFloat("lookX", moveX);
            //anim.SetFloat("lookY", moveY);  
        }
    
    }
}
