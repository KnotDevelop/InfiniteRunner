using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlatformManager : MonoBehaviour
{
    public static PlatformManager instance;
    [SerializeField] Transform playerPos;
    [SerializeField] Transform platform;
    [SerializeField] Transform obstacle;
    Transform currentPlatform;
    Transform currentCheckPoint;
    [SerializeField] List<Transform> platformList = new List<Transform>();
    [SerializeField] List<Transform> scorePlatformList = new List<Transform>();
    [SerializeField] Material material;
    [SerializeField] Light dLight;
    [SerializeField] SpriteRenderer bg;
    int wave = 0;
    public float speed;
    bool isAction = false;
    [SerializeField] float colorH = 0;

    int obstacleMin = 0;
    int obstacleMax = 0;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        SetEnvironmentColor();
        currentPlatform = platformList[platformList.Count - 1];
        currentCheckPoint = SpawnPlatform();
    }
    private void Update()
    {
        if (!GameManager.Instance.isPlaying) return;
        transform.Translate(Time.deltaTime * speed, 0,0);
        if (playerPos.position.x <= scorePlatformList[0].position.x)
        {
            scorePlatformList.RemoveAt(0);
            GameManager.Instance.TakeScore();
            SetEnvironmentColor();
        }
        if (playerPos.position.x <= currentCheckPoint.position.x)
        {
            currentCheckPoint = SpawnPlatform();
        }
    }
    public void SetSpeed(int _score)
    {
        speed = 3.5f + (0.01f * _score);
        //PlayerAnimationManager.instance.SetAnimationRun_Speed(speed);
    }
    public void SetEnvironmentColor() 
    {
        material.color = Color.HSVToRGB(colorH, 0.6f, 1);
        dLight.color = Color.HSVToRGB(colorH, 0.3f, 1);
        bg.color = Color.HSVToRGB(colorH, 0.5f, 0.5f);
        colorH += 0.001f;
        if (colorH >= 1)
            colorH = 0;
    }
    public Transform SpawnPlatform()
    {
        Transform _tempValue = null;
        if (wave >= 2) 
        {
            for (int i = 0; i < 50; i++)
            {
                Destroy(platformList[0].gameObject);
                platformList.RemoveAt(0);
            }
        }
        for (int i = 0; i < 50; i++)
        {
            Transform _got = Instantiate(platform, transform);
            _got.position += new Vector3(currentPlatform.localPosition.x - 1, 0, 0);
            if (i % 2 == 0) 
            {
                RandomObstacle(_got);
                scorePlatformList.Add(currentPlatform);
            }
            platformList.Add(_got);
            currentPlatform = _got;
           
            if (i == 25)
            {
                _tempValue = _got;
            }
        }
        wave++;
        return _tempValue;
    }
    public void RotatePlatform(bool _result)
    {
        if (_result)
        {
            StartCoroutine(RotateBy90Degrees(transform.rotation, transform.rotation * Quaternion.Euler(90, 0, 0)));
        }
        else 
        {
            StartCoroutine(RotateBy90Degrees(transform.rotation, transform.rotation * Quaternion.Euler(-90, 0, 0)));
        }
    }
    private IEnumerator RotateBy90Degrees(Quaternion startValue, Quaternion endValue)
    {
        if (isAction) yield break;
        isAction = true;
        AudioManager.instance.Play_Swipe();
        float duration = 0.2f;
        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / duration;
            transform.rotation = Quaternion.Slerp(startValue, endValue, t);
            yield return null;
        }
        // Ensure the final rotation is set
        transform.rotation = endValue;
        isAction = false;
    }
    void DifficultCurve()
    {
        int _score = GameManager.Instance.GetScore();

        if (_score <= 150)
        {
            obstacleMin = 0;
            obstacleMax = 3;
        }
        else if (_score <= 300)
        {
            obstacleMin = 1;
            obstacleMax = 3;
        }
        else if (_score <= 450)
        {
            obstacleMin = 1;
            obstacleMax = 4;
        }
        else 
        {
            obstacleMin = 2;
            obstacleMax = 4;
        }

    }
    void RandomObstacle(Transform _pos)
    {
        DifficultCurve();
        int _rn = Random.Range(obstacleMin, obstacleMax);
        List<int> _obstaclePosIndex = GenerateUniqueRandomNumbers(0, 4, _rn);
        
        for (int i = 0; i < _obstaclePosIndex.Count; i++)
        {
            Transform _got = Instantiate(obstacle, _pos);
            _got.name = "Obstacle";
            switch (_obstaclePosIndex[i])
            {
                case 0:
                    _got.localPosition = new Vector3(0, 1, 0);
                    break;
                case 1:
                    _got.localPosition = new Vector3(0, -1, 0);
                    break;
                case 2:
                    _got.localPosition = new Vector3(0, 0, 1);
                    _got.localRotation = Quaternion.Euler(90, 0, 0);
                    break;
                case 3:
                    _got.localPosition = new Vector3(0, 0, -1);
                    _got.localRotation = Quaternion.Euler(90, 0, 0);
                    break;
            }
        }
    }
    List<int> GenerateUniqueRandomNumbers(int min, int max, int count)
    {
        if (count > max - min + 1)
        {
            Debug.LogError("Count cannot exceed the range of possible numbers.");
            return null;
        }

        HashSet<int> uniqueNumbers = new HashSet<int>();
        List<int> resultList = new List<int>();

        while (uniqueNumbers.Count < count)
        {
            int randomNumber = Random.Range(min, max);
            if (!uniqueNumbers.Contains(randomNumber))
            {
                uniqueNumbers.Add(randomNumber);
                resultList.Add(randomNumber);
            }
        }

        return resultList;
    }
}
