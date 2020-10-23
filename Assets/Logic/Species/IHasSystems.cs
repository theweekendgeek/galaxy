using Logic.Systems;
using UnityEngine;

namespace logic.Species
{
    public interface IHasSystems
    {
        void addSystemOwned(ISystem system);
        void addSystemKnown(ISystem system);
        void removeSystem(ISystem system);
        void findSystem(ISystem system);
        GameObject getHomeSystem();
        void setHomeSystem(GameObject system);

        Material getColor();
    }
}