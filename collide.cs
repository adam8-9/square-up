using UnityEngine;

public class collide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("Collison");
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }


    }
}
