using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBrickGroup : MonoBehaviour
{
    public int minBlocks, maxBlocks;
    int numQuestionBlocks;
    int numBlocks;
    public GameObject brickPrefab, questionBlockPrefab;
    float questionBlockWidth, brickWidth;
    public Collider brickCollider;

    void Start()
    {
        numBlocks = Random.Range(minBlocks, maxBlocks + 1);
        numQuestionBlocks = Random.Range(0,(int)(numBlocks/2) + 1);
        float width = CalculateWidth();
        float startZ = GetStartZ(width);
        GenerateBoxes(startZ);
    }

    void GenerateBoxes(float curZ) {
        int numBrickBlocks = numBlocks - numQuestionBlocks;
        Vector3 curPos = transform.position;
        curPos.z = curZ;
        while (numQuestionBlocks > 0 && numBrickBlocks > 0) {
            int randNum = Random.Range(0,3);
            if (randNum != 2) {
                CreateBrick(curPos);
                curPos.z += brickWidth;
                numBrickBlocks -= 1;
            } else {
                CreateQuestionBlock(curPos);
                curPos.z += questionBlockWidth;
                numQuestionBlocks -= 1;
            }
        }

        if (numQuestionBlocks > 0) {
            while (numQuestionBlocks > 0) {
                CreateQuestionBlock(curPos);
                curPos.z += questionBlockWidth;
                numQuestionBlocks -= 1;
            }
        } else {
            while (numBrickBlocks > 0) {
                CreateBrick(curPos);
                curPos.z += brickWidth;
                numBrickBlocks -= 1;
            }
        }

    }

    void CreateQuestionBlock(Vector3 curPos) {
        GameObject newQuestionBlock = Instantiate(questionBlockPrefab, curPos, Quaternion.Euler(Vector3.up));
        newQuestionBlock.transform.parent = transform;
    }

    void CreateBrick(Vector3 curPos) {
        GameObject newBrick = Instantiate(brickPrefab, curPos, Quaternion.Euler(Vector3.up));
        newBrick.transform.parent = transform;
    }

    float CalculateWidth() {
        GameObject tempQB = Instantiate(questionBlockPrefab);
        questionBlockWidth = tempQB.GetComponent<Collider>().bounds.size.z;
        Destroy(tempQB);
        GameObject tempBrick = Instantiate(brickPrefab);
        brickWidth = tempBrick.GetComponent<Collider>().bounds.size.z;
        Destroy(tempBrick);
        return (numQuestionBlocks * questionBlockWidth) + ((numBlocks - numQuestionBlocks) * brickWidth);
    }

    float GetStartZ(float width) {
        GameObject[] boundaries = GameObject.FindGameObjectsWithTag("Barrier");
        GameObject leftBoundary, rightBoundary;
        if (boundaries[0].transform.position.z < boundaries[1].transform.position.z) { 
            leftBoundary = boundaries[0]; 
            rightBoundary = boundaries[1];
        } else {
            rightBoundary = boundaries[0];
            leftBoundary = boundaries[1];
        }

        Bounds leftBounds = leftBoundary.GetComponent<Collider>().bounds;
        Bounds rightBounds = rightBoundary.GetComponent<Collider>().bounds;

        float curLeftZ = transform.position.z - (width/2);
        float curRightZ = transform.position.z + (width/2);
        
        float leftBoundZ = leftBoundary.transform.position.z + leftBounds.extents.z;
        float rightBoundZ = rightBoundary.transform.position.z - rightBounds.extents.z;

        if (curLeftZ < leftBoundZ ) {
            curLeftZ = leftBoundZ;
        } else if (curRightZ > rightBoundZ) {
            curLeftZ = rightBoundZ - width;
        }

        return curLeftZ;
    }

}
