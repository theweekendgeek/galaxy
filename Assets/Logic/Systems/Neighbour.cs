using UnityEngine;

namespace Logic.Systems
{
    public class Neighbour
    {
        private ISystem system;
        private float distance;

        public Neighbour(ISystem system, float distance)
        {
            this.system = system;
            this.distance = distance;
        }

        public float Distance => distance;
    }
}