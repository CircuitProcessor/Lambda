namespace UnitSystems.Interfaces
{
    public interface IUnit
    {
        double Value { get; set; }
        string Symbol { get; }
    }

}