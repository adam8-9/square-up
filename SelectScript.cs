using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectScript : MonoBehaviour
{
    public GameObject Broly;
    public GameObject Goku;
    private Vector3 CharPos;
    private Vector3 offScreen;
    private int CharInt = 1;
    private SpriteRenderer GokuRender, BrolyRender;

    private readonly string selectChar = "selectedCharacter";
    
    private void Awake()
    {
        
        CharPos = Broly.transform.position;
        offScreen = Goku.transform.position;
        GokuRender = Goku.GetComponent<SpriteRenderer>();
        BrolyRender = Broly.GetComponent<SpriteRenderer>();
    }

    public void NextChar()
    {
        switch (CharInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectChar,1);           
                GokuRender.enabled = false;
                Goku.transform.position = offScreen;
                Broly.transform.position = CharPos;
                BrolyRender.enabled = true;
                CharInt++;      
                break;
            case 2:
                PlayerPrefs.SetInt(selectChar, 2);         
                BrolyRender.enabled = false;
                Broly.transform.position = offScreen;
                Goku.transform.position = CharPos;
                GokuRender.enabled = true;
                CharInt++;     
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
  
    }

    public void PrevChar()
    {
        switch (CharInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectChar, 1);             
                GokuRender.enabled = false;
                Goku.transform.position = offScreen;
                Broly.transform.position = CharPos;
                BrolyRender.enabled = true;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectChar, 2);          
                BrolyRender.enabled = false;
                Broly.transform.position = offScreen;
                Goku.transform.position = CharPos;
                GokuRender.enabled = true;
                CharInt--;
                break;
            default:
                ResetInt();
                break;
        }
    }

    private void ResetInt()
    {
        if(CharInt >= 2)
        {
            CharInt = 1;
            
        }
        else
        {
            CharInt = 2;
        }
    }

    public void ConfirmButton()
    {
     
        SceneManager.LoadScene("TestScene");
    }

    public void Player2()
    {

        SceneManager.LoadScene("Player2Select");
    }
}
