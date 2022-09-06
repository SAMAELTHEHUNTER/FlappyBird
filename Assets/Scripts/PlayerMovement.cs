using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject m_Player;
    [SerializeField] private float m_ForceMultiplier;
    [SerializeField] private float m_Velocity;
    [SerializeField] private GameObject m_GameOverUI;
    private bool m_IsGameOver = false;
    private Rigidbody2D m_PlayerRigidBody2D;
    public SpriteRenderer spriteRenderer;
    public Sprite UpSprite;
    public Sprite DownSprite;
    public Sprite BtSprite;
	public Text ScoreTxt;
    public Text CoinsTxt;
    public AudioSource audio;
    int Score = 0;
    int coins = 0;
    private void Start()
    {
        m_PlayerRigidBody2D=m_Player.GetComponent<Rigidbody2D>();
        m_PlayerRigidBody2D.velocity = Vector2.right * m_Velocity;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !m_IsGameOver)
        {
            print("Jump");
            m_PlayerRigidBody2D.velocity=new Vector2(m_PlayerRigidBody2D.velocity.x,m_ForceMultiplier);
        }
        Vector2 v1;
        v1 = m_PlayerRigidBody2D.velocity;
        if(v1.y > 0) {
            spriteRenderer.sprite = DownSprite;
        }
        else if (v1.y < 0) {
            spriteRenderer.sprite = UpSprite;
        }
        else
        {
            spriteRenderer.sprite = BtSprite;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
		
        if (collision.tag.Equals("Hazard"))
        {
            m_IsGameOver = true;
            print("Player is Dead!");
            m_GameOverUI.SetActive(true);
        }
		else if (collision.tag.Equals("CheckPoint")) {
			Score++;
			ScoreTxt.text = "SCORE: " + Score.ToString();
		}

        else if (collision.tag.Equals("Coin"))
        {
            audio.Play();
            coins++;
            CoinsTxt.text = "COIN: " + coins.ToString();
            collision.gameObject.SetActive(false);

        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(100);
    }
}
