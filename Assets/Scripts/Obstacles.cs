using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float speed;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
       // Vector3 Target=new Vector3(transform.position.x,transform.position.y-1,transform.position.z);
       // transform.position=Vector3.MoveTowards(transform.position,Target,speed*Time.deltaTime);
        if(transform.position.y <= -7) Destroy(gameObject);
    }
    
    
     

}
