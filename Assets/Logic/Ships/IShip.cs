using logic.Species;

namespace Logic.Ships
{
    public interface IShip
    {
        void SetOwner(ISpecies owner);
        ISpecies GetOwner();
    }
}