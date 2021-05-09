using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGrepeat : MonoBehaviour
{
    public GameObject playerChara;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float y_axis_val_p = playerChara.transform.position.y;
        float y_axis_val_bg = gameObject.transform.position.y;
        if (y_axis_val_p < -23.5f) {

            if (y_axis_val_bg > y_axis_val_p + 10) {
                gameObject.transform.position= new Vector3(transform.position.x, transform.position.y - 10f, 0f);
            }
            
        }
    }
}
