using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using System.Linq;
using UnityEngine.AI;
using System;
using System.Reflection;

public class TaskPatrol : Node
{
    private List<Transform> tempWaypoints;
    private CreepBT _tree;
    private GameObject[] _rooms;
    private GameObject _chosenRoom;
    private IEnumerable<Transform> _powerEntrances;
    private List<Transform> _powerEntrancesList;
    private IEnumerable<Transform> _patrolPoints;
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
            _rooms = GameObject.FindGameObjectsWithTag("Room"); // get all rooms in the game-world
            ChooseRoom(); // choose room randomly
            ChoosePowerEntrance(); //choose power entrance of the chosen room
            InitWaypoints(); //get all patrol waypoints of the chosen room

            _tree.gameObject.transform.position = ((Transform)_powerEntrancesList.First()).position; //teleport creep to the entrance
            _currWaypointIndex = 0;
        }

        try
        {
            ChoosePatrolPoint(_currWaypointIndex);
            _agent.SetDestination(_currWaypoint.position);
            state = NodeState.RUNNING;
        }
        catch (IndexOutOfRangeException)
        {
            state = NodeState.SUCCESS;
        }

        return state;
    }

    private void InitWaypoints()
    {
        _patrolPoints = _chosenRoom.GetComponentsInChildren<Transform>().Where(x => x.CompareTag("PatrolPoint"));

        IEnumerator temp = _patrolPoints.GetEnumerator();
        int amountOfPatrolPoints = 0;
        foreach (Transform t in _patrolPoints)
        {
            amountOfPatrolPoints++;
        }
    }

    private void ChoosePatrolPoint(int index) 
    {
        Transform[] temp = _patrolPoints.ToArray();
        int rand = UnityEngine.Random.Range(1, 3);
        _currWaypoint = temp[index + rand];
    }

    private void ChooseRoom()
    {
        _chosenRoom = _rooms[UnityEngine.Random.Range(0, _rooms.Length)];
    }

    private void ChoosePowerEntrance()
    {
        _powerEntrances = _chosenRoom.GetComponentsInChildren<Transform>();

        _powerEntrancesList = new List<Transform>();

        foreach (var elem in _powerEntrances)
        {
            if (elem.tag == "PowerEntrance")
            {
                _powerEntrancesList.Add(elem);
            }
        }
    }

    private void TagWaypoint()
    {
        
    }
}
