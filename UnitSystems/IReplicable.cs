namespace UnitSystems
{
    public interface IReplicable<out T>
        where T : struct, IUnit
    {
        T ReplicateFrom(double value);
    }
}