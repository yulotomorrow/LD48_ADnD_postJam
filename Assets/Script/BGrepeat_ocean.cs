using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGrepeat_ocean : MonoBehaviour
{
    //public GameObject playerChara;
    float y_axis_val_bg;
    Vector3 val_bg;
    // Start is called before the first frame update
    void Start()
    {
        y_axis_val_bg = gameObject.transform.position.y;
        val_bg = gameObject.transform.position;
    }

    float moveScale = 1f;
    // Update is called once per frame
    void FixedUpdate()
    {

        //float y_axis_val_p = playerChara.transform.position.y;
         

        y_axis_val_bg += Time.deltaTime * moveScale;
        gameObject.transform.position = new Vector3(val_bg.x, y_axis_val_bg, val_bg.z);

        if (y_axis_val_bg > 30f) {

             y_axis_val_bg -= 10;
             gameObject.transform.position= new Vector3(transform.position.x, y_axis_val_bg, 0f);

            
        }
    }
}
