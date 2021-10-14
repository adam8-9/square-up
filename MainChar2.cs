using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainChar2 : MonoBehaviour
{
    public Sprite GokuSprite2, BrolySprite2;
    public GameObject Goku2;
    public GameObject Broly2;
    private SpriteRenderer Sprite;
    private readonly string selectChar2 = "selectedCharacter2";
    void Awake()
    {
        Sprite = this.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        int getChar2;

        getChar2 = PlayerPrefs.GetInt(selectChar2);

        switch (getChar2)
        {
            case 1:
                Sprite.sprite = BrolySprite2;
                Goku2.SetActive(false);
                break;
            case 2:
                Sprite.sprite = GokuSprite2;           
                Broly2.SetActive(false);
                break;
            default:
                Sprite.sprite = BrolySprite2;
                Goku2.SetActive(false);
                break;
        }
    }

}
