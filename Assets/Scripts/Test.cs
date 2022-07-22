using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{


    public float moveSpeed = 5f;

    private GameObject enemyObj;
    private enemy enemyScript;



    void Start()
    {


   enemyScript = enemyObj.GetComponent<enemy>();
    }

    // Update is called once per frame
    void Update()
    {

        // Tutorial said Input.getAxis("Horizontal") - I had to change this to UnityEngine.Input.GetAxis("direction") in order to get it to work
        float moveHorizontal = UnityEngine.Input.GetAxis("Horizontal");
        float moveVertical = UnityEngine.Input.GetAxis("Vertical");

        //    float mousePosition = UnityEngine.Input.mousePosition;
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
          transform.Translate(movement * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemyScript.enemyHealth--;
            print("in the if!");
        }
        // Debug.Log(enemyScript.enemyHealth);

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            enemyScript = collision.gameObject.GetComponent<enemy>();
            enemyScript.enemyHealth--;
            print("HIT!! enemy score is now .. " + enemyScript.enemyHealth);
        }
    }
}
