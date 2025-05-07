using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    float xDeathZone = 21.8f;
    float yDeathZone = 13.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flapStrength = 10;
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        // Revisar si Birs salio de la pantalla y dar gameOver
        float x = transform.position.x;
        float y = transform.position.y;

        if(x > xDeathZone || x < (xDeathZone * -1) || y > yDeathZone || y < (yDeathZone * -1))
        {
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        Debug.Log("Bird collision");
        birdIsAlive = false;
    }
}
