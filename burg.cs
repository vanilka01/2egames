using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class burg : MonoBehaviour
{
    public Joystick joystick;

    private Rigidbody2D rb;

    public new GameObject gameObject;
    public GameObject cum;
    public List<GameObject> guns_;
    public GameObject _speed;
    public GameObject attack;
    public GameObject shield;

    public static float speed = 10f;
    private float startTimer = 0f;
    private float bestTimer = 0f;

    public static int hpGG = 10;
    public static int hpSH = 0;
    public static int scoreInGame = 0;
    public static int _scoreInGame;
    public static int allCoins;
    public static int countKills = 0;
    public static int allKills = 0;
    public static int countBoss = 0;
    public static int allBoss = 0;
    private int bestTime;

    public static bool isRight;
    private int indexGun;
    private bool isAttackBoost = false;
    private bool isSpeedBoost = false;

    public Text showHP;
    public Text showHP2;
    public Text showSH;
    public Text showSH2;
    public Text score;
    public Text score2;

    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        PlayerPrefs.Save();
        countKills = 0;
        indexGun = PlayerPrefs.GetInt("index");
        isRight = false;
        rb = GetComponent<Rigidbody2D>();
        hpGG = 10;
        hpSH = PlayerPrefs.GetInt("Shield");
        Mathf.Clamp(hpGG, 0, 10);
        _scoreInGame = PlayerPrefs.GetInt("allCoins");
        scoreInGame = 0;
        attack.SetActive(false);
        _speed.SetActive(false);
        speed = 10f;

        if(hpSH == 0)
        {
            shield.SetActive(false);
        }
        else
        {
            shield.SetActive(true);
        }
    }

    void Update()
    {
        cum.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -10f);

        guns_[indexGun].transform.position = new Vector3(gameObject.transform.position.x + 1.5f, gameObject.transform.position.y, gameObject.transform.position.z - 0.5f);
        if (isRight)
        {
            guns_[indexGun].transform.position = new Vector3(gameObject.transform.position.x - 1.5f, gameObject.transform.position.y, gameObject.transform.position.z - 0.5f);
        }

        showHP.text = hpGG.ToString();
        showHP2.text = showHP.text;

        showSH.text = hpSH.ToString();
        showSH2.text = showSH.text;

        score.text = _scoreInGame.ToString();
        score2.text = score.text;

        if (hpGG <= 0)
        {
            allCoins = PlayerPrefs.GetInt("allCoins") ;
            PlayerPrefs.SetInt("allCoins", allCoins + scoreInGame);

            allKills = PlayerPrefs.GetInt("countKills");
            PlayerPrefs.SetInt("countKills", allKills + countKills);

            allBoss = PlayerPrefs.GetInt("countBoss");
            PlayerPrefs.SetInt("countBoss", allBoss + countBoss);

            bestTime = PlayerPrefs.GetInt("bestTime");
            if(bestTime < (int)bestTimer)
            {
                PlayerPrefs.SetInt("bestTime", (int)bestTimer);
            }

            PlayerPrefs.Save();
            SceneManager.LoadScene("Lose");
        }

        moveInput = new Vector2(joystick.Horizontal, joystick.Vertical);
        moveVelocity = moveInput.normalized * speed;

        if (isAttackBoost)
        {
            startTimer += Time.deltaTime;
            if (startTimer >= 5f)
            {
                Gun.startTimeBtwFire += 0.2f;
                startTimer = 0f;
                isAttackBoost = false;
                attack.SetActive(false);
            }
        }

        if (isSpeedBoost)
        {
            startTimer += Time.deltaTime;
            if (startTimer >= 5f)
            {
                speed -= 2f;
                startTimer = 0f;
                isSpeedBoost = false;
                _speed.SetActive(false);
            }
        }

        if(Pause.timer == 1)
        {
            bestTimer += Time.deltaTime;
        }

        if (BossBullet.isFreeze)
        {
            speed = 0;
            BossBullet.freezeTime -= Time.deltaTime;
            if (BossBullet.freezeTime <= 0)
            {
                speed = 10;
                BossBullet.isFreeze = false;
                BossBullet.freezeTime = 0.5f;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);

        float angel = moveInput.x * (-10);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angel);
        if (isRight == false && moveInput.x < 0)
        {
            Flip();
        }
        else if (isRight == true && moveInput.x > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        isRight = !isRight;
        Vector3 Scale = gameObject.transform.localScale;
        Scale.x *= -1;
        gameObject.transform.localScale = Scale;

        guns_[indexGun].transform.localScale = new Vector3(guns_[indexGun].transform.localScale.x * -1, guns_[indexGun].transform.localScale.y, guns_[indexGun].transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Heal":
                hpGG++;
                Destroy(collision.gameObject);
                Boosters.countBoosters--;
                break;

            case "Speed":
                speed += 2f;
                _speed.SetActive(true);
                Destroy(collision.gameObject);
                isSpeedBoost = true;
                Boosters.countBoosters--;
                break;

            case "Attack":
                Gun.startTimeBtwFire -= 0.2f;
                attack.SetActive(true);
                Destroy(collision.gameObject);
                isAttackBoost = true;
                Boosters.countBoosters--;
                break;

            case "Coins":
                _scoreInGame += 6;
                scoreInGame += 6;
                Destroy(collision.gameObject);
                Boosters.countBoosters--;
                break;
        }
    }
}


//TODO
//+1. счетчик боссов
//+2. музыка меню и проигрыша
//-3. настройки громкости
//+4. пнг гг в главном меню
//+5. название в меню

