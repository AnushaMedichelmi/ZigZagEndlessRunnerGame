using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    void Start()
    {
        rb= GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    IEnumerator FallDown()
    {
        yield return(new WaitForSeconds(0.5f));
        Debug.Log("Falling down");
        rb.isKinematic = true;
        yield return (new WaitForSeconds(1f));
        Debug.Log("Stop falling");
       // gameObject.SetActive(true);

}

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("FallDown");
        }
       if(name=="RightTile")
        
            TileSpawnManager.Instance.BackToRightPool(other.gameObject);
        else if(name=="ForwardTile")
            TileSpawnManager.Instance.BackToForwardPool(other.gameObject);

       
    }
   
}
