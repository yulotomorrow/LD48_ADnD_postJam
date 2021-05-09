using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFollow : MonoBehaviour
{

    public GameObject player_obj;
    private RectTransform rt_words;
    public Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        rt_words = this.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform goTransform = player_obj.transform;
        rt_words.position = goTransform.position;
        //mainCamera.WorldToScreenPoint(goTransform.position);


        gameObject.GetComponent<RectTransform>().position = new Vector3(rt_words.position.x, rt_words.position.y,0);
        
    }

}
