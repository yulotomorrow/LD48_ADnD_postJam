using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMove : MonoBehaviour
{

    float enemySpeed = 0.1f;
    private int fishID = FishGenerate.caseNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPosition = gameObject.transform.position;
        switch (fishID)
        {
            case 0:
                
                newPosition.x += enemySpeed;
                gameObject.transform.position = newPosition;
                break;
        
            case 1:
                
                newPosition.x -= enemySpeed;
                gameObject.transform.position = newPosition;
            break;

            case 2:

                newPosition.y -= enemySpeed;
                gameObject.transform.position = newPosition;
                break;

            case 3:

                newPosition.y += enemySpeed;
                gameObject.transform.position = newPosition;
                break;


        }




    }

    private void Update()
    {
        //initialize
        if (gameObject.GetComponent<Renderer>().isVisible == true && CharaControl_ocean.reset == true)
        {
            Destroy(gameObject);
        }
    }
}
