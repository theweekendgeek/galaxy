using System;
using logic.Species;
using UnityEngine;
using UnityEngine.AI;

namespace Logic.Ships
{
    public class Ship : MonoBehaviour, IColoniyShip, IShip
    {
        private ISpecies species;
        public void colonize(GameObject target)
        {
            Debug.Log("COLONIZING");
            GetComponent<NavMeshAgent>().SetDestination(target.transform.position);
        }

        public void SetOwner(ISpecies owner)
        {
            species = owner;
        }

        public ISpecies GetOwner()
        {
            return species;
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("TRIGGER ENTERED");
        }
    }
}