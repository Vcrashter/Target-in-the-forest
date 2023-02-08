using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;

    void Start()
    {
        Destroy(gameObject, 2f);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        gameManager.IncrementScore();
    }
}