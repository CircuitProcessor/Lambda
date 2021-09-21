namespace UnitSystems
{
    public interface IUnit
    {
        string Symbol { get; }

        double Value { get; }
    }

}