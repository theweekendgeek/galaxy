using System;
using System.Collections.Generic;
using Logic.Ships;
using Logic.Systems;
using UnityEngine;

namespace logic.Species
{
    
    public class Species : MonoBehaviour, IColonize, IHasSystems, ISpecies
    {
        public string speciesName = "Gobbeldigook";
        public GameObject ship;
        public GameObject homeSystem;
        
        
        public Material speciesColor;
        public List<ISystem> systemsOwned = new List<ISystem>();
        public List<ISystem> systemsKnown = new List<ISystem>();

        public void Start()
        {
            InvokeRepeating(nameof(survey), 2.0f, 3.0f);
        }
        
        public void colonize(GameObject target, GameObject dest)
        {
            Debug.Log("AAAAAAa");
            var colonyShip = GameObject.Instantiate(
                ship, 
                dest.transform.position, 
                Quaternion.identity);

            Debug.Log(colonyShip);
            Debug.Log(target);
            var IColonyShip = colonyShip.GetComponent<IColoniyShip>();
            IColonyShip.colonize(target);
        }
        
        public void addSystemOwned(ISystem system)
        {
            systemsOwned.Add(system);
        }

        public void addSystemKnown(ISystem system)
        {
            systemsKnown.Add(system);
        }

        public void removeSystem(ISystem system)
        {
            throw new System.NotImplementedException();
        }

        public void findSystem(ISystem system)
        {
            addSystemKnown(system);
        }

        public GameObject getHomeSystem()
        {
            return homeSystem;
        }

        public void setHomeSystem(GameObject system)
        {
            homeSystem = system;
        }

        public Material getColor()
        {
            return speciesColor;
        }

        public void survey()
        {
            //Debug.Log("SURVEYING (SPECIES)");
            systemsKnown.ForEach(system =>
            {
               /// Debug.Log("in lambda");
                system.survey();
            });
            
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other);
        }

        public void calculateMove()
        {
            Debug.Log("Calculating");
        }

    }
}