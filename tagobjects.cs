using UnityEngine;

public class tagobjects : MonoBehaviour
{
    GameObject Player;
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Destroy(Player);
        
     
           

       
    }


    void Update()
    {

    }
}
