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
            FillTable(FillStatusEnum.BoxEmpty);
        }

        public void FillTable(FillStatusEnum fill)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _table[i, j] = fill;
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
            var fillInOdds = false;

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

        public void FillCrossPattern()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if(j==i)
                    {
                        _table[i, j] = FillStatusEnum.BoxFilled;
                    }
                    else if(j==_table.GetLength(0)-1-i)
                    {
                        _table[i, j] = FillStatusEnum.BoxFilled;
                    }
                }
            }
        }

        public void FillUsinsPattern()
        {
            FillTable(FillStatusEnum.BoxFilled);

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if(i % 2 ==0 && j == _table.GetLength(0)/2)
                    {
                        _table[i, j] = FillStatusEnum.BoxEmpty;
                    }
                    else if(i % 2 != 0 && (j==0 || j == Size - 1))
                    {
                        _table[i, j] = FillStatusEnum.BoxEmpty;
                    }
                }
            }
        }

    }
}
