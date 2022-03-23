using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public float playerSpeed;
    TileSpawnManager spawnTile;
    ScoreManager score;
    public GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        spawnTile = GameObject.Find("TileSpawnManager").GetComponent<TileSpawnManager>();
        score = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if player moving forward then move him left
            if (direction == Vector3.forward)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }
        transform.Translate(direction * playerSpeed * Time.deltaTime);

    }



    public void OnCollisionEnter(Collision other)
    {
        //if(other.gameObject.tag=="Player")
        {

            TileSpawnManager.Instance.SpawnTile();



        }
        //spawnTile.SpawnTile();
        //if(other.tag == "Player")
        //{
        //    TileSpawnManager.Instance.SpawnTile();

        //}
        if (other.gameObject.tag == "Coin")
        {
            score.ScoreUpdate(10);
        }
        /*
        if (other.gameObject.tag == "Right")
        {
            temp = other.gameObject;
            //temp.GetComponent<Rigidbody>().isKinematic = false;
            temp.GetComponentInParent<Rigidbody>().isKinematic = false;
            StartCoroutine("RightPool");
        }
        else if (other.gameObject.tag == "Forward")
        {
            temp = other.gameObject;
            temp.GetComponentInParent<Rigidbody>().isKinematic = false;
            StartCoroutine("ForwardPool");
        }*/



    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Right")
        {
            //Destroy(collision.gameObject, 3f);
            TileSpawnManager.Instance.BackToRightPool(collision.gameObject);
            temp = collision.gameObject;
            //StartCoroutine("RightPool");
        }
        if (collision.gameObject.tag == "Forward")
        {
            //Destroy(collision.gameObject, 3f);
            TileSpawnManager.Instance.BackToForwardPool(collision.gameObject);
            temp = collision.gameObject;
            //StartCoroutine("ForwardPool");

        }

    }
    IEnumerator RightPool()
    {
        yield return new WaitForSeconds(1f);

        TileSpawnManager.Instance.BackToRightPool(temp);
        // TileSpawnManager.Instance.BackToForwardPool(temp);


    }
    IEnumerator ForwardPool()
    {
        yield return new WaitForSeconds(1f);
        // TileSpawnManager.Instance.BackToRightPool(temp);
        TileSpawnManager.Instance.BackToForwardPool(temp);


    }





}