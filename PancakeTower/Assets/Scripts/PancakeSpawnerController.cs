using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeSpawnerController : MonoBehaviour
{
    public GameObject pancakePrefab;
    private Vector2 screenBounds;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        SpawnPancakes();
    }

    void SpawnPancakes()
    {
        GameObject pancakeInstance = Instantiate(pancakePrefab) as GameObject;
        int random = new System.Random().Next(15, 20);
        pancakeInstance.GetComponent<Transform>().localScale = new Vector3(random * 0.01f, -0.15f, 0);
        float spawnX = UnityEngine.Random.Range(-screenBounds.x, screenBounds.x);
        pancakeInstance.transform.position = new Vector2(spawnX, 10);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
