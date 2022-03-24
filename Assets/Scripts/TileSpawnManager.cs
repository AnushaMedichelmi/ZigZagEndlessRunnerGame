using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    // public GameObject rightTile;
    public GameObject currentTile;
    // public GameObject forwardTile;
    public GameObject[] tilesPrefab;
    Stack<GameObject> rightTile = new Stack<GameObject>();
    Stack<GameObject> forwardTile = new Stack<GameObject>();
    int count;
    float time;
    //SingleTon means we can only create single object out of it. We can't create multiple objects from it.
    private static TileSpawnManager instance;

    // static TileSpawnManager Instance { get => instance; }
    /*  private void Awake()
      {
          if (instance == null)
          {
              instance = this;
          }

      }*/
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
        CreateTile(20);
        for (int i = 0; i < 50; i++)
        {
            SpawnTile();
            //CreateTile(10);
        }

    }

    public void SpawnTile()
    {
        if (rightTile.Count == 0 || forwardTile.Count == 0)
        {
            CreateTile(20);
        }
        int k = Random.Range(0, 10);
        if (k == 5)
        {
            currentTile.transform.GetChild(3).gameObject.SetActive(true);
        }
        int index = Random.Range(0, 2);
        if (index == 0)
        {
            GameObject tempTile = forwardTile.Pop();
            tempTile.SetActive(true);
            tempTile.transform.position = currentTile.transform.GetChild(0).position;
            currentTile = tempTile;

        }
        else
        {
            if (index == 1)
            {
                GameObject tempTile = rightTile.Pop();
                tempTile.SetActive(true);
                tempTile.transform.position = currentTile.transform.GetChild(1).position;
                currentTile = tempTile;
            }
        }
        /* int index = Random.Range(0, 10);
         if(index==5)
         {
             currentTile.transform.GetChild(3).gameObject.SetActive(true);
         }
         int k = Random.Range(0, 2);
         //Instantiate(rightTile,currentTile.transform.GetChild(1).position,Quaternion.identity);
         currentTile = Instantiate(tilesPrefab[k], currentTile.transform.GetChild(k).position, Quaternion.identity); */
    }

    // Update is called once per frame
    void Update()
    {
        /* time=time+Time.deltaTime;
         if(time>3f)
         {
             Destroy(GameObject.FindGameObjectWithTag("Tile"));
             time = 0f;
         }*/
    }
    private void CreateTile(int count)
    {
        for (int i = 0; i < count; i++)
        {
            // SpawnTile();
            // CreateTile();

            rightTile.Push(Instantiate(tilesPrefab[1]));
            tilesPrefab[1].SetActive(false);
            forwardTile.Push(Instantiate(tilesPrefab[0]));
            tilesPrefab[0].SetActive(false);

        }
    }
    public void BackToRightPool(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        rightTile.Push(obj);
        rightTile.Peek().SetActive(false);

    }
    public void BackToForwardPool(GameObject obj)
    {
        obj.GetComponent<Rigidbody>().isKinematic = true;
        forwardTile.Push(obj);
        forwardTile.Peek().SetActive(false);
    }


}