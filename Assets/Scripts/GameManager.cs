using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//1. ��� ����������� �¾�� �� ���̴�.
//2. �� �� �������� �¾�� �� ���ΰ�.
public class GameManager : MonoBehaviour
{
    
    private float timePrev = 0f;
    public bool isGameOver;
    public GameObject asteroidPrefab;
    public List<GameObject> asteroidPool = new List<GameObject>();
    public GameObject bulletPrefab;
    public List<GameObject> bulletPool = new List<GameObject>();

    public static GameManager gameManager;
    private void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        else if (gameManager != this)
            //Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        timePrev = Time.time; //����ð�
        asteroidPrefab = Resources.Load<GameObject>("Asteroid");
        isGameOver = false;
        bulletPrefab = Resources.Load("Bullet") as GameObject;
        StartCoroutine(AsteroidSpawn());
        CreateAsteroidPool();
        CreateBulletPool();
    }
    private void CreateAsteroidPool()
    {
        GameObject asteroidObj = new GameObject("AsteroidPool");
        for (int i = 0; i < 5; i++)
        {
            GameObject _asteroid = Instantiate(asteroidPrefab, asteroidObj.transform);
            _asteroid.name = "Asteroid" + i.ToString();
            _asteroid.SetActive(false);
            asteroidPool.Add(_asteroid);
        }
    }
    private void CreateBulletPool()
    {
        GameObject bulletObj = new GameObject("BulletPool");
        for (int i = 0; i < 10; i++)
        {
            GameObject _bullet = Instantiate(bulletPrefab, bulletObj.transform);
            _bullet.name = "Bullet" + i.ToString();
            _bullet.SetActive(false);
            bulletPool.Add(_bullet);
        }
    }
    
    public GameObject GetBullet()
    {
        for (int i = 0; i < bulletPool.Count; i++)
        {
            if (bulletPool[i].activeSelf == false)
            {
                return bulletPool[i];
            }
        }
        return null;
    }
    IEnumerator AsteroidSpawn()
    {
        while (isGameOver == false)
        {
            yield return new WaitForSeconds(0.2f);
            foreach (GameObject _asteroid in asteroidPool)
            {
                if (Time.time - timePrev > 2.0f)
                {
                    if (_asteroid.activeSelf == false)
                    {
                        float randomY = Random.Range(-4f, 4f); //Y��ǥ ���� ����
                        float _scale = Random.Range(0.5f, 1f); //ũ�⵵ �����ϰ�
                        _asteroid.transform.position = new Vector3(13f, _asteroid.transform.position.y + randomY,
                                         _asteroid.transform.position.z);
                        _asteroid.transform.localScale = Vector3.one * _scale;
                        _asteroid.SetActive(true);
                    }
                    //Instantiate(asteroidPrefab, new Vector3(13f, asteroidPrefab.transform.position.y + randomY,
                    //            asteroidPrefab.transform.position.z), Quaternion.identity);
                    //Quaternion.identity = ������ �� ȸ���� ���ٴ� ��
                    timePrev = Time.time;
                }
                else
                {
                    yield return null; //�������� ���� �ΰ��� ��ȯ.
                }
            }
        }
    }
}
