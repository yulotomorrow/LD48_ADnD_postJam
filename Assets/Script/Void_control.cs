using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Void_control : MonoBehaviour
{

    public GameObject bed;
    public GameObject desk;
    public GameObject rabbit;
    public GameObject hole;
    public GameObject map;
    public GameObject map2;
    public ParticleSystem particles;
    public GameObject fall_audio;
    public GameObject bgm_void;
    //public GameObject coordinate;

    public static int stageNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stageNum == 1)
        {

            bed.SetActive(true);
            map2.SetActive(true);
        }
        else if (stageNum == 2)
        {

            map.SetActive(true);
            map2.SetActive(false);
        }
        else if (stageNum == 3)
        {

            rabbit.SetActive(true);
            hole.SetActive(true);
            map2.SetActive(false);
            map.SetActive(false);
            bed.SetActive(false);
            if (CharaCtrl_void.get_coord == true)
            {
                hole.GetComponent<Collider2D>().enabled = true;
            }
            else {
                hole.GetComponent<Collider2D>().enabled = false;
            }
         }
        else {

            bed.SetActive(false);
            map.SetActive(false);
            rabbit.SetActive(false);
            hole.SetActive(false);
            map2.SetActive(false);
        }

        if (RabbitHoleCollide.isHole == true) {
            bed.SetActive(false);
            map.SetActive(false);
            rabbit.SetActive(false);
            hole.SetActive(false);
            desk.SetActive(false);
            map2.SetActive(false);
            bgm_void.SetActive(false);
            particles.gameObject.SetActive(true);
            fall_audio.SetActive(true);

        }
    }
}
