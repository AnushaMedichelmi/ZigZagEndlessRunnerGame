using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    public GameObject currentTile;
    //public GameObject rightTile;
    //public GameObject forwardTile;
    public GameObject[] tilesPrefab;
    private static TileSpawnManager instance;

    Stack<GameObject> rightTile = new Stack<GameObject>();
    Stack<GameObject> forwardTile = new Stack<GameObject>();
    //static TileSpawnManager Instance { get => instance;  }


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
                instance = GameObject.FindObjectOfType<TileSpawnManager>();
            }
            return instance;
        }
    }

    void Start()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    //SpawnTile();
        //    //CreateTile(1);

        //}
        //SpawnTile();
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();

        }
    }


    public void SpawnTile()
    {/*
        int index = Random.Range(0, 10);
        if (index == 3)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }
        int k = Random.Range(0, 2);
        //Instantiate(tilesPrefab[k], currentTile.transform.GetChild(k).position, Quaternion.identity);
        currentTile = Instantiate(tilesPrefab[k], currentTile.transform.GetChild(k).position, Quaternion.identity);
        */
        if ((rightTile.Count == 0) || (forwardTile.Count == 0))
        {
            CreateTile(20);
        }
        int k = Random.Range(0, 2);
        if (k == 0)
        {
            GameObject temp = forwardTile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(0).position;
            currentTile = temp;

        }
        else if (k == 1)
        {
            GameObject temp = rightTile.Pop();
            temp.SetActive(true);
            temp.transform.position = currentTile.transform.GetChild(1).position;
            currentTile = temp;
        }

    }

    public void CreateTile(int value)
    {
        for (int i = 0; i < value; i++)
        {
            //SpawnTile();
            //CreateTile();
            rightTile.Push(Instantiate(tilesPrefab[1]));
            tilesPrefab[1].SetActive(false);
            forwardTile.Push(Instantiate(tilesPrefab[0]));
            tilesPrefab[0].SetActive(false);

        }
    }
    public void BackToRightPool(GameObject obj)
    {
        //obj.GetComponent<Rigidbody>().isKinematic = true;
        rightTile.Push(obj);
        rightTile.Peek().SetActive(false);
        //obj.SetActive(false);
    }
    public void BackToForwardPool(GameObject obj)
    {
        // obj.GetComponent<Rigidbody>().isKinematic = true;

        forwardTile.Push(obj);
        forwardTile.Peek().SetActive(false);
        //obj.SetActive(false);
    }
}