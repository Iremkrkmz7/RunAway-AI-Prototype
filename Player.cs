using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
    }
    void Update()
    {
      if(LevelGenerator.Instance != null)
      {
          int currentLevel = Mathf.Clamp(LevelGenerator.Instance._currentLevel,0, LevelGenerator.levels.Length-1);
           agent.speed = LevelGenerator.levels[currentLevel].enemySpeed * 1.9f;
      }
      if(Input.GetMouseButtonDown(0))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }
      }   
    }
}
