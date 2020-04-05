using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllManager : MonoBehaviour
{
    public GameObject platform;
    public int platformAmount;
    List<GameObject> platforms;
    // Start is called before the first frame update
    void Start()
    {
       platforms = new List<GameObject>();
        for (int i = 0; i < platformAmount; i++)
        {
            GameObject obj = (GameObject) Instantiate(platform);
            obj.SetActive(false);
            platforms.Add(obj);
        }
    }

    public GameObject GetPlatform()
    {
        for (int i = 0; i < platforms.Count; i++) 
        {
            if (!platforms[i].activeInHierarchy) 
            {
                return platforms[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(platform);
        obj.SetActive(false);
        platforms.Add(obj);
        return obj;
    }
}
