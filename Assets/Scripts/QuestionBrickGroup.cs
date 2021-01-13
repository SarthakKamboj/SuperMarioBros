using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBrickGroup : MonoBehaviour
{
    public int minBlocks, maxBlocks;
    int numQuestionBlocks;
    int numBlocks;
    public GameObject brickPrefab, questionBlockPrefab;
    float width;
    void Start()
    {
        numBlocks = Random.Range(minBlocks, maxBlocks);
        numQuestionBlocks = Random.Range(0,(int)numBlocks/2);
        float questionBlockWidth = questionBlockPrefab.GetComponent<Collider>().bounds.size.z;
        float brickWidth = brickPrefab.GetComponent<Collider>().bounds.size.z;
        width = numQuestionBlocks * questionBlockWidth + (numBlocks - numQuestionBlocks) * brickWidth;
    }


    void Update()
    {
        
    }
}
