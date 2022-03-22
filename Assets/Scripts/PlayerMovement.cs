using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector3 direction;
    public float playerSpeed;
    TileSpawnManager tileSpawnManager;
    ScoreManager score;
    // Start is called before the first frame update


    void Start()
    {
        tileSpawnManager = GameObject.Find("TileSpawnManager").GetComponent<TileSpawnManager>();
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


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Tile")
        {
            Destroy(collision.gameObject, 2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        tileSpawnManager.SpawnTile();
        //if (other.gameObject.tag == "Player")
        //{
        //    TileSpawnManager.Instance.SpawnTile();
        //}
        if (other.gameObject.tag == "Coin")
        {
            score.ScoreCalculator(10);
            other.gameObject.SetActive(false);
        }
    }

}
