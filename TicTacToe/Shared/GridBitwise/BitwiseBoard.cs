﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToe.Shared.GridBitwise
{
    public class BitwiseBoard : IMutableBoard
    {
        private readonly int[] winCombinations = new int[]
        {
            0b111_000_000,
            0b000_111_000,
            0b000_000_111,
            0b100_100_100,
            0b010_010_010,
            0b001_001_001,
            0b100_010_001,
            0b001_010_100
        };
        public enum Player
        {
            X,
            O
        }

        private int Board => x_moves | o_moves;
        private int x_moves, o_moves;
        private Player currentPlayer;
        private bool finished;

        public BitwiseBoard()
        {
            x_moves = 0b000_000_000;
            o_moves = 0b000_000_000;
            currentPlayer = Player.X;
            finished = false;
        }

        private void SwitchTurn() => currentPlayer = currentPlayer == Player.X ? Player.O : Player.X;
        private bool hasWinner => winCombinations.Any(posMask => (posMask & CurrentPlayerMoves) == posMask); // bitmask check
        int CurrentPlayerMoves => currentPlayer == Player.X ? x_moves : o_moves;

        public IEnumerable<Cell> HomeMoves => this.CellsBelongingTo(Player.X);

        public IEnumerable<Cell> AwayMoves => this.CellsBelongingTo(Player.O);

        public IEnumerable<Cell> PlayableCells => this.CellsBelongingTo(null);

        private IEnumerable<Cell> CellsBelongingTo(Player? player) =>
            this.GetRowWiseContent()
                .Select((player, index) => (player, index))
                .Where(tuple => tuple.player == player)
                .Select(tuple => (row: tuple.index / 3, col: tuple.index % 3))
                .Select(cell => new Cell(cell.row, cell.col));

        public IEnumerable<Line> WinningLines =>
            this.GetLineCoords() is (int fromRow, int fromCol, int toRow, int toCol)
                ? new[] { new Line(new Cell(fromRow, fromCol), new Cell(toRow, toCol)) }
                : Enumerable.Empty<Line>();

        public void PlaceMark(int index)
        {
            if (finished || ((Board & (1 << index)) != 0)) // check if bit already set (position is taken)
                return;

            UpdateCurrentPlayerMoves(index);
            GetRowWiseContent();
            if (hasWinner)
            {
                Console.WriteLine($"{currentPlayer} won");
                finished = true;
                return;
            }
            else if (Board >= 511) // check tie (0b111_111_111)
            {
                Console.WriteLine("tie");
                finished = true;
                return;
            }

            SwitchTurn();
        }

        private void UpdateCurrentPlayerMoves(int index)
        {
            if (currentPlayer == Player.X)
                x_moves |= 1 << index;
            else
                o_moves |= 1 << index;
        }
        public (int fromRow, int fromCol, int toRow, int toCol)? GetLineCoords()
        {
            if (!hasWinner)
                return null;

            int luckyNumber = winCombinations.First(posMask => (posMask & CurrentPlayerMoves) == posMask);
            var binStr = new string(Convert.ToString(luckyNumber, 2).PadLeft(9).Reverse().ToArray());
            var fstIndex = binStr.IndexOf('1');
            var lstIndex = binStr.LastIndexOf('1');

            return (fstIndex / 3, fstIndex % 3, lstIndex / 3, lstIndex % 3);
        }

        private string MovesAsString(int moves) =>
            new string(Convert.ToString(moves, 2).PadLeft(9).Reverse().ToArray());


        public IEnumerable<Player?> GetRowWiseContent() =>
            this.MovesAsString(x_moves).Zip(
                this.MovesAsString(o_moves),
                (x, o) =>
                    x == '1' ? Player.X
                    : o == '1' ? Player.O
                    : (Player?)null);

        public void Play(Cell cell) =>
            this.PlaceMark(cell.Row * 3 + cell.Column);

        public int CountContinuations() => 0;
    }
}
