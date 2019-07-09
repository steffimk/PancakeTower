using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeSpawnerController : MonoBehaviour
{
    public GameObject pancakePrefab;
    private Vector2 screenBounds;
    private float timer;
    public float pancakeSpawnVelocity;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        SpawnPancake();
    }

    void SpawnPancake()
    {
        GameObject pancakeInstance = Instantiate(pancakePrefab) as GameObject;
        pancakeInstance.GetComponent<Rigidbody2D>().gravityScale = 1;
        int random = new System.Random().Next(15, 20);
        pancakeInstance.GetComponent<Transform>().localScale = new Vector3(random * 0.01f, -0.15f, 0);
        float spawnX = UnityEngine.Random.Range(-screenBounds.x, screenBounds.x);
        pancakeInstance.transform.position = new Vector2(spawnX, 5);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > pancakeSpawnVelocity)
        {
            this.SpawnPancake();
            timer = 0;
        }
    }
}
