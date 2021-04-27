namespace AlexSpace
{
    public interface ISaveDataRepository
    {
        void Save(BonusArrayController player);

        void Load(BonusArrayController player);
    }
}