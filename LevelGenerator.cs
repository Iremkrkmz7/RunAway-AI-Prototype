using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance { get; private set; }
 
    public GameObject planePrefab;
    public GameObject enemyPrefab;
    public GameObject coinPrefab;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject startPanel;
    public TextMeshProUGUI levelTextUI;
    public TextMeshProUGUI coinTextUI;
    

    
 
    public static LevelData[] levels = new LevelData[]
    {
        new LevelData { levelNumber=1,  environment=EnvironmentType.City, planeSize=25f, coinCount=3, enemyCount=1, enemySpeed=1f,    groundColor=new Color(0.5f,0.5f,0.5f),   skyColor=new Color(0.7f,0.7f,0.8f),   ambientSound="city" },
        new LevelData { levelNumber=2,  environment=EnvironmentType.City, planeSize=24f, coinCount=3, enemyCount=1, enemySpeed=1.1f,  groundColor=new Color(0.5f,0.5f,0.5f),   skyColor=new Color(0.7f,0.7f,0.8f),   ambientSound="city" },
        new LevelData { levelNumber=3,  environment=EnvironmentType.City, planeSize=23f, coinCount=3, enemyCount=1, enemySpeed=1.2f,  groundColor=new Color(0.48f,0.48f,0.48f), skyColor=new Color(0.68f,0.68f,0.78f),ambientSound="city" },
        new LevelData { levelNumber=4,  environment=EnvironmentType.City, planeSize=22f, coinCount=4, enemyCount=2, enemySpeed=1.4f,  groundColor=new Color(0.48f,0.48f,0.48f), skyColor=new Color(0.68f,0.68f,0.78f),ambientSound="city" },
        new LevelData { levelNumber=5,  environment=EnvironmentType.City, planeSize=21f, coinCount=4, enemyCount=2, enemySpeed=1.5f,  groundColor=new Color(0.46f,0.46f,0.46f), skyColor=new Color(0.66f,0.66f,0.76f),ambientSound="city" },
        new LevelData { levelNumber=6,  environment=EnvironmentType.City, planeSize=20f, coinCount=4, enemyCount=2, enemySpeed=1.6f,  groundColor=new Color(0.46f,0.46f,0.46f), skyColor=new Color(0.66f,0.66f,0.76f),ambientSound="city" },
        new LevelData { levelNumber=7,  environment=EnvironmentType.City, planeSize=19f, coinCount=5, enemyCount=2, enemySpeed=1.7f,  groundColor=new Color(0.44f,0.44f,0.44f), skyColor=new Color(0.64f,0.64f,0.74f),ambientSound="city" },
        new LevelData { levelNumber=8,  environment=EnvironmentType.City, planeSize=18f, coinCount=5, enemyCount=2, enemySpeed=1.8f,  groundColor=new Color(0.44f,0.44f,0.44f), skyColor=new Color(0.64f,0.64f,0.74f),ambientSound="city" },
        new LevelData { levelNumber=9,  environment=EnvironmentType.City, planeSize=17f, coinCount=5, enemyCount=2, enemySpeed=1.9f,  groundColor=new Color(0.42f,0.42f,0.42f), skyColor=new Color(0.62f,0.62f,0.72f),ambientSound="city" },
        new LevelData { levelNumber=10, environment=EnvironmentType.City, planeSize=16f, coinCount=5, enemyCount=2, enemySpeed=2f,    groundColor=new Color(0.42f,0.42f,0.42f), skyColor=new Color(0.62f,0.62f,0.72f),ambientSound="city" },
 
        new LevelData { levelNumber=11, environment=EnvironmentType.Forest, planeSize=22f, coinCount=4, enemyCount=2, enemySpeed=2.1f, groundColor=new Color(0.2f,0.5f,0.2f),   skyColor=new Color(0.5f,0.7f,0.9f),   ambientSound="forest" },
        new LevelData { levelNumber=12, environment=EnvironmentType.Forest, planeSize=21f, coinCount=4, enemyCount=2, enemySpeed=2.2f, groundColor=new Color(0.2f,0.5f,0.2f),   skyColor=new Color(0.5f,0.7f,0.9f),   ambientSound="forest" },
        new LevelData { levelNumber=13, environment=EnvironmentType.Forest, planeSize=20f, coinCount=5, enemyCount=3, enemySpeed=2.3f, groundColor=new Color(0.18f,0.48f,0.18f), skyColor=new Color(0.48f,0.68f,0.88f),ambientSound="forest" },
        new LevelData { levelNumber=14, environment=EnvironmentType.Forest, planeSize=19f, coinCount=5, enemyCount=3, enemySpeed=2.4f, groundColor=new Color(0.18f,0.48f,0.18f), skyColor=new Color(0.48f,0.68f,0.88f),ambientSound="forest" },
        new LevelData { levelNumber=15, environment=EnvironmentType.Forest, planeSize=18f, coinCount=5, enemyCount=3, enemySpeed=2.5f, groundColor=new Color(0.16f,0.46f,0.16f), skyColor=new Color(0.46f,0.66f,0.86f),ambientSound="forest" },
        new LevelData { levelNumber=16, environment=EnvironmentType.Forest, planeSize=17f, coinCount=6, enemyCount=3, enemySpeed=2.6f, groundColor=new Color(0.16f,0.46f,0.16f), skyColor=new Color(0.46f,0.66f,0.86f),ambientSound="forest" },
        new LevelData { levelNumber=17, environment=EnvironmentType.Forest, planeSize=16f, coinCount=6, enemyCount=3, enemySpeed=2.7f, groundColor=new Color(0.14f,0.44f,0.14f), skyColor=new Color(0.44f,0.64f,0.84f),ambientSound="forest" },
        new LevelData { levelNumber=18, environment=EnvironmentType.Forest, planeSize=15f, coinCount=6, enemyCount=3, enemySpeed=2.8f, groundColor=new Color(0.14f,0.44f,0.14f), skyColor=new Color(0.44f,0.64f,0.84f),ambientSound="forest" },
        new LevelData { levelNumber=19, environment=EnvironmentType.Forest, planeSize=14f, coinCount=6, enemyCount=3, enemySpeed=2.9f, groundColor=new Color(0.12f,0.42f,0.12f), skyColor=new Color(0.42f,0.62f,0.82f),ambientSound="forest" },
        new LevelData { levelNumber=20, environment=EnvironmentType.Forest, planeSize=13f, coinCount=6, enemyCount=3, enemySpeed=3f,   groundColor=new Color(0.12f,0.42f,0.12f), skyColor=new Color(0.42f,0.62f,0.82f),ambientSound="forest" },
 
        new LevelData { levelNumber=21, environment=EnvironmentType.Mountain, planeSize=19f, coinCount=5, enemyCount=3, enemySpeed=3.1f, groundColor=new Color(0.5f,0.35f,0.2f),   skyColor=new Color(0.4f,0.6f,0.9f),   ambientSound="wind" },
        new LevelData { levelNumber=22, environment=EnvironmentType.Mountain, planeSize=18f, coinCount=5, enemyCount=3, enemySpeed=3.2f, groundColor=new Color(0.5f,0.35f,0.2f),   skyColor=new Color(0.4f,0.6f,0.9f),   ambientSound="wind" },
        new LevelData { levelNumber=23, environment=EnvironmentType.Mountain, planeSize=17f, coinCount=6, enemyCount=4, enemySpeed=3.3f, groundColor=new Color(0.48f,0.33f,0.18f), skyColor=new Color(0.38f,0.58f,0.88f),ambientSound="wind" },
        new LevelData { levelNumber=24, environment=EnvironmentType.Mountain, planeSize=16f, coinCount=6, enemyCount=4, enemySpeed=3.4f, groundColor=new Color(0.48f,0.33f,0.18f), skyColor=new Color(0.38f,0.58f,0.88f),ambientSound="wind" },
        new LevelData { levelNumber=25, environment=EnvironmentType.Mountain, planeSize=15f, coinCount=6, enemyCount=4, enemySpeed=3.5f, groundColor=new Color(0.46f,0.31f,0.16f), skyColor=new Color(0.36f,0.56f,0.86f),ambientSound="wind" },
        new LevelData { levelNumber=26, environment=EnvironmentType.Mountain, planeSize=14f, coinCount=7, enemyCount=4, enemySpeed=3.6f, groundColor=new Color(0.46f,0.31f,0.16f), skyColor=new Color(0.36f,0.56f,0.86f),ambientSound="wind" },
        new LevelData { levelNumber=27, environment=EnvironmentType.Mountain, planeSize=13f, coinCount=7, enemyCount=4, enemySpeed=3.7f, groundColor=new Color(0.44f,0.29f,0.14f), skyColor=new Color(0.34f,0.54f,0.84f),ambientSound="wind" },
        new LevelData { levelNumber=28, environment=EnvironmentType.Mountain, planeSize=12f, coinCount=7, enemyCount=4, enemySpeed=3.8f, groundColor=new Color(0.44f,0.29f,0.14f), skyColor=new Color(0.34f,0.54f,0.84f),ambientSound="wind" },
        new LevelData { levelNumber=29, environment=EnvironmentType.Mountain, planeSize=11f, coinCount=7, enemyCount=4, enemySpeed=3.9f, groundColor=new Color(0.42f,0.27f,0.12f), skyColor=new Color(0.32f,0.52f,0.82f),ambientSound="wind" },
        new LevelData { levelNumber=30, environment=EnvironmentType.Mountain, planeSize=10f, coinCount=7, enemyCount=4, enemySpeed=4f,   groundColor=new Color(0.42f,0.27f,0.12f), skyColor=new Color(0.32f,0.52f,0.82f),ambientSound="wind" },
 
        
        new LevelData { levelNumber=31, environment=EnvironmentType.Sky, planeSize=16f, coinCount=6, enemyCount=4, enemySpeed=4.1f, groundColor=new Color(0.9f,0.9f,1f),     skyColor=new Color(1f,0.6f,0.4f),     ambientSound="sky" },
        new LevelData { levelNumber=32, environment=EnvironmentType.Sky, planeSize=15f, coinCount=6, enemyCount=4, enemySpeed=4.2f, groundColor=new Color(0.88f,0.88f,0.98f),skyColor=new Color(0.98f,0.55f,0.38f),ambientSound="sky" },
        new LevelData { levelNumber=33, environment=EnvironmentType.Sky, planeSize=14f, coinCount=7, enemyCount=5, enemySpeed=4.3f, groundColor=new Color(0.86f,0.86f,0.96f),skyColor=new Color(0.96f,0.5f,0.36f), ambientSound="sky" },
        new LevelData { levelNumber=34, environment=EnvironmentType.Sky, planeSize=13f, coinCount=7, enemyCount=5, enemySpeed=4.4f, groundColor=new Color(0.84f,0.84f,0.94f),skyColor=new Color(0.94f,0.45f,0.34f),ambientSound="sky" },
        new LevelData { levelNumber=35, environment=EnvironmentType.Sky, planeSize=12f, coinCount=7, enemyCount=5, enemySpeed=4.5f, groundColor=new Color(0.82f,0.82f,0.92f),skyColor=new Color(0.92f,0.4f,0.32f), ambientSound="sky" },
        new LevelData { levelNumber=36, environment=EnvironmentType.Sky, planeSize=11f, coinCount=8, enemyCount=5, enemySpeed=4.6f, groundColor=new Color(0.8f,0.8f,0.9f),   skyColor=new Color(0.9f,0.35f,0.3f),  ambientSound="sky" },
        new LevelData { levelNumber=37, environment=EnvironmentType.Sky, planeSize=10f, coinCount=8, enemyCount=5, enemySpeed=4.7f, groundColor=new Color(0.78f,0.78f,0.88f),skyColor=new Color(0.88f,0.3f,0.28f), ambientSound="sky" },
        new LevelData { levelNumber=38, environment=EnvironmentType.Sky, planeSize=9f,  coinCount=8, enemyCount=5, enemySpeed=4.8f, groundColor=new Color(0.76f,0.76f,0.86f),skyColor=new Color(0.86f,0.25f,0.26f),ambientSound="sky" },
        new LevelData { levelNumber=39, environment=EnvironmentType.Sky, planeSize=8f,  coinCount=8, enemyCount=5, enemySpeed=4.9f, groundColor=new Color(0.74f,0.74f,0.84f),skyColor=new Color(0.84f,0.2f,0.24f), ambientSound="sky" },
        new LevelData { levelNumber=40, environment=EnvironmentType.Sky, planeSize=7f,  coinCount=8, enemyCount=5, enemySpeed=5f,   groundColor=new Color(0.72f,0.72f,0.82f),skyColor=new Color(0.82f,0.15f,0.22f),ambientSound="sky" },
 
        
        new LevelData { levelNumber=41, environment=EnvironmentType.Space, planeSize=13f, coinCount=7,  enemyCount=5, enemySpeed=5.1f, groundColor=new Color(0.05f,0.05f,0.1f), skyColor=new Color(0f,0f,0.05f), ambientSound="space" },
        new LevelData { levelNumber=42, environment=EnvironmentType.Space, planeSize=12f, coinCount=7,  enemyCount=5, enemySpeed=5.3f, groundColor=new Color(0.05f,0.05f,0.1f), skyColor=new Color(0f,0f,0.05f), ambientSound="space" },
        new LevelData { levelNumber=43, environment=EnvironmentType.Space, planeSize=11f, coinCount=8,  enemyCount=6, enemySpeed=5.5f, groundColor=new Color(0.04f,0.04f,0.09f),skyColor=new Color(0f,0f,0.04f), ambientSound="space" },
        new LevelData { levelNumber=44, environment=EnvironmentType.Space, planeSize=10f, coinCount=8,  enemyCount=6, enemySpeed=5.7f, groundColor=new Color(0.04f,0.04f,0.09f),skyColor=new Color(0f,0f,0.04f), ambientSound="space" },
        new LevelData { levelNumber=45, environment=EnvironmentType.Space, planeSize=9f,  coinCount=8,  enemyCount=6, enemySpeed=5.9f, groundColor=new Color(0.03f,0.03f,0.08f),skyColor=new Color(0f,0f,0.03f), ambientSound="space" },
        new LevelData { levelNumber=46, environment=EnvironmentType.Space, planeSize=8f,  coinCount=9,  enemyCount=6, enemySpeed=5.9f, groundColor=new Color(0.03f,0.03f,0.08f),skyColor=new Color(0f,0f,0.03f), ambientSound="space" },
        new LevelData { levelNumber=47, environment=EnvironmentType.Space, planeSize=7f,  coinCount=9,  enemyCount=6, enemySpeed=6f,   groundColor=new Color(0.02f,0.02f,0.07f),skyColor=new Color(0f,0f,0.02f), ambientSound="space" },
        new LevelData { levelNumber=48, environment=EnvironmentType.Space, planeSize=6.5f,coinCount=9,  enemyCount=6, enemySpeed=6f,   groundColor=new Color(0.02f,0.02f,0.07f),skyColor=new Color(0f,0f,0.02f), ambientSound="space" },
        new LevelData { levelNumber=49, environment=EnvironmentType.Space, planeSize=6f,  coinCount=10, enemyCount=6, enemySpeed=6f,   groundColor=new Color(0.01f,0.01f,0.06f),skyColor=new Color(0f,0f,0.01f), ambientSound="space" },
        new LevelData { levelNumber=50, environment=EnvironmentType.Space, planeSize=5.5f,coinCount=10, enemyCount=6, enemySpeed=6f,   groundColor=new Color(0.01f,0.01f,0.06f),skyColor=new Color(0f,0f,0.01f), ambientSound="space" },
        new LevelData { levelNumber=51, environment=EnvironmentType.Space, planeSize=5f,  coinCount=10, enemyCount=6, enemySpeed=6f,   groundColor=new Color(0f,0f,0.05f),      skyColor=Color.black,            ambientSound="space" },
        new LevelData { levelNumber=52, environment=EnvironmentType.Space, planeSize=4f,  coinCount=10, enemyCount=6, enemySpeed=6f,   groundColor=new Color(0f,0f,0.05f),      skyColor=Color.black,            ambientSound="space" },
    };
    private bool _gameStarted = false;
    public int _currentLevel = 0;
    private int _coinsCollected = 0;
    private readonly List<GameObject> _spawned = new List<GameObject>();

    void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        Time.timeScale = 0f;
        if(startPanel != null) startPanel.SetActive(true);
        UpdateLevelText();
    }
    void Start()
    {
        int isRespawn = PlayerPrefs.GetInt("IsRespawn", 0);
        if(isRespawn ==1)
        {
            PlayerPrefs.SetInt("IsRespawn" , 0);
             _gameStarted = true;
            Time.timeScale = 1f;
            if(startPanel != null) startPanel.SetActive(false);
            LoadCheckpoint();
            GenerateLevel(); 
        }
        else
        {
           Time.timeScale = 0f;
           if(startPanel != null) startPanel.SetActive(true);
        }
    }
    
 
    public void GenerateLevel()
    {
        Time.timeScale = 1f ;
        var go = GameObject.FindWithTag("GameOver");
        if(go != null) go.SetActive(false);

        if (_currentLevel >= levels.Length)
        {
            Win();
            return;
        }
 
        ClearLevel();
        _coinsCollected = 0;
 
        LevelData data = levels[_currentLevel];
 
        SpawnPlane(data);
        SpawnEnemies(data);
        SpawnCoins(data);
 
        Debug.Log($"[PCG] Level {_currentLevel + 1} başladı | " +
                  $"Boyut: {data.planeSize} | Coin: {data.coinCount} | Düşman: {data.enemyCount}");
        
        UpdateLevelText();
        UpdateCoinText();

        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if(playerObj != null)
        {
            var playerAgent = playerObj.GetComponent<NavMeshAgent>();
            if(playerAgent != null)
            playerAgent.speed = levels[_currentLevel].enemySpeed * 0.8f;
        }
    }
   void Update()
{
    if(!_gameStarted) return;

    if (Input.GetKeyDown(KeyCode.N))
    {
        Time.timeScale = 1f;
        SavedCheckpoint();
        _currentLevel++;
        GenerateLevel();
        UpdateLevelText();

    }
}
    void UpdateLevelText()
    {
        if(levelTextUI == null) return;
        int bolum = (_currentLevel / 10) + 1;
        int seviye =(_currentLevel % 10) +1;
        if(bolum > 4)
        {
            bolum= 4;
            seviye = (_currentLevel - 30) + 1;
        }
        levelTextUI.text = "BOLUM" + bolum +"- SEVIYE " + seviye;
    }
    public void NextLevel()
    {
        _currentLevel++;
        int levelInChapter = _currentLevel % 10;
        if(levelInChapter == 0 || levelInChapter == 4)
        {
            PlayerPrefs.SetInt("SavedLevel", _currentLevel);
            PlayerPrefs.Save();
            Debug.Log("Checkpoint alındı mevcut level" + _currentLevel);
        
        }
        UpdateLevelText();
        ClearLevel();
        GenerateLevel();
    }
    void SavedCheckpoint()
    {
        int checkpoint = (_currentLevel / 5) * 5;
        PlayerPrefs.SetInt("SavedLevel" , checkpoint);
        PlayerPrefs.Save();
        Debug.Log($"[SAVE] Checkpoint kaydedildi: {checkpoint}");
    }
    public IEnumerator RespawnAtCheckpoint()
    {
        yield return new WaitForSecondsRealtime(3f);
        PlayerPrefs.SetInt("IsRespawn", 1);
        Time.timeScale = 1f;
        _currentLevel = PlayerPrefs.GetInt("SavedLevel", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }
    void LoadCheckpoint()
    {
        int saved = PlayerPrefs.GetInt("SavedLevel", 0);
        Debug.Log($"[LOAD] Kaydedilen checkpoint: {saved}");
        _currentLevel = saved;

    }
     
    void SpawnPlane(LevelData data)
    {
        Camera.main.backgroundColor = data.skyColor;
        var go = Instantiate(planePrefab, Vector3.zero ,Quaternion.identity, transform);
        go.transform.localScale = new Vector3(data.planeSize * 0.1f ,1f , data.planeSize * 0.1f);
      go.GetComponent<Renderer>().material.color = data.groundColor;
        _spawned.Add(go);

      float size = (data.planeSize * 0.1f) * 5f;
     AddWall(new Vector3(size, 1f, 0f),   new Vector3(0.1f, 2f, size * 2f));
     AddWall(new Vector3(-size, 1f, 0f),  new Vector3(0.1f, 2f, size * 2f));
     AddWall(new Vector3(0f, 1f, size),   new Vector3(size * 2f, 2f, 0.1f));
     AddWall(new Vector3(0f, 1f, -size),  new Vector3(size * 2f, 2f, 0.1f));
    }
    void AddWall(Vector3 pos, Vector3 scale)
     {
        var wall = new GameObject("Wall");
       wall.transform.position = pos;
       wall.transform.localScale = scale;
       wall.AddComponent<BoxCollider>();
       wall.transform.parent = transform;
       _spawned.Add(wall);
     }
   
    void SpawnEnemies(LevelData data)
    {
        float half = data.planeSize * 0.4f;
        for (int i = 0; i < data.enemyCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-half, half),
                1f,
                Random.Range(-half, half)
            );
            var go = Instantiate(enemyPrefab, pos, Quaternion.identity, transform);
            var npc = go.GetComponent<NPC>();
            if (npc != null) npc.gameOverText = gameOverText;
            _spawned.Add(go);
        }
    }
 
    void SpawnCoins(LevelData data)
    {
        float half = data.planeSize * 0.4f;
        for (int i = 0; i < data.coinCount; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-half, half),
                0.5f,
                Random.Range(-half, half)
            );
            var go = Instantiate(coinPrefab, pos, Quaternion.identity, transform);
            _spawned.Add(go);
        }
    }
 
    public void CoinCollected()
    {
        _coinsCollected++;
        UpdateCoinText();
        Debug.Log($"[Coin] {_coinsCollected}/{levels[_currentLevel].coinCount}");

        if(_coinsCollected >= levels[_currentLevel].coinCount)
        {
            SoundManager.Instance.PlayLevelComplete();
            SavedCheckpoint();
            _currentLevel++;
            GenerateLevel();
            UpdateLevelText();
            
        }
    }
    void UpdateCoinText()
    {
        if(coinTextUI != null) coinTextUI.text =$"{_coinsCollected} / {levels[_currentLevel].coinCount}";

    }
   
    public void StartGame()
    {
        _gameStarted = true;
        Time.timeScale = 1f;
        if(startPanel != null) startPanel.SetActive(false);
        LoadCheckpoint();
        GenerateLevel();
    }
    void Win()
    {
        PlayerPrefs.DeleteAll();
        _gameStarted = false;
        _currentLevel = 0;
        if(winText != null) winText.SetActive(true);
        SoundManager.Instance.PlayWin();
        Time.timeScale = 0f;
        Debug.Log("[WIN] Tüm levellar tamamlandı!");

    }
    public void ClearLevel()
    {
        foreach (var obj in _spawned)
        if(obj != null) Destroy (obj);
        _spawned.Clear();
    }
   
    public void RestartGame()
    {
        PlayerPrefs.SetInt("IsRespawn", 1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}



       

    
    

 

