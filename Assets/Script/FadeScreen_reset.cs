using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScreen_reset: MonoBehaviour
{
    //bool fadeScr;
    float fadeAmount;
    public Animator whale_anim;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CharaControl_ocean.o2_num == 0 && CharaControl_ocean.reset == false) {

            //fadeScr = true;
            //StopAllCoroutines();
            StartCoroutine(fadeNlight());
            
        }
    }




    IEnumerator fadeNlight() {

        Time.timeScale = 0;
        CharaControl_ocean.reset = true;
        StartCoroutine(fadeScreen(true));
       // Debug.Log("fade");
               
        yield return new WaitForSecondsRealtime(3);
        
        Time.timeScale = 1;
        StartCoroutine(fadeScreen(false));
        yield return null;
    }

    IEnumerator fadeScreen(bool toFade = false, int fadespeed = 1) {

        Color screenColor = GetComponent<SpriteRenderer>().color;
        
        if (toFade == true) {

            while (gameObject.GetComponent<SpriteRenderer>().color.a < 1) {

                fadeAmount = screenColor.a + (fadespeed * Time.unscaledDeltaTime/2);

                screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
                gameObject.GetComponent<SpriteRenderer>().color = screenColor;

                
                yield return null;
            }
        }
        else
        {

            while (gameObject.GetComponent<SpriteRenderer>().color.a > 0)
            {

                fadeAmount = screenColor.a - (fadespeed * Time.unscaledDeltaTime / 2);

                screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
                gameObject.GetComponent<SpriteRenderer>().color = screenColor;

                
                yield return null;
            }
        }

    }
}
