using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Joystick joystick;

    public List<GameObject> guns_;
    public List<GameObject> textDamage;

    public float offset;
    private float setOff = 90f;
    private float timeBtwFire;
    public static float startTimeBtwFire;
    private float rotZ;
    private float timer;

    public static int damage;
    private int indexGun;

    public GameObject bullet;
    private GameObject instDamage;
    private GameObject _;

    public Transform firePos;

    public List<AudioSource> audioSources;

    public static bool isSpawnDamage;
    private bool isInstDamage;

    private void Start()
    {
        guns_[0].SetActive(false);
        guns_[1].SetActive(false);
        guns_[2].SetActive(false);
        guns_[3].SetActive(false);
        guns_[4].SetActive(false);
        guns_[5].SetActive(false);
        guns_[6].SetActive(false);
        guns_[7].SetActive(false);
        indexGun = PlayerPrefs.GetInt("index");
        guns_[indexGun].SetActive(true);

        joystick = GameObject.FindGameObjectWithTag("JoystickAttack").GetComponent<Joystick>();

        isSpawnDamage = false;
        timer = startTimeBtwFire - 0.1f;

        switch (indexGun)
        {

            case 0:
                damage = 2;
                startTimeBtwFire = 1.3f;
                instDamage = textDamage[1];
                break;

            case 1:
                damage = 2;
                startTimeBtwFire = 1.1f;
                instDamage = textDamage[0];
                break;

            case 2:
                damage = 1;
                startTimeBtwFire = 1.4f;
                instDamage = textDamage[0];
                break;

            case 3:
                damage = 3;
                startTimeBtwFire = 1.8f;
                instDamage = textDamage[2];
                break;

            case 4:
                damage = 2;
                startTimeBtwFire = 0.7f;
                instDamage = textDamage[1];
                break;

            case 5:
                damage = 1;
                startTimeBtwFire = 0.3f;
                instDamage = textDamage[0];
                break;

            case 6:
                damage = 2;
                startTimeBtwFire = 1.4f;
                instDamage = textDamage[1];
                break;

            case 7:
                damage = 5;
                startTimeBtwFire = 1f;
                instDamage = textDamage[3];
                break;
        }
    }

    void Update()
    {
        if (burg.isRight)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, ((rotZ * -1) - offset));
            if (joystick.Horizontal != 0)
            {
                rotZ = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
            }
            else
            {
                rotZ = Mathf.Atan2(joystick.Horizontal - setOff, joystick.Vertical) * Mathf.Rad2Deg;
            }
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, (rotZ - offset) * -1);
            if (joystick.Horizontal != 0)
            {
                rotZ = Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg;
            }
            else
            {
                rotZ = Mathf.Atan2(joystick.Horizontal + setOff, joystick.Vertical) * Mathf.Rad2Deg;
            }
        }

        if (timeBtwFire <= 0 && joystick.Horizontal != 0 && joystick.Vertical != 0)
        {
            if (Input.GetMouseButton(0))
            {
                if (gameObject.name == "guns_6" || gameObject.name == "guns_2")
                {
                    Instantiate(bullet, firePos.position, Quaternion.Euler(0f, 0f, rotZ * -1 + 30));
                    Instantiate(bullet, firePos.position, Quaternion.Euler(0f, 0f, rotZ * -1));
                    Instantiate(bullet, firePos.position, Quaternion.Euler(0f, 0f, rotZ * -1 - 30));
                    timeBtwFire = startTimeBtwFire;
                    audioSources[1].pitch = Random.Range(0.9f, 1.1f);
                    audioSources[1].Play();
                }
                else
                {
                    Instantiate(bullet, firePos.position, Quaternion.Euler(0f, 0f, rotZ * -1));
                    timeBtwFire = startTimeBtwFire;
                    audioSources[0].pitch = Random.Range(0.9f, 1.1f);
                    audioSources[0].Play();
                }
            }
        }
        else
        {
            timeBtwFire -= Time.deltaTime;
        }

        if (isSpawnDamage)
        {
            _ =  Instantiate(instDamage, new Vector3(Bullet.spawn.x, Bullet.spawn.y, Bullet.spawn.z - 1), Quaternion.identity);
            isInstDamage = true;
            isSpawnDamage = false;
        }
        if (isInstDamage)
        {
            _.transform.Translate(7 * Time.deltaTime * Vector3.up);
            Destroy(_, startTimeBtwFire);
            if(timer <= 0)
            {
                timer = startTimeBtwFire - 0.1f;
                isInstDamage = false;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }
}