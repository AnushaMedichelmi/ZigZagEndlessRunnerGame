using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject currentTile;
    public GameObject[] tilePrefabs;
    private static TileSpawnManager instance;

    //public static TileSpawnManager Instance { get => instance;}

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }

    //}

    public static TileSpawnManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<TileSpawnManager>(); ;
            }
            return instance;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(rightTile, currentTile.transform.GetChild(1).position, Quaternion.identity);
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();

        }
    }

    public void SpawnTile()
    {
        int indexNumber = Random.Range(0, 10);
        if (indexNumber == 3)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }
        int randomValue = Random.Range(0, 2);
        currentTile = Instantiate(tilePrefabs[randomValue], currentTile.transform.GetChild(randomValue).position, Quaternion.identity);
    }
}
