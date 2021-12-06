using System;
using System.Collections.Generic;
using System.Linq;
class BingoBoard 
    {
        private (int, bool)[,] _board = new (int, bool)[,] {
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)},
            {(0, false),(0, false),(0, false),(0, false),(0, false)}};

        private int totalSum = 0;

        public BingoBoard(IReadOnlyList<string> rows)
        {
            for (var i = 0; i < rows.Count; i++)
            {
                var inputSplit = rows[i].Split(" ");
                inputSplit = inputSplit.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var row = Array.ConvertAll(inputSplit, int.Parse);
                for (var j = 0; j < row.Length; j++)
                {
                    if (_board != null)
                    {
                        _board[i, j] = (row[j], false);
                        totalSum += row[j];
                    } 
                }
            }
        }

        public (int sum, int winIndex) PlayNumbers(int[] numbers) 
        {
            for(int num=0; num<numbers.Length; num++)
            {
                for (var i = 0; i < _board.GetLength(0); i++)
                {
                    for (var j = 0; j < _board.GetLength(1); j++)
                    {
                        if (_board[i, j].Item1 != numbers[num]) continue;
                        _board[i, j].Item2 = true;
                        totalSum -= numbers[num];
                        if(hasBingo())
                        {
                            return (totalSum, num);
                        }
                    }
                }
                
            }

            return (-1, numbers.Length-1);
        }

        private bool hasBingo()
        {
            for (var i = 0; i < _board.GetLength(0); i++)
            {
                var length = 0;
                for (var j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i,j].Item2)
                    {
                        length++;
                    }
                    else
                    {
                        length = 0;
                    }
                }

                if (length == 5)
                {
                    return true;
                }
            }
            for (var i = 0; i < _board.GetLength(1); i++)
            {
                var length = 0;
                for (var j = 0; j < _board.GetLength(0); j++)
                {
                    if (_board[j,i].Item2)
                    {
                        length++;
                    }
                    else
                    {
                        length = 0;
                    }
                }

                if (length == 5)
                {
                    return true;
                }
            }
            return false;
        }
    }