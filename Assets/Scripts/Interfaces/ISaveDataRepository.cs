namespace AlexSpace
{
    public interface ISaveDataRepository
    {
        void Save(PlayerBase player);

        void Load(PlayerBase player);
    }
}