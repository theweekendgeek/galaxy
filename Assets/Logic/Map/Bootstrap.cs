using System;
using System.Collections;
using System.Collections.Generic;
using logic.Species;
using Logic.Systems;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bootstrap : MonoBehaviour
{
    public NavMeshAgent ship;
    public bool paused = false;
    public List<GameObject> systems = new List<GameObject>();
    public GameObject species;
    
    // Start is called before the first frame update
    private void calculateNeighbours()
    {
       
        foreach (var systemi in systems)
        {
            ISystem sytsem = systemi.GetComponent(typeof(ISystem)) as ISystem;
            sytsem.calculateNeighbours();    
        }
    }

    void Start()
    {
        systems.AddRange(GameObject.FindGameObjectsWithTag("System"));
        
        calculateNeighbours();
        setSpecies();
        var destination = species.GetComponent<IHasSystems>().getHomeSystem();
        var target = systems[Random.Range(0, systems.Count - 1)];
        Debug.Log(target);
        species.GetComponent<IColonize>().colonize(target, destination);

    }

    private void SetShipDestination()
    {
        var randomSystem = systems[Random.Range(0, systems.Count-1)];
        ship.SetDestination(randomSystem.transform.position);
    }

    private void setSpecies()
    {
        systems.AddRange(GameObject.FindGameObjectsWithTag("System"));
        var randomSystem = systems[Random.Range(0, 4)];
        ISystem randomISystem = randomSystem.GetComponent(typeof(ISystem)) as ISystem;
        randomISystem.changeOwner(species.GetComponent<IHasSystems>());
        species.GetComponent<IHasSystems>().addSystemKnown(randomISystem);
        species.GetComponent<IHasSystems>().setHomeSystem(randomSystem);
        InvokeRepeating(nameof(MainLoop), 5f, 2.0f);

    }

    private void MainLoop()
    {
        if (paused) return;
        
        var spec = species.GetComponent(typeof(ISpecies)) as ISpecies;
        spec.calculateMove();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Time.timeScale = paused ? 1 :  0;
            paused = !paused;

        }
    }
}
