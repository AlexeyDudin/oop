namespace Lab3_1.Interfaces
{
    public interface ICar
    {
        bool IsTurnedOn();
        Direction GetDirection();
        int GetSpeed();
        Gear GetGear();

        bool TurnOnEngine();
        bool TurnOffEngine();
        bool SetGear(int gear);
        bool SetGear(GearSelector gear);
        bool SetSpeed(int speed);
    }
}
