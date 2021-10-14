using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMainChar : MonoBehaviour
{
    public Sprite GokuSprite, BrolySprite;
    public GameObject Goku;
    public GameObject Broly;
    private SpriteRenderer mySprite;
    private readonly string selectChar = "selectedCharacter";
    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }

  void Start()
    {
        int getChar;

        getChar = PlayerPrefs.GetInt(selectChar);

        switch (getChar)
        {
            case 1:
                mySprite.sprite = BrolySprite;
                Goku.SetActive(false);            
                break;
            case 2:
                mySprite.sprite = GokuSprite;
                Broly.SetActive(false);
                break;
            default:
                mySprite.sprite = BrolySprite;
                Goku.SetActive(false);
                break;

        }
    }

}
