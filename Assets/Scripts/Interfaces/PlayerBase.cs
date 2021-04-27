namespace AlexSpace
{
    public class PlayerBase
    {
        public bool[] baseBoolBadArray;

        public bool[] baseBoolGoodArray;

        public BadBonus[] badCompArray;

        public GoodBonus[] goodCompArray;
        public PlayerBase(bool[] saveBadArray, bool[] saveGoodArray, BadBonus[] badArray, GoodBonus[] goodArray)
        {
            this.baseBoolBadArray = saveBadArray;
            this.baseBoolGoodArray = saveGoodArray;
            this.badCompArray = badArray;
            this.goodCompArray = goodArray;
        }
    }
}