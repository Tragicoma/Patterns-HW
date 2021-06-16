using System;

namespace PatternsData
{
    [Serializable]
    public class Algorythms
    {
        public const int Size = 5;

        private FillStatusEnum[,] _table = new FillStatusEnum[Size,Size];

        public Algorythms()
        {
            CreateEmptyTable();
        }

        public void CreateEmptyTable()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _table[i, j] = FillStatusEnum.BoxEmpty;
                }
            }
        }

        public FillStatusEnum GetBoxValue(int row, int col)
        {
            CheckIfFieldIsValid(row, col);

            return _table[row, col];
        }

        private static void CheckIfFieldIsValid(int row, int col)
        {
            if (row < 0 || row > Size - 1 || col < 0 || col > Size - 1)
            {
                throw new ArgumentException("No such row or colum");
            }
        }

        public void FillCheckersPattern()
        {
            var fillInOdds = true;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if(j % 2 != 0 && fillInOdds)
                    {
                        _table[i, j] = FillStatusEnum.BoxFilled;
                    }
                    else if(j % 2 == 0 && !fillInOdds)
                    {
                        _table[i, j] = FillStatusEnum.BoxFilled;
                    }
                }

                fillInOdds = !fillInOdds;
            }
        }

    }
}
