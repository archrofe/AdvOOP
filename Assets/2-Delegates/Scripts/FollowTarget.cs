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
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;

        private NavMeshAgent agent;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }
    }
}