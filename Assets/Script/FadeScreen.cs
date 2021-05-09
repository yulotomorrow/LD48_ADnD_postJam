using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
    //bool fadeScr;
    float fadeAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CharaControl_ocean.o2_num == 0) {

            //fadeScr = true;

            StartCoroutine(fadeNlight());
        }
    }

    IEnumerator fadeNlight() {

        StartCoroutine(fadeScreen(true));
        yield return new WaitForSeconds(1);
        StartCoroutine(fadeScreen(false));

    }

    IEnumerator fadeScreen(bool toFade = false, int fadespeed = 2) {

        Color screenColor = GetComponent<SpriteRenderer>().color;
        
        if (toFade == true) {

            while (gameObject.GetComponent<SpriteRenderer>().color.a < 1) {

                fadeAmount = screenColor.a + (fadespeed * Time.deltaTime);

                screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
                gameObject.GetComponent<SpriteRenderer>().color = screenColor;

                yield return null;
            }
        }
        else
        {

            while (gameObject.GetComponent<SpriteRenderer>().color.a > 0)
            {

                fadeAmount = screenColor.a - (fadespeed * Time.deltaTime);

                screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
                gameObject.GetComponent<SpriteRenderer>().color = screenColor;

                yield return null;
            }
        }

    }
}
