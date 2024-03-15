using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    // each characters moves 1 pixel to line up with grid in game
    // Start is called before the first frame update
    public float movespeed;
    public LayerMask layer_struct;
    private bool isMoving;
    private Vector2 input; 
    private Animator animator;

    private void Awake(){
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving){
            input.x = Input.GetAxisRaw("Horizontal"); // values for this is 1 or -1 which signify left/right
            input.y = Input.GetAxisRaw("Vertical"); // values for this is 1 or -1 which signify up/down

            // remove diagonal movement
            if (input.x !=0) {
                input.y = 0; 
            }

            if(input != Vector2.zero){
                //animator portion
                animator.SetFloat("moveX", input.x); // set input to the movex and movey in blendtree
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position; // curr pos of player
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(canWalk(targetPos)){
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        //set animator to tell if walk or not
        animator.SetBool("isMoving",isMoving);
    }


    IEnumerator Move(Vector3 targetPos){
        
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position,targetPos, movespeed * Time.deltaTime); 
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    //collison detection
    private bool canWalk(Vector3 targetPos){
       if(Physics2D.OverlapCircle(targetPos,0.2f,layer_struct) != null){
            // if passes, solid object in place
            return false;
       }
       return true;
    }
}
