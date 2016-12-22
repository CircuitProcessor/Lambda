namespace UnitSystems.Interfaces
{
    public interface IUnit
    {
        double Value { get; set; }
        string Symbol();
    }

    public interface IQuotientable<T1,T2>
    {
        T1 Dividend { get; set; }
        T2 Divider { get; set; }
    }

}