using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System.Linq;
using UnityEngine.AI;
using System;
using System.Reflection;
using JetBrains.Annotations;

public class TaskPatrol : Node
{
    private CreepBT _tree;
    private GameObject[] _rooms;
    private GameObject _chosenRoom;
    private IEnumerable<Transform> _powerEntrances;
    private List<Transform> _powerEntrancesList;
    private IEnumerable<Transform> _patrolPoints;
    private List<Transform> _patrolPointsList;
    private NavMeshAgent _agent;
    private int _currWaypointIndex;
    private Transform _currWaypoint;


    public TaskPatrol(BTree tree) : base(tree) {
        _tree = (CreepBT)tree;

        _agent = _tree.GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        
    }

    public override NodeState Evaluate()
    {
        if (state != NodeState.RUNNING)
        {
            _tree.gameObject.SetActive(true);
            _rooms = GameObject.FindGameObjectsWithTag("Room"); // get all rooms in the game-world
            _chosenRoom = _rooms[UnityEngine.Random.Range(0, _rooms.Length)]; // choose room randomly

            ChoosePowerEntrance(); //choose power entrance of the chosen room
            InitWaypoints(); //get all patrol waypoints of the chosen room

            _tree.gameObject.transform.position = _powerEntrancesList.First().position; //teleport creep to the entrance
            _currWaypointIndex = 0;
        }

        try
        {
            ChoosePatrolPoint(_currWaypointIndex);
            _agent.SetDestination(_currWaypoint.position);
            state = NodeState.RUNNING;
        }
        catch (ArgumentOutOfRangeException)
        {
            state = NodeState.SUCCESS;
            _currWaypointIndex = 0;
            _currWaypoint = null;
            _agent.SetDestination(_powerEntrancesList[0].position);
            _tree.gameObject.SetActive(false);
        }
        return state;
    }

    private void InitWaypoints()
    {
        _patrolPoints = _chosenRoom.GetComponentsInChildren<Transform>();
        _patrolPointsList = new List<Transform>();

        foreach(Transform waypoint in _patrolPoints)
        {
            if (waypoint.gameObject.tag == "PatrolPoint")
                _patrolPointsList.Add(waypoint);
        }
    }

    private void ChoosePatrolPoint(int index) 
    {
        int randomIndex = UnityEngine.Random.Range(1, _patrolPointsList.Count - 1);
        _currWaypoint = _patrolPointsList[randomIndex];
        _patrolPointsList.RemoveAt(randomIndex);
    }

    private void ChoosePowerEntrance()
    {
        _powerEntrances = _chosenRoom.GetComponentsInChildren<Transform>();

        _powerEntrancesList = new List<Transform>();

        foreach (var waypoint in _powerEntrances)
        {
            if (waypoint.gameObject.tag == "PowerEntrance")
                _powerEntrancesList.Add(waypoint);
        }
    }
}
