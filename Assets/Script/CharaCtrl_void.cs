using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class CharaCtrl_void : MonoBehaviour
{

    public Sprite xy_sprite;
    public Sprite xz_sprite;
    public ParticleSystem pixels;
    public ParticleSystem pixels_words;
    public AudioSource xy_sound;
    public AudioSource xz_sound;

    public GameObject floatText;
    public Text floatText_cnt;

    public static bool isXY = true;


    public static float coordinate_x;
    public static float coordinate_y;
    public static float coordinate_z;

    

    private Vector3 newPosition;

    public Text coordinates;

    private bool switchingXY = false;
    private bool switchingXZ = false;

    private RectTransform rt_words;

    public Flowchart fc_void;
    private bool is_start_void;

    public static bool get_coord;

    // Start is called before the first frame update
    void Start()
    {
        coordinate_x = newPosition.x;
        coordinate_y = newPosition.y;
        coordinate_z = 0f;
        rt_words = floatText.GetComponent<RectTransform>();

    }

    private bool is_cooldown = false;
    private float moveSpeed= 0.08f;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 screenPosition_P = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        newPosition = gameObject.transform.position;

        is_start_void = fc_void.GetBooleanVariable("isStart_scene3") && (!RabbitHoleCollide.isHole);

        // movement control, lock movement at beginning
        if (is_start_void == true)
        {

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {

                if (!(screenPosition_P.x < Screen.width * 0.05f))
                {

                    newPosition.x -= moveSpeed;
                    gameObject.transform.position = newPosition;
                    transform.localScale = new Vector3(-1, 1, 1);


                }
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                if (!(screenPosition_P.x > Screen.width * 0.9f))
                {


                    newPosition.x += moveSpeed;
                    gameObject.transform.position = newPosition;
                    transform.localScale = new Vector3(1, 1, 1);


                }
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {

                if (!(screenPosition_P.y < Screen.height * 0.1f))
                {

                    newPosition.y -= moveSpeed;
                    gameObject.transform.position = newPosition;
                    //transform.localScale = new Vector3(1, -1, 1);

                    if (isXY == true)
                    {
                        coordinate_y -= moveSpeed;
                    }
                    else
                    {
                        coordinate_z -= moveSpeed;
                    }

                }
            }



            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {

                if (!(screenPosition_P.y > Screen.height * 0.95f))
                {


                    newPosition.y += moveSpeed;
                    gameObject.transform.position = newPosition;
                    //transform.localScale = new Vector3(1, 1, 1);

                    if (isXY == true)
                    {
                        coordinate_y += moveSpeed;
                    }
                    else
                    {
                        coordinate_z += moveSpeed;
                    }

                }
            }

        }

        // free fall
        if (RabbitHoleCollide.isHole == true) {
            coordinate_z = CoordinateGenertae.depth_real;
        }

        coordinate_x = newPosition.x;

        coordinates.text = ("(" + Mathf.Round(coordinate_x * 3) + ", " + Mathf.Round(coordinate_y * 3)
            + ", " + Mathf.Round(coordinate_z * 3) + ")");

        // change form
        if (Input.GetKey(KeyCode.E) && is_cooldown == false)
        {
            if (switchingXZ == true)
            {
 
                StartCoroutine(cooldown());
                gameObject.GetComponent<SpriteRenderer>().sprite = xz_sprite;
                isXY = false;
                xz_sound.Play();
                pixels.Play();
         
            }
            else if (switchingXY == true)
            {
                if (get_coord == false) {
                    pixels_words.Play();
                }
                StartCoroutine(cooldown());
                gameObject.GetComponent<SpriteRenderer>().sprite = xy_sprite;
                isXY = true;
                get_coord = true;
                //Debug.Log(get_coord);
                xy_sound.Play();
                pixels.Play();
                
            }
        }

        Transform goTransform = gameObject.transform;
        rt_words.position = goTransform.position;
        floatText.GetComponent<RectTransform>().position = new Vector3(rt_words.position.x, rt_words.position.y, 0);


    }
    

    



    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.CompareTag("bed"))
        {
            floatText.SetActive(true);
            switchingXZ = true;
            switchingXY = false;
            floatText_cnt.text= "Bed";
        }
        else if (collision.CompareTag("desk"))
        {
            floatText.SetActive(true);
            switchingXY = true;
            switchingXZ = false;
            floatText_cnt.text = "Desk";
        }
        Debug.Log("collide");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        floatText.SetActive(false);
        if (collision.CompareTag("bed") || collision.CompareTag("desk"))
        {
            switchingXZ = false;
            switchingXY = false;

        }
    }

    IEnumerator cooldown(float time = 1f) {

        is_cooldown = true;
        yield return new WaitForSeconds(time);
        is_cooldown = false;

    }

}
