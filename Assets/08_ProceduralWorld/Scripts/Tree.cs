using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    const int INDEX_OF_SQUARE_CHILD = 0;
    const int INDEX_OF_CIRCLE_CHILD = 1;
    [SerializeField] GameObject branchPrefab;
    [SerializeField] int totalLevels = 3;
    [SerializeField] float initialSize = 5;
    [SerializeField, Range(0f, 1f)] float reductionPerLevel = 0.1f;
    Queue<GameObject> rootBranchesQueue = new Queue<GameObject>();
    int currentLevel = 1;
 
    void Start()
    {
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        ChangeBranchSize(rootBranch, initialSize); 
        rootBranchesQueue.Enqueue(rootBranch);
        GenerateTree();
    }

    void GenerateTree() {

        if(currentLevel >= totalLevels) {
            return;
        }

        ++currentLevel;

        float newSize = Mathf.Max(initialSize - initialSize * reductionPerLevel * (currentLevel - 1), 0.1f);
        var branchesCreated = new List<GameObject>();

        while(rootBranchesQueue.Count > 0) {
            var rootBranch = rootBranchesQueue.Dequeue();
            var rightBranch = CreateBranch(rootBranch, -Random.Range(10,40));
            var leftBranch = CreateBranch(rootBranch, Random.Range(10, 40));

            ChangeBranchSize(leftBranch, newSize);
            ChangeBranchSize(rightBranch, newSize);

            branchesCreated.Add(leftBranch);
            branchesCreated.Add(rightBranch);
        }

        foreach(var newBranches in branchesCreated) {
            rootBranchesQueue.Enqueue(newBranches);
        }

        GenerateTree();
    }
    
    private GameObject CreateBranch(GameObject prevBranch, float relativeAngle) {
        GameObject newBranch = Instantiate(branchPrefab, transform);
        newBranch.transform.localPosition = prevBranch.transform.localPosition + prevBranch.transform.up *
            GetBranchLenght(prevBranch);
        newBranch.transform.localRotation = 
            prevBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);
        return newBranch;
    }

    void ChangeBranchSize(GameObject branchesInstance, float newSize) {
        var squere = branchesInstance.transform.GetChild(INDEX_OF_SQUARE_CHILD);
        var circle = branchesInstance.transform.GetChild(INDEX_OF_CIRCLE_CHILD);

        //Square Conf
        var newScale = squere.transform.localScale;
        newScale.y = newSize;
        squere.transform.localScale = newScale;

        var newPosition = squere.transform.localPosition;
        newPosition.y = newPosition.y = newSize / 2;
        squere.transform.localPosition = newPosition;

        //Circle Conf
        var newCirclePosition = circle.transform.localPosition;
        newCirclePosition.y = newSize;
        circle.transform.localPosition = newCirclePosition;

    }

    float GetBranchLenght (GameObject branchInstance) {
        return branchInstance.transform.GetChild(INDEX_OF_SQUARE_CHILD).localScale.y;
    }
}
