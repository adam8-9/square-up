using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superAtk_1 : MonoBehaviour
{
    public Transform goku;
    public GameObject Atk1_prefab;
    public int checkTotal = 0;
    public float checkTime = 0;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            checkTotal = +1;


            if ((checkTotal == 1) && (checkTime < 0.2))
                checkTime += Time.deltaTime;

          

            if ((checkTotal == 1 ) && (checkTime >= 0.2))
            {
                checkTime = 0;
                checkTotal = 0;

            }


         

            if ((checkTotal == 2) && (checkTime < 0.2))
            {


                checkTotal = 0;
                Shoot();


            }
        }
       
    }


    void Shoot()
    {
        Instantiate(Atk1_prefab, goku.position, goku.rotation);
    }
}
