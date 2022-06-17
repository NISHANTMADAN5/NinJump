using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    

    // Start is called before the first frame update

    [SerializeField]
    float speed;
    float direction = 1;
    [SerializeField]
    float maxx;
    public Animator animator;
    public bool grounded=true;
    
    public bool canMove=true;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetFloat("position",transform.position.x);
        animator.SetBool("isjumping",!grounded);
        if(Mathf.Abs(transform.position.x)>=1.38)
        {
            grounded=true;
        }
        else{
            grounded=false;
        }
        if(Input.GetButtonDown("Jump") && grounded && canMove)
        {
            
            //transform.position=Vector3.MoveTowards(transform.position,Target,speed*Time.deltaTime);
            direction*=-1;
            
        }

        
        Vector3 Target=new Vector3(Mathf.Clamp(transform.position.x,-maxx,maxx)+direction,transform.position.y,transform.position.z);

             
        transform.position=Vector3.MoveTowards(transform.position,Target,speed*Time.deltaTime);

    }
    
    void OnTriggerEnter2D(Collider2D colliider) {
       if(colliider.gameObject.tag =="Items")
       {
           //Destroy(colliider.gameObject);
           //GameManager.instance.IncrementScore();
           //increase the score
           

       } 
       else if(colliider.gameObject.tag =="Obstacles")
       {
           
           //GameManager.instance.DecreaseLives();
           //Decrease the lives
           GameManager.instance.DecreaseLives();
       } 
    }
    
}
