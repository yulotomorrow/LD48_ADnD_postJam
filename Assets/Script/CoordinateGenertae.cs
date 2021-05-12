using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CoordinateGenertae : MonoBehaviour
{

    public Vector3[] coords;
    

    private float depth_unit = 4f;
    public static float depth_real;

    public Text destinaText;

    private Vector3 player_coord_R;
    public GameObject coord;

    //public static bool is_generated = false;
    public static bool is_match;

    public GameObject fadeScr;

    // Start is called before the first frame update
    void Start()
    {
        coords[0] = new Vector3(-10, 5, 0);
        coords[1] = new Vector3(2, 6, -9);
        coords[2] = new Vector3(-1, 18, -25);
        coords[3] = new Vector3(0, 27, -999999);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        player_coord_R = new Vector3(Mathf.Round(CharaCtrl_void.coordinate_x * 3), Mathf.Round(CharaCtrl_void.coordinate_y * 3),
                            Mathf.Round(CharaCtrl_void.coordinate_z * 3));

        // destination text
        if (CharaCtrl_void.get_coord == true) {

            destinaText.text = ("(" + coords[Void_control.stageNum].x + ", " + coords[Void_control.stageNum].y
            + ", " + coords[Void_control.stageNum].z + ")");
        }
        else {
            destinaText.text = "Unknown";
        }


        // match coordinate 
        if (player_coord_R.x == coords[Void_control.stageNum].x && player_coord_R.y == coords[Void_control.stageNum].y &&
            player_coord_R.z == coords[Void_control.stageNum].z && CharaCtrl_void.get_coord == true)
        {

            is_match = true;
        }
        else {
            is_match = false;
        }




        if (RabbitHoleCollide.isHole == true)
        {
            depth_real -= depth_unit;
            Debug.Log(depth_real);
            //play falling animation

            if (depth_real < -4000f)
            {
                StartCoroutine(fadeScreen(true, 1, 2, true));
                
            }
        }
        else {

            depth_real = player_coord_R.z;
        }
    }

    private void Update()
    {

        if (is_match == true)
        {
            Void_control.stageNum++;
            StartCoroutine(fadeNlight());
            CharaCtrl_void.get_coord = false;
            //is_generated = false;
            is_match = false;
        }

    }


    float fadeAmount;


    IEnumerator fadeNlight(float duration = 1f)
    {
        Time.timeScale = 0;
        StartCoroutine(fadeScreen(true, 3, 0, false));
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1;
        StartCoroutine(fadeScreen(false, 3, 0, false));

    }
    IEnumerator fadeScreen(bool toFade = false, int fadespeed = 1, float wait = 0.3f, bool toNext = false)
    {

        Color screenColor = fadeScr.GetComponent<SpriteRenderer>().color;

        if (toFade == true)
        {

            while (fadeScr.GetComponent<SpriteRenderer>().color.a < 1)
            {

                fadeAmount = screenColor.a + (fadespeed * Time.unscaledDeltaTime/3);

                screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
                fadeScr.GetComponent<SpriteRenderer>().color = screenColor;
                yield return new WaitForSecondsRealtime(wait);

                if (toNext == true)
                {
                    SceneManager.LoadScene("Scene4_glitch", LoadSceneMode.Single);
                }
                //yield return null;
            }
        }
        else
        {

            while (fadeScr.GetComponent<SpriteRenderer>().color.a > 0)
            {

                fadeAmount = screenColor.a - (fadespeed * Time.unscaledDeltaTime / 3);

                screenColor = new Color(screenColor.r, screenColor.g, screenColor.b, fadeAmount);
                fadeScr.GetComponent<SpriteRenderer>().color = screenColor;

                yield return null;
            }
        }

    }
}
