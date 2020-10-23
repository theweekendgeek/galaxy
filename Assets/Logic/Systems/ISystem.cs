using logic.Species;

namespace Logic.Systems
{
    public interface ISystem
    {
        void changeOwner(IHasSystems species);
        Species getOwner();
        void survey();
        void calculateNeighbours();
    }
}