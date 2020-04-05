using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControll : MonoBehaviour
{

    public GameObject enemy;
    public int enemyAmount;
    List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        for (int i = 0; i < enemyAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(enemy);
            obj.SetActive(false);
            enemies.Add(obj);
        }
    }

    public GameObject GetEnemy()
    {
        for (int i = 0; i < enemies.Count; i++) 
        {
            if (!enemies[i].activeInHierarchy) 
            {
                return enemies[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(enemy);
        obj.SetActive(false);
        enemies.Add(obj);
        return obj;
    }
}
