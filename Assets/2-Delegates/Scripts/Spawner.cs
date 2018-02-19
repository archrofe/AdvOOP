/*=============================================
-----------------------------------
Copyright (c) 2018 Archer Rofe
-----------------------------------
@file: Spawner.cs
@date: 19/02/2018
@author: Archer Rofe
@brief: Script for spawning objects via delegates
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Delegates
{
    public class Spawner : MonoBehaviour
    {
        public Transform target;
        public GameObject trollPrefab, orcPrefab;
        public float spawnAmount = 10; // Spawn amount for eac prefab
        public float spawnRate = 0.5f;

        private float spawnTimer = 0f;

        public delegate void SpawnDelegate();
        public SpawnDelegate spawnCallback;

        // Use this for initialization
        void Start()
        {
            // Subsribe all functions to delegate
            spawnCallback += SpawnOrc;
            spawnCallback += SpawnTroll;
        }

        // Update is called once per frame
        void Update()
        {
            // Count up the timer
            spawnTimer += Time.deltaTime;
            // Has timer reached spawn rate?
            if (spawnTimer >= spawnRate)
            {
                // Loop through and spawn orcs and trolls
                for (int i = 0; i < spawnAmount; i++)
                {
                    spawnCallback.Invoke();
                }
                // Reset spawn timer
                spawnTimer = 0f;
            }
        }

        void SpawnOrc()
        {
            GameObject clone = Instantiate(orcPrefab, transform.position, transform.rotation);

            FollowTarget agent = clone.GetComponent<FollowTarget>();
            agent.target = target;
        }

        void SpawnTroll()
        {
            GameObject clone = Instantiate(trollPrefab, transform.position, transform.rotation);

            FollowTarget agent = clone.GetComponent<FollowTarget>();
            agent.target = target;
        }
    }
}