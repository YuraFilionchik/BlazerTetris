using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components
{
    public class GameFieldModel : ComponentBase
    {
        public int Col_count = 10;
        public int Row_count = 20;
        public Color DefaultColor = Color.Transparent; //empty cell
        [Parameter]
        public Size Size { get; set; } //size of game field
        public CellComponentmodel[,] Cells; //конечный вариант поля для отрисовки
        public CellComponentmodel[,] StaticCells; //неподвижное поле с уже лежащими фигурами
        private Timer timer;
        private FigureBuilder builder;
        public iFigure CurrentFigure;
        public iFigure NextFigure;
        
        public int CellSize { get
            {
                return (int)((Size.Height) / Row_count);
            } }

        protected override void OnInitialized()
        {
            
            
        }
public static GameFieldModel Game ;
        public GameFieldModel()
        {
            Game=this;
            if (Size.Height == 0 || Size.Width == 0) Size = new Size { Height = 600, Width = 300 };
            Cells = new CellComponentmodel[Row_count, Col_count];
            builder=new FigureBuilder(CellSize);
            GenerateField();
            StaticCells = GameFieldModel.CopyField(Cells);
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            FreeFall(CurrentFigure);
            StateHasChanged();
        }
        public void DrawFigure(iFigure figure)
        {

        }
        /// <summary>
        /// true - success
        /// false - end game
        /// </summary>
        /// <param name="figure"></param>
        /// <returns></returns>
        public bool FreeFall(iFigure figure)
        {
            var movedFig = CurrentFigure.Move(0, 1);
            if (IsFigureInButtom(movedFig) || IsCollisionOldCells(movedFig,StaticCells))//on floor
            {
                StaticCells = AttemptFigure(CurrentFigure.Cells, StaticCells); //объединение фигуры и поля
                CurrentFigure = NextFigure;
                NextFigure = builder.BuildRandom();
                Cells = AttemptFigure(CurrentFigure.Cells, StaticCells);
                if (IsCollisionOldCells(CurrentFigure.Cells, StaticCells)) {
                    timer.Stop();
                    return false; //Game over
}
                
            }
            else
            {
                CurrentFigure.Cells = movedFig;//отображаем сдвинутую фигуру
                Cells = AttemptFigure(CurrentFigure.Cells, StaticCells);
            }
            return true;
        }
        public void GenerateField()
        {
            for (int row = 0; row < Row_count; row++)
            {
                for (int column = 0; column < Col_count; column++)
                {

                    Cells[row, column] = new CellComponent();
                    var cell = Cells[row, column];
                    cell.SetColor(DefaultColor);
                    cell.SetEmpty(true);
                    cell.SetCellSize(CellSize);
                    cell.SetPosInField(new Point { Y = row, X = column });
                    //cell.SetPositionABS();
                }
            }
        }

        public void ClearField()
        {
            for(int row=0; row<Row_count;row++)
            {
                for(int column=0; column<Col_count;column++)
                {
                    Cells[row, column].SetColor(DefaultColor);
                    Cells[row, column].SetEmpty(true);
                }
            }
        }

        public void StopGame()
        {
            //timer.Stop();
            FreeFall(CurrentFigure);
        }
        public void StartGame()
        {
            ClearField();
            NextFigure = builder.BuildRandom();
            CurrentFigure = builder.BuildRandom();
            Cells = AttemptFigure(CurrentFigure.Cells, StaticCells);
            StateHasChanged();
           // timer.Start();
        }

        /// <summary>
        /// add figure.cells to field
        /// </summary>
        /// <param name="cells"></param>
        /// <param name="statFielCells"></param>
        /// <returns></returns>
        private CellComponentmodel[,] AttemptFigure(CellComponentmodel[] cells, CellComponentmodel[,] statFielCells)
        {
            CellComponentmodel[,] newField = GameField.CopyField(statFielCells);
            foreach (CellComponentmodel cell in cells)
            {
                newField[cell.PosInField.Y, cell.PosInField.X] = cell;
            }

            return newField;
        }

        public static CellComponentmodel[] FillCells(CellComponentmodel[] cells, Color color)
        {
            for(int i=0; i<cells.Count();i++)
            {
                cells[i].SetColor(color);
                cells[i].SetEmpty(false);
            }
            return cells;
        }
        public static CellComponentmodel[] CreateCells(int count,int cellSize)
        {
            CellComponentmodel[] cells = new CellComponentmodel[count];
            for (int i = 0; i < count; i++)
            {
                cells[i] = new CellComponentmodel();
                cells[i].SetCellSize(cellSize);
            }
            return cells;
        }

        public static CellComponentmodel[,] CopyField(CellComponentmodel[,] cells)
        {
            var rows = cells.GetUpperBound(0)+1;
            if (rows == 0) return new CellComponentmodel[0, 0];
            var columns = cells.Length / rows;
            CellComponentmodel[,] newCells = new CellComponentmodel[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    newCells[i,j] = CellComponentmodel.CopyCell(cells[i,j]);
                }
            }
            return newCells;
        }

        public bool IsCollisionBorder(CellComponentmodel[] fig)
        {
            //check out of field
            return fig.Any(x => x.PosInField.X < 0 ||
                                x.PosInField.Y < 0 ||
                                x.PosInField.X > Col_count - 1 ||
                                x.PosInField.Y > Row_count - 1);
        }
        public bool IsFigureInButtom(CellComponentmodel[] fig)
        {
            return fig.Any(x => x.PosInField.Y > Row_count - 1);
        }
        public bool IsCollisionOldCells(CellComponentmodel[] fig, CellComponentmodel[,] staticfield)
        {
            var rows = staticfield.GetUpperBound(0);
            var columns = staticfield.Length / rows;
           
            //check collision with static cells
            foreach (CellComponentmodel cell in staticfield)
            {
                if (cell.Empty) continue;
                if (fig.Any(x => x.PosInField == cell.PosInField)) return true;
            }

            return false;
        }

    }
}
