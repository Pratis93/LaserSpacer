using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullScript : MonoBehaviour {

    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update ()
    {
        this.transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);

        if (this.transform.position.y > ShipScript.ymax) Destroy(gameObject);
	}
}
