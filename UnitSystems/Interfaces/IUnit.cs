namespace UnitSystems.Interfaces
{
    public interface IUnit
    {
        string Symbol { get; }

        double Value { get; }
    }

}