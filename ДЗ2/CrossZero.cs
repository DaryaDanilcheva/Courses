using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ДЗ2
{
    public class CrossZero
    {
        public int Size { get; set; } = 0;
        int count;

        public string[,] Field { get; set; }

        public void Fill(int fieldSize)
        {
            Size = fieldSize;
            Field = new string[fieldSize, fieldSize];
            for (int i = 0; i < fieldSize; i++)
            {
                for (int j = 0; j < fieldSize; j++)
                {
                    Field[i, j] = ".";
                }
            }
            count = fieldSize * fieldSize;
        }

        public string Win()
        {
            for (int i = 0; i < Size; i++)
            {
                if (Field[i, 0] != ".")
                {
                    for (int j = 1; j < Size; j++)
                    {
                        if (Field[i, 0] == Field[i, j])
                        {
                            if (j == Size - 1)
                                return Field[i, j];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < Size; i++)
            {
                if (Field[0, i] != ".")
                {
                    for (int j = 1; j < Size; j++)
                    {
                        if (Field[0, i] == Field[j, i])
                        {
                            if (j == Size - 1)
                                return Field[j, i];
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            for (int i = 0; i < Size - 1; i++)
            {
                if (Field[0, 0] != ".")
                {
                    if (Field[i, i] == Field[i + 1, i + 1])
                    {
                        if (i == Size - 2)
                            return Field[i, i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            for (int i = 0; i < Size - 1; i++)
            {
                if (Field[0, Size - 1] != ".")
                {
                    if (Field[i, Size - i - 1] == Field[i + 1, Size - i - 2])
                    {
                        if (i == Size - 2)
                            return Field[i, Size - 1 - i];
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return ".";
        }
    }
}
