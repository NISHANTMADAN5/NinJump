using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public static ObstSpawn instance;
     public GameObject obstacles;
     
     [SerializeField]
    float maxx=6.5f;
    [SerializeField]
    float SpawnInterval;
    private void Awake() {
       
        if(instance==null)
        {
            instance=this;
        }
    }
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void Spawn()
    {
         int rand = Random.Range(0,2);
        float v ;
        if (rand ==1)
        {
            v= maxx;
        }
        else
        {
            v=-maxx;
        }
        Vector3 randomPos= new Vector3(v,transform.position.y,0);
        Instantiate(obstacles,randomPos,transform.rotation);
    }

    IEnumerator SpawnObstacles()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    public void StartSpawning()
    {
        StartCoroutine("SpawnObstacles");
    }
    public void StopSpawning()
    {
        StopCoroutine("SpawnObstacles");
    }

}
