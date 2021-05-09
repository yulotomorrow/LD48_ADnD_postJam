using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitHoleCollide : MonoBehaviour
{
    public static bool isHole = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isHole = true;
        gameObject.GetComponent<Collider2D>().enabled = false;

    }
}
