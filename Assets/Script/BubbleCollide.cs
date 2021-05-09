using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleCollide : MonoBehaviour
{

    public GameObject floatText_bbl;
    public Sprite[] button_bbl;
    public string[] floatText_cnt_bbl;
    public Text textField;

    private RectTransform rt_words;
    private int cntNum;
    // Start is called before the first frame update
    void Start()
    {

        rt_words = floatText_bbl.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cntNum = CharaControl_ocean.seaweedCounter;

        Transform goTransform = gameObject.transform;
        rt_words.position = goTransform.position;
        floatText_bbl.GetComponent<RectTransform>().position = new Vector3(rt_words.position.x-1.1f, rt_words.position.y+1.8f, 0);

        if (cntNum > 0) {

            if (cntNum % 2 == 0)
            {
                floatText_bbl.GetComponent<Image>().sprite = button_bbl[cntNum / 2 - 1];
                textField.text = floatText_cnt_bbl[cntNum / 2 - 1];
            }
            else {
                floatText_bbl.GetComponent<Image>().sprite = button_bbl[(cntNum- 1) / 2 ];
                textField.text = floatText_cnt_bbl[(cntNum - 1) / 2];

            }
        
        }

        
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("nori"))
        {
            CharaControl_ocean.isHeal = true;
            
        }
        if (collision.CompareTag("fish"))
        {
            CharaControl_ocean.o2_real -= 60f;
            AudioSource au=gameObject.GetComponent<AudioSource>();
            au.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("nori"))
        {
            CharaControl_ocean.isHeal = false;
        }
    }
}
