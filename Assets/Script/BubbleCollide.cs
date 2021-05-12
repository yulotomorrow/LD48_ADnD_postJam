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
    public GameObject fillObject;
    

    private RectTransform rt_words;
    private int cntNum;

    private bool isFishCooldown = false;
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
        if (collision.CompareTag("fish") && isFishCooldown == false)
        {

            StartCoroutine(collideCooldown());
            CharaControl_ocean.o2_real -= 75f;
            AudioSource au = gameObject.GetComponent<AudioSource>();
            au.Play();
            StartCoroutine(collideFlash());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("nori"))
        {
            CharaControl_ocean.isHeal = false;
        }
    }

    IEnumerator collideFlash() {

        Color bubbleColor = GetComponent<SpriteRenderer>().color;
        Color fillColor = fillObject.GetComponent<Image>().color;

        yield return new WaitForSeconds(0.08f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(215f/255f, 74f / 255f, 77f / 255f, 1);
        fillObject.GetComponent<Image>().color = new Color(215f / 255f, 74f / 255f, 77f / 255f, 1);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = bubbleColor;
        fillObject.GetComponent<Image>().color = fillColor;

    }

    IEnumerator collideCooldown() {

        isFishCooldown = true;
        yield return new WaitForSeconds(0.5f);
        isFishCooldown = false;

    }
    


    }
