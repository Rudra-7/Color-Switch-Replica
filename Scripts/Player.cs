using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    

    public string currentColor;

    public SpriteRenderer sr;

    public Color colorCyan;
    public Color colorYellow;
    public Color colorMagenta;
    public Color colorPink;

    private void Start()
    {
        SetRandomeColor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

     void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.tag == "ColorChanger") {
            SetRandomeColor();
            Destroy(coll.gameObject);
            return;
        
        }
        if (coll.tag != currentColor) {
            Debug.Log("Game Over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomeColor() {
        int index = Random.Range(0, 4);

        switch (index){
            case 0:
                currentColor = "Cyan";
                sr.color = colorCyan;
                break;

            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;

            case 2:
                currentColor = "Magenta";
                sr.color = colorMagenta;
                break;

            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    } 
}
