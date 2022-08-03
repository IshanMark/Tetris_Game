﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris_Game
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position (StartOffset.Row,StartOffset.Column);
        }
        public IEnumerable<Position> TilePosition() {
            foreach (Position pos in Tiles[rotationState]) { 
                yield return new Position (pos.Row+offset.Row, pos.Column+offset.Column);
            }
        }

        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        public void RotateCCW() {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else {
                rotationState--;
            }
        }

        public void Move(int rows, int cols) { 
            offset.Row += rows;
            offset.Column += cols;
        }

        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }
    }
}
