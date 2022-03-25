using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        TileSpawnManager.Instance.SpawnTile();
        if (other.tag == "Player")
        {
            StartCoroutine("FallDown");
        }



    }

    IEnumerator FallDown()
    {
        yield return (new WaitForSeconds(0.5f));
        Debug.Log("Falling down");
        rb.isKinematic = false;
        yield return (new WaitForSeconds(1f));
        Debug.Log("Stop falling");
        rb.isKinematic = true;
        if (TileSpawnManager.Instance.name == "RightTile")
        {
            TileSpawnManager.Instance.BackToRightPool(gameObject);
        }
        if (TileSpawnManager.Instance.name == "ForwardTile")
        {

            TileSpawnManager.Instance.BackToForwardPool(gameObject);

        }
    }
}

  
   

