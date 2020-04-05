using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject enemy;
    public Transform generationPoint;
    public float distanceBetween;

    float platformWidth;
    public float distanceMin;
    public float distanceMax;

    public EnemyControll EnemyM;

    void Start()
    {
        platformWidth = enemy.GetComponent<BoxCollider2D>().size.x;
    }
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(distanceMin, distanceMax);
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);
            // Instantiate(platform, transform.position, transform.rotation);

            GameObject newenemy = EnemyM.GetEnemy();
            newenemy.transform.position = transform.position;
            newenemy.transform.rotation = transform.rotation;
            newenemy.SetActive(true);
        }
    }
}
