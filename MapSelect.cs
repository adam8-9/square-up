using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MapSelect : MonoBehaviour
{
    public void Map1()
    {

        SceneManager.LoadScene("WorldTournament");
    }
    public void Map2()
    {

        SceneManager.LoadScene("IceMap");
    }
    public void Map3()
    {

        SceneManager.LoadScene("TestScene");
    }
    public void Map4()
    {

        SceneManager.LoadScene("skyMap");
    }
}
