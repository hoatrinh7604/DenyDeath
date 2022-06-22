using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private Vector3 target;

    private ObjectController objController;
    [SerializeField] Rigidbody2D rig;

    // Start is called before the first frame update
    void Start()
    {
        objController = GetComponent<ObjectController>();
        int x = Random.Range(4, 7) * 100;
        int dirX = Random.Range(0, 2);
        int dirY = Random.Range(0, 2);
        rig.AddForce(new Vector2(x*(dirX==0?1:-1), x * (dirY == 0 ? 1 : -1)));
    }

    // Update is called once per frame
    void LateUpdate()
    {

    }

    public void Settarget(Vector3 target)
    {
        this.target = target;
    }

    public void Escape()
    {
        if(GetComponent<ObjectController>().IsEnemy())
            GameController.Instance.UpdateSlider(1);
    }

    public void UpdateSpeed(float value)
    {
        speed = value;
    }
}
