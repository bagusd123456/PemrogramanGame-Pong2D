using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public int force;
    Rigidbody2D rb;

    int scorePlayer1;
    int scorePlayer2;

    Text scoreUIP1;
    Text scoreUIP2;

    GameObject panelSelesai;
    Text textPemenang;

    AudioSource audio;
    public AudioClip hitSound;
    void Start()
    {
        panelSelesai = GameObject.Find("PanelSelesai");
        panelSelesai.SetActive(false);
        scoreUIP1 = GameObject.Find("Score1").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("Score2").GetComponent<Text>();
        rb = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rb.AddForce(arah * force);

        scorePlayer1 = 0;
        scorePlayer2 = 0;

        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rb.velocity = new Vector2(0, 0);
    }

    void TampilkanScore()
    {
        Debug.Log("Score P1: " + scorePlayer1 + " Score P2: " + scorePlayer2);
        scoreUIP1.text = scorePlayer1 + "";
        scoreUIP2.text = scorePlayer2 + "";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(hitSound, 0.306f);
        if(collision.gameObject.name == "Right")
        {
            scorePlayer1 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rb.AddForce(arah * force);

            if (scorePlayer1 == 5)
            {
                panelSelesai.SetActive(true);
                textPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                textPemenang.text = "Player 1 Pemenang!";
                Destroy(gameObject);
                return;
                }
        }
        if(collision.gameObject.name == "Left")
        {
            scorePlayer2 += 1;
            TampilkanScore();
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rb.AddForce(arah * force);

            if (scorePlayer2 == 5)
            {
                panelSelesai.SetActive(true);
                textPemenang = GameObject.Find("Pemenang").GetComponent<Text>();
                textPemenang.text = "Player 2 Pemenang!";
                Destroy(gameObject);
                return;
            }
        }
        if(collision.gameObject.name == "Player 1" || 
            collision.gameObject.name == "Player 2")
        {
            float sudut = (transform.position.y - collision.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rb.velocity.x, sudut).normalized;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(arah * force * 2);
        }
    }

}
