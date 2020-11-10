using System.Collections;
using UnityEngine;

public class BallonSpawner : MonoBehaviour
{

    [SerializeField]
    private GameObject balloonPrefab;
    private float minX = -8;
    private float maxX = 4;
        
    void Start()
    {
        StartCoroutine(CO_GenerateBalloons());
    }

    private IEnumerator CO_GenerateBalloons()
    {
        while (GameManager.Instance.isPlaying)
        {
            float randomPosX = Random.Range(minX, maxX);
            Instantiate(balloonPrefab, new Vector3(randomPosX, -4.0f, 0.0f), Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
