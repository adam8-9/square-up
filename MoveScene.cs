using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{

    public GameObject Broly;
    void update()
    {
        if (Input.GetKeyDown("9"))
        {
            SceneManager.LoadScene("WorldTournament");
            
            
        }
        DontDestroyOnLoad(Broly.transform);

    }



}
