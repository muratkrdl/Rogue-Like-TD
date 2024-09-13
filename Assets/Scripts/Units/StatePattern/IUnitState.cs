public interface IUnitState
{
    void EnterState(UnitValues unitValues);
    void UpdateState(UnitValues unitValues);
    void ExitState(UnitValues unitValues);
}
