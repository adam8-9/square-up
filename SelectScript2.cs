using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectScript2 : MonoBehaviour
{
    public GameObject Broly2;
    public GameObject Goku2;
    private Vector3 CharPos2;
    private Vector3 offScreen2;
    private int CharInt2 = 1;
    private SpriteRenderer Goku2Render, Broly2Render;

   
    private readonly string selectChar2 = "selectedCharacter2";
    private void Awake()
    {
        CharPos2 = Broly2.transform.position;
        offScreen2 = Goku2.transform.position;
        Goku2Render = Goku2.GetComponent<SpriteRenderer>();
        Broly2Render = Broly2.GetComponent<SpriteRenderer>();
    }

    public void NextChar2()
    {
        switch (CharInt2)
        {
            case 1:               
                PlayerPrefs.SetInt(selectChar2, 1);
                Goku2Render.enabled = false;
                Goku2.transform.position = offScreen2;
                Broly2.transform.position = CharPos2;
                Broly2Render.enabled = true;
                CharInt2++;
                break;
            case 2:           
                PlayerPrefs.SetInt(selectChar2, 2);
                Broly2Render.enabled = false;
                Broly2.transform.position = offScreen2;
                Goku2.transform.position = CharPos2;
                Goku2Render.enabled = true;
                CharInt2++;
                ResetInt2();
                break;
            default:
                ResetInt2();
                break;
        }

    }

    public void PrevChar2()
    {
        switch (CharInt2)
        {
            case 1:           
                PlayerPrefs.SetInt(selectChar2, 1);
                Goku2Render.enabled = false;
                Goku2.transform.position = offScreen2;
                Broly2.transform.position = CharPos2;
                Broly2Render.enabled = true;
                ResetInt2();
                break;
            case 2:           
                PlayerPrefs.SetInt(selectChar2, 2);
                Broly2Render.enabled = false;
                Broly2.transform.position = offScreen2;
                Goku2.transform.position = CharPos2;
                Goku2Render.enabled = true;
                CharInt2--;
                break;
            default:
                ResetInt2();
                break;
        }
    }

    private void ResetInt2()
    {
        if (CharInt2 >= 2)
        {
            CharInt2 = 1;

        }
        else
        {
            CharInt2 = 2;
        }
    }

    public void ConfirmButton()
    {

        SceneManager.LoadScene("maps");
    }

    public void Player2()
    {

        SceneManager.LoadScene("Player2Select");
    }
}