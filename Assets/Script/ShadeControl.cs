using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShadeControl : MonoBehaviour
{

    public Color shader;
    // Start is called before the first frame update
    void Start()
    {
        shader = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CharaControl_ocean.seaweedCounter >10)
        {
            shader.a = (CharaControl_ocean.seaweedCounter - 10) / 9f;
            gameObject.GetComponent<SpriteRenderer>().color = shader;

            if (CharaControl_ocean.seaweedCounter > 17)
            {
                shader.a = 1f;
                SceneManager.LoadScene("Scene3_void", LoadSceneMode.Single);

            }
        }
    }
}
