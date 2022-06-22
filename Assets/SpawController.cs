using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawController : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [SerializeField] Transform target;
    [SerializeField] float delayTime = 2f;
    [SerializeField] float delayMinTime = 2f;
    [SerializeField] float delayMaxTime = 2f;
    [SerializeField] float speedObj = 5f;
    private float time;

    [SerializeField] bool isRight;

    [SerializeField] Transform spawPointMin;
    [SerializeField] Transform spawPointMax;
    [SerializeField] Transform targetPointMin;
    [SerializeField] Transform targetPointMax;
    [SerializeField] bool isHorizontal;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > delayTime)
        {
            SpawObject();
            time = 0;
            delayTime = Random.Range(delayMinTime, delayMaxTime);
        }
    }

    void SpawObject()
    {
        int index = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[index]);
        
        obj.GetComponent<MovingController>().Settarget(GetRandomTarget());
        obj.GetComponent<MovingController>().UpdateSpeed(speedObj);


        if(isHorizontal)
        {
            float y = Random.Range(spawPointMin.position.y, spawPointMax.position.y);
            obj.transform.position = new Vector2(spawPointMin.position.x, y);
        }
        else
        {
            float x = Random.Range(spawPointMin.position.x, spawPointMax.position.x);
            obj.transform.position = new Vector2(x, spawPointMin.position.y);
        }
        
    }

    private Vector3 GetRandomTarget()
    {
        Vector3 result = Vector3.zero;
        if(targetPointMin.position.x == targetPointMax.position.x)
        {
            result = new Vector3(targetPointMin.position.x, Random.Range(targetPointMin.position.y, targetPointMax.position.y), 0);
        }
        else
        {
            result = new Vector3(Random.Range(targetPointMin.position.x, targetPointMax.position.x), targetPointMin.position.y, 0);
        }

        return result;
    }

    public void UpdateSpeed()
    {
        speedObj += 1;
    }
}
