using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    [SerializeField] GameObject branchPrefab;
    [SerializeField] int totalLevels = 3;
    Queue<GameObject> rootBranchesQueue = new Queue<GameObject>();
    int currentLevel = 1;
 
    void Start()
    {
        GameObject rootBranch = Instantiate(branchPrefab, transform);
        rootBranchesQueue.Enqueue(rootBranch);
        GenerateTree();
    }

    void GenerateTree() {

        if(currentLevel >= totalLevels) {
            return;
        }

        ++currentLevel;

        List<GameObject> branchesCreated = new List<GameObject>();

        while(rootBranchesQueue.Count > 0) {
            var rootBranch = rootBranchesQueue.Dequeue();
            var rightBranch = CreateBranch(rootBranch, -45f);
            var leftBranch = CreateBranch(rootBranch, 45f);

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
        newBranch.transform.localPosition = prevBranch.transform.localPosition + prevBranch.transform.up;
        newBranch.transform.localRotation = 
            prevBranch.transform.localRotation * Quaternion.Euler(0, 0, relativeAngle);
        return newBranch;
    }
}
