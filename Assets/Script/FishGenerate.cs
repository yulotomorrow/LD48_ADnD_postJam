using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerate : MonoBehaviour
{

    public GameObject enemy;
    public GameObject indicatorTri;
 

    public Sprite[] enemyList;

    public static int caseNum; 

    private float xPos_fish;
    private float yPos_fish;
    private Vector3 generatePosition_edge;
    private Vector3 indicatePosition_edge;
    private Vector3 gP_edge;
    private Vector3 iP_edge;

    private GameObject randomEnemy;
    private GameObject indicatorCopy;

    // Start is called before the first frame update
    void Start()
    {
        
        iP_edge.x = - 8.72f;
        gP_edge.x = -10.58f- 0.1f * 0.8f * 30 - 1f;
        iP_edge.y = -4.86f;
        gP_edge.y = -6.98f - 0.1f * 0.8f * 30 - 1f;
        generatePosition_edge.z = 0;
        indicatePosition_edge.z = 0;
        setRandomTime();
    }


    float enemyTimer = 0f;
    float enemySpawnTime = 0.5f;

    int directionRnd;
    // Update is called once per frame
    void FixedUpdate()
    {

        enemyTimer += Time.deltaTime;
        if (enemyTimer > enemySpawnTime)
        {
            
            //enemyTimer = 0f;
                yPos_fish = (Random.value - 0.5f) * 5f;
                xPos_fish = (Random.value - 0.5f) * 9f;
                generatePosition_edge.y = yPos_fish;
                indicatePosition_edge.y = yPos_fish;
                setRandomTime();
                caseNum = directionRnd;
            switch (directionRnd) {
                case 0:
                    generatePosition_edge.y = yPos_fish;
                    indicatePosition_edge.y = yPos_fish;
                    generatePosition_edge.x = gP_edge.x;
                    indicatePosition_edge.x = iP_edge.x;
                    indicatorCopy = Instantiate(indicatorTri, indicatePosition_edge, Quaternion.identity);
                    randomEnemy = Instantiate(enemy, generatePosition_edge, Quaternion.identity);
                    break;

                case 1:
                    generatePosition_edge.y = yPos_fish;
                    indicatePosition_edge.y = yPos_fish;
                    generatePosition_edge.x = -gP_edge.x;
                    indicatePosition_edge.x = -iP_edge.x;
                    indicatorCopy = Instantiate(indicatorTri, indicatePosition_edge, Quaternion.identity);
                    randomEnemy = Instantiate(enemy, generatePosition_edge, Quaternion.identity);
                    indicatorCopy.transform.localScale = new Vector3(-0.1f, 0.1f, 1);
                    randomEnemy.transform.localScale = new Vector3(-1.4f, 1.4f, 1);

                    break;

                case 2:
                    generatePosition_edge.x = xPos_fish;
                    indicatePosition_edge.x = xPos_fish;
                    generatePosition_edge.y = -gP_edge.y;
                    indicatePosition_edge.y = -iP_edge.y;
                    indicatorCopy = Instantiate(indicatorTri, indicatePosition_edge, Quaternion.Euler(0, 0, -90));
                    randomEnemy = Instantiate(enemy, generatePosition_edge, Quaternion.Euler(0, 0, -90));
                    break;

                case 3:
                    generatePosition_edge.x = xPos_fish;
                    indicatePosition_edge.x = xPos_fish;
                    generatePosition_edge.y = gP_edge.y;
                    indicatePosition_edge.y = iP_edge.y;
                    indicatorCopy = Instantiate(indicatorTri, indicatePosition_edge, Quaternion.identity);
                    randomEnemy = Instantiate(enemy, generatePosition_edge, Quaternion.identity);
                    indicatorCopy.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    randomEnemy.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    break;

            }
               
                Destroy(indicatorCopy,0.8f);   
                Destroy(randomEnemy, 6f);


                enemyTimer = 0f;


        }
        if (CharaControl_ocean.reset == true) {
            enemyTimer = 0f;
        }
    }

    void setRandomTime()
    {
        enemySpawnTime = Random.Range(1.9f, 3f);
        directionRnd = Random.Range(0, 4);
    }


}
