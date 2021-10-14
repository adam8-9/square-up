using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class keybinds : MonoBehaviour
{
  
    private Dictionary<string, KeyCode > keys = new Dictionary<string, KeyCode>();

   // private Dictionary<string, KeyCode, KeyCode> keys1 = new Dictionary<string, KeyCode, KeyCode>();

    //private IDictionary<string, Tuple<KeyCode, KeyCode>> keys1 = new Dictionary<string, Tuple<KeyCode, KeyCode>>();
    public Text up, left, down, right;

    private GameObject currentKey;

    // Start is called before the first frame update
    void Start()
    {
        keys.Add("Up", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("UP", "W")));
        keys.Add("Down", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Down", "s")));
       // keys.Add("left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("left", "a")));
       // keys.Add("right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("right", "d")));
        //keys1.Add("Horizontal", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("a", "d")));
      //  keys.Add("Horizontal", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Horizontal", "d")));
        //keys.Add("Horizontal1", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Horizontal1", "d")));

        up.text = keys["UP"].ToString();
        down.text = keys["Down"].ToString();
        left.text = keys["Horizontal"].ToString();
       // right.text = keys["Horizontal1"].ToString();
    }

    // Update is called once per frame
   /* void Update()
    {
        if (Input.GetKeyDown(keys["UP"]))
        {
            Debug.Log("Up");
        }

        if (Input.GetKeyDown(keys["Down"]))
        {
            Debug.Log("Down");
        }


        if (Input.GetKeyDown(keys["Horizontal"]))
        {
            Debug.Log("left");
        }

       /* if (Input.GetKeyDown(keys["Horizontal1"]))
        {
            Debug.Log("right");
        }
       
    }
  /*      if (Input.GetKeyDown(keys["Left"]))
        {
            Debug.Log("Left");
        }

        if (Input.GetKeyDown(keys["Right"]))
        {
            Debug.Log("Right");
        }
    
     */


    void OnGUI()
    {
        if(currentKey != null)
        {
            Event e = Event.current;
            if (e.isKey)
            {
                keys[currentKey.name] = e.keyCode;
               
                currentKey.transform.GetChild(0).GetComponent<Text>().text = e.keyCode.ToString();
                currentKey = null;
            }
        }
    }

    public void ChangeKey(GameObject clicked)
    {
        currentKey = clicked;
    }

    public void SaveKeys()
    {
        foreach (var key in keys )
        {
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }

        PlayerPrefs.Save();
    }

    public void Back()
    {
        SceneManager.LoadScene("main menu");
    }
}




