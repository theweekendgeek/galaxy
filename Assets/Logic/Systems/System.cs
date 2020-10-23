using System.Collections.Generic;
using System.Linq;
using logic.Species;
using UnityEngine;
using NotImplementedException = System.NotImplementedException;

namespace Logic.Systems
{
    public class System : MonoBehaviour, ISystem
    {
        public Material systemColor;
        private int colliderSurveySteps = 4;
        private List<Neighbour> neighbours = new List<Neighbour>();
        
        public void changeOwner(IHasSystems species)
        {
            Debug.Log("changing owner");
            species.addSystemOwned(this);
            updateColor(species.getColor());
        }

        public Species getOwner()
        {
            throw new NotImplementedException();
        }

        public void survey()
        {
            //Debug.Log("Surveying");
            GetComponent<CapsuleCollider>().radius += colliderSurveySteps;
            //Debug.Log("ColliderSize:");
            //Debug.Log(GetComponent<CapsuleCollider>().radius);
        }

        private void updateColor(Material newColor)
        {
            GetComponent<MeshRenderer> ().material = newColor;
        }


        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Collision");
            Debug.Log(other);        
        }

        public void calculateNeighbours()
        {
            var radius = 2;
            var layerMask = 1 << 8;
            Collider[] systems;
            //systems = Physics.OverlapSphere(transform.position, 500f, layerMask);

            do
            {
                systems = Physics.OverlapSphere(transform.position, radius, layerMask);
                radius += 2;
            } while (systems.Length < 6);
            
            foreach (var system in systems)
            {
                var distance = Vector3.Distance(transform.position, system.transform.position);
                var sys = system.GetComponent<System>();
                if (distance > 0)
                {
                    var neighbour = new Neighbour(sys, distance);
                    neighbours.Add(neighbour);
                }
          
            }

            neighbours = neighbours.OrderBy(neighbour => neighbour.Distance).ToList();
        }
    }
}