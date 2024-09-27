public interface ITowerUnitState
{
    void EnterState(TowerUnitValues unitValues);
    void UpdateState(TowerUnitValues unitValues);
    void ExitState(TowerUnitValues unitValues);
}
