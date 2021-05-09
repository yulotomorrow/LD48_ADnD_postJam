using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class CharaCtrl_castle : MonoBehaviour
{

    private bool canControl;

    public Camera mainCam;
    private bool collide_scroll;
    private bool has_fell;
    public GameObject warningSign;
    public GameObject floatText_scroll;

    public Flowchart pt1;
    public Flowchart pt2;

    private Rigidbody2D rigidbody_avatar;
    private BoxCollider2D collider_avatar;
    [SerializeField] private LayerMask groundLayer;

    public AudioSource bgmSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody_avatar = transform.GetComponent<Rigidbody2D>();
        collider_avatar = transform.GetComponent<BoxCollider2D>();
        Time.timeScale = 1;
    }

    private float moveSpeed= 0.08f;
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 screenPosition_P = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        if (pt2.gameObject.activeSelf == false)
        {
            canControl = pt1.GetBooleanVariable("finishPt1");
        }
        else {
            canControl = false;
        }

        

        Debug.Log(canControl);

        if (canControl == true && isFalling() == false) {

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {

                if (!(screenPosition_P.x < Screen.width * 0.05f))
                {
                    Vector3 newPosition = gameObject.transform.position;
                    newPosition.x -= moveSpeed;
                    gameObject.transform.position = newPosition;
                    transform.localScale = new Vector3(-1, 1, 1);

                }
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {

                if (!(screenPosition_P.x > Screen.width * 0.95f))
                {

                    Vector3 newPosition = gameObject.transform.position;
                    newPosition.x += moveSpeed;
                    gameObject.transform.position = newPosition;
                    transform.localScale = new Vector3(1, 1, 1);


                }
            }
        }

        // bind camera using raycast
        if (isFalling() == true) {

            mainCam.transform.SetParent(gameObject.transform, true);
            has_fell = true;
            bgmSource.Stop();
            //M_camera.GetComponent<AudioListener>().enabled = false;
        }
        else if (has_fell == true)
        {

            mainCam.transform.SetParent(warningSign.gameObject.transform, true);
            //M_camera.GetComponent<AudioListener>().enabled = true;

        }


        // pick up scroll
        if (Input.GetKey(KeyCode.E) && collide_scroll == true)
        {
            pt2.gameObject.SetActive(true);

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("scroll"))
        {

            collide_scroll = true;
            floatText_scroll.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("scroll"))
        {

            collide_scroll = false;
            floatText_scroll.SetActive(false);
        }
    }

    private bool isFalling()
    {

        RaycastHit2D raycast = Physics2D.BoxCast(collider_avatar.bounds.center, collider_avatar.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
        return raycast.collider == null;
    }


}
