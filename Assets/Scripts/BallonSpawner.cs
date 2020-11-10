﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject balloonPrefab;
    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CO_GenerateBalloons());
    }

    // Update is called once per frame
    private IEnumerator CO_GenerateBalloons()
    {
        while (GameManager.Instance.isPlaying)
        {
            float randomPosX = Random.Range(minX, maxX);
            Instantiate(balloonPrefab, new Vector3(randomPosX, -5.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(0.75f);
        }
    }
}
