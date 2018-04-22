using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullEnemyScript : MonoBehaviour {

    public float speedOfBull;
	
	void Update ()
    {
        this.transform.position -= new Vector3(0f, speedOfBull*Time.deltaTime, 0f);

        if (this.transform.position.y < ShipScript.ymin)
            Destroy(gameObject);
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag.Contains("Enemy")) return;

        Destroy(gameObject);
    }

}
