using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharaControl_ocean : MonoBehaviour
{

    public GameObject player;
    public GameObject health;
    public GameObject submarine;
    //public Text submarine_text;
    public Text initialize_text;

    public Slider o2Meter;
    public Text depth_UI;

    public Vector3 generatePosition;
    public static int seaweedCounter = 0;


    private GameObject randomHealth;


    private float o2_unit = 0.42f;
    public static float o2_real = 1000f;
    public static int o2_num = 1000;

    private float depth_unit = 0.05f;
    private float depth_real = 0f;

    //public GameObject panel;
    private Rigidbody2D rigidSphere;

    public static bool isHeal;

    private Vector3 initialTransform;
    public static bool reset = false;
    private float resetCount = 0f;
    private Vector3 subm_initial;

    // Start is called before the first frame update
    void Start()
    {
        generatePosition = new Vector3((Random.value - 0.5f) * Screen.width* 0.7f, 
            (Random.value - 0.5f) * Screen.height * 0.7f, 0f);
        initialTransform = player.GetComponent<Transform>().position;
        subm_initial= submarine.GetComponent<Transform>().position;
        rigidSphere = player.GetComponent<Rigidbody2D>();

    }


    float o2_Timer = 0f;
    float o2_Max = 8f;
    private bool spawn_o2;
    private bool is_consumed = true;


    private float maxVelocity = 5f;
    private float maxLinearVelocity = 2.99f;
    private float unitVelocity = 1.5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        
        o2_Timer += Time.deltaTime;
        //Debug.Log(enemyTimer);

        o2_real -= o2_unit;
        depth_real -= depth_unit;
        o2_num = (int)Mathf.Round(o2_real);

        if (o2_Timer> o2_Max && is_consumed == true) {
            spawn_o2 = true;
            is_consumed = false;
            o2_Timer = 0f;
        }


        //Vector2 screenPosition_E = Camera.main.WorldToScreenPoint(randomEnemy.transform.position);
        Vector2 screenPosition_P = Camera.main.WorldToScreenPoint(player.transform.position);



       
        // movement control
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {

            Vector3 newVelocity = rigidSphere.velocity;
            newVelocity.z = 0f;
            float newVelocityAbs = Mathf.Sqrt(Mathf.Pow(2,Mathf.Abs(newVelocity.x))+ Mathf.Pow(2, Mathf.Abs(newVelocity.y)));
            
            if (!(screenPosition_P.x < Screen.width * 0.05f) && newVelocityAbs < maxVelocity 
                && Mathf.Abs(newVelocity.x) < maxLinearVelocity) 
            {
                
                newVelocity+= Vector3.left * unitVelocity;
                player.GetComponent<Rigidbody2D>().velocity = newVelocity;

            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            Vector3 newVelocity = rigidSphere.velocity;
            newVelocity.z = 0f;
            float newVelocityAbs = Mathf.Sqrt(Mathf.Pow(2, Mathf.Abs(newVelocity.x)) + Mathf.Pow(2, Mathf.Abs(newVelocity.y)));
            if (!(screenPosition_P.x > Screen.width * 0.95f) && newVelocityAbs < maxVelocity
                && Mathf.Abs(newVelocity.x) < maxLinearVelocity)
            {

                newVelocity += Vector3.right * unitVelocity;
                player.GetComponent<Rigidbody2D>().velocity = newVelocity;

            }
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector3 newVelocity = rigidSphere.velocity;
            newVelocity.z = 0f;
            float newVelocityAbs = Mathf.Sqrt(Mathf.Pow(2, Mathf.Abs(newVelocity.x)) + Mathf.Pow(2, Mathf.Abs(newVelocity.y)));

            if (!(screenPosition_P.y > Screen.height * 0.95f) && newVelocityAbs < maxVelocity
                && Mathf.Abs(newVelocity.y) < maxLinearVelocity)
            {
                newVelocity += Vector3.up * unitVelocity;
                player.GetComponent<Rigidbody2D>().velocity = newVelocity;

            }
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {

            Vector3 newVelocity = rigidSphere.velocity;
            newVelocity.z = 0f;
            float newVelocityAbs = Mathf.Sqrt(Mathf.Pow(2, Mathf.Abs(newVelocity.x)) + Mathf.Pow(2, Mathf.Abs(newVelocity.y)));

            if (!(screenPosition_P.y < Screen.height * 0.05f) && newVelocityAbs < maxVelocity
                && Mathf.Abs(newVelocity.y) < maxLinearVelocity)
            {

                newVelocity += Vector3.down * unitVelocity;
                player.GetComponent<Rigidbody2D>().velocity = newVelocity;


            }
        }


        
        o2Meter.value = o2_num/1000f;
        depth_UI.text = "" + Mathf.Round(depth_real)*10;


        // spawn a seaweed on certain amount of time, random position

        if (spawn_o2 == true) {
            generatePosition = new Vector3((Random.value - 0.5f) * 9f, (Random.value - 0.5f) * 5f, 0f);
            randomHealth = Instantiate(health, generatePosition, Quaternion.identity);
            spawn_o2 = false;
        }

        if (Input.GetKey(KeyCode.E) && isHeal == true)
        {

            
            if (o2_real < 800f)
            {
                o2_real += 200f;
            }
            else {
                o2_real = 1000f;
            }
            
            Destroy(randomHealth.gameObject);
            is_consumed = true;
            seaweedCounter++;
            o2_Timer = 0f;
        }

        if (o2_num <=0) {

            o2_num = 0;
        }

        if (depth_real < -300) {
            // value: 1000, on UI 10000
            submarine.gameObject.SetActive(true);
            submarine.GetComponent<Transform>().position = subm_initial;
            // submarine_text.gameObject.SetActive(true);


        }


        if (o2_num == 0)
        {
            //fadeScr = true;
            resetCount += Time.deltaTime;
            if (resetCount > 2.5)
            {
                reset= true;
                resetCount = 0;
            }

        }

        if (reset == true) {

            o2_Timer = 0f;
            player.GetComponent<Transform>().position = initialTransform;
            depth_real = 0f;
            o2_real = 1000f;
            o2_num = 1000;
            //Destroy(randomHealth.gameObject);
            player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            submarine.gameObject.SetActive(false);
            seaweedCounter = 0;
            initialize_text.text = "Press E to collect!";
            reset = false;

            Debug.Log("reset");

        }




    }






}
