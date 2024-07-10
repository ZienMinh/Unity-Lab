using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static ScoreManager instance;
    [SerializeField] private TextMeshPro TextMeshPro;
    public int score;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    public void ChangeScore(int value)
    {
        score = score + value;
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro.text = score.ToString();
    }
}
