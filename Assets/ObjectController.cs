using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    [SerializeField] bool isEnemy;
    [SerializeField] GameObject effectPrefab;

    public bool isDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameController.Instance.GameOver();
        }
    }

    public bool IsEnemy()
    {
        return isEnemy;
    }
}
