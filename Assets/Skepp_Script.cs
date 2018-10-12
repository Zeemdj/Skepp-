using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skepp_Script : MonoBehaviour
{
    public float RotationSpeed = 150;
    public SpriteRenderer Rend;
    public float Speed = 5f;
    public Color LeftColor;
    public Color RightColor;
    public float Timer;
    public int CurrentTime = 1;



    // Use this for initialization
    void Start()
    {
        //randomiserar start positionen
        Rend.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4.6f, 4.6f), 0);
        //Randomiserar skeppets hastigehet.
        Speed = Random.Range(3f, 15f);

    }

    // Update is called once per frame
    void Update()
    {
        #region LeftTurn

        //Gör så att skeppet svänger vänster och blir grönt
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, (RotationSpeed - 50) * Time.deltaTime);
            Rend.color = LeftColor;
        }
        #endregion
        #region RightTurn

        // Gör så skeppet svänger höger och blir blått
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -RotationSpeed * Time.deltaTime);
            Rend.color = RightColor;
        }
        #endregion
        #region Forward Speed

        // Gör så skeppet åker framåt
        transform.Translate(Speed * Time.deltaTime, 0f, 0f);

        // Halverar skeppets fart framåt
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate((-Speed / 2) * Time.deltaTime, 0f, 0f);
        }
        #endregion
        #region Timer

        // Printar timern en gång per sekund
        Timer += Time.deltaTime;
        
        if (Timer > CurrentTime && Timer < CurrentTime + 0.2)
        {
            print("Timer: " + (int)Timer + "sec");
            CurrentTime = CurrentTime + 1;
        }
        #endregion
        #region Random Color

        // Randomiserar färgen varje gång man trycker "SPACE"
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rend.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        #endregion
        #region Warp

        // Warpar skeppet till motsatt sida av där den åkte ut från skärmen.
        if (transform.position.x < -9.75f)
        {
            transform.position = new Vector3(9.75f, transform.position.y, transform.position.z);
        }
        if (transform.position.x > 9.75f)
        {
            transform.position = new Vector3(-9.75f, transform.position.y, transform.position.z);
        }
        if (transform.position.y < -5.4f)
        {
            transform.position = new Vector3(transform.position.x, 5.4f, transform.position.z);
        }
        if (transform.position.y > 5.4f)
        {
            transform.position = new Vector3(transform.position.x, -5.4f, transform.position.z);
        }
        #endregion
    }
}
