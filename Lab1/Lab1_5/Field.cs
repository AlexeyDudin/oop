using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab1_5
{
    public class Field
    {
        public const int MAX_X = 100;
        public const int MAX_Y = 100;

        private FieldEnums[][] fieldEnums;
        private Point CurrentPosition { get; set; }
        public FieldEnums[][] FieldPole 
        {
            get => fieldEnums;
            set
            {
                fieldEnums = value;
                FillStartPoints(fieldEnums);
            }
        }

        public List<Point> StartPoints { get; } = new List<Point>();

        private void RecourciveFill()
        {
            if (CanFillPoint(CurrentPosition))
            {
                if (fieldEnums[CurrentPosition.Y][CurrentPosition.X] != FieldEnums.StartPosition)
                {
                    fieldEnums[CurrentPosition.Y][CurrentPosition.X] = FieldEnums.FillPoint;
                }
                CurrentPosition = CurrentPosition.Left;
                RecourciveFill(); //Left
                CurrentPosition = CurrentPosition.Rigth.Down;
                RecourciveFill(); //Down
                CurrentPosition = CurrentPosition.Up.Rigth;
                RecourciveFill(); //Right
                CurrentPosition = CurrentPosition.Left.Up;
                RecourciveFill(); //Up
                CurrentPosition = CurrentPosition.Down;
            }
        }

        private void CycledFill()
        {
            Direction direction = Direction.Left;
            List<CycledFiledState> stateList = new List<CycledFiledState>();
            do
            {
                if (CanFillPoint(CurrentPosition))
                {
                    CycledFiledState state = new CycledFiledState();
                    state.Point = CurrentPosition;
                    direction = Direction.Left;
                    state.Direction = direction;
                    stateList.Add(state);
                    if (fieldEnums[CurrentPosition.Y][CurrentPosition.X] != FieldEnums.StartPosition)
                    {
                        fieldEnums[CurrentPosition.Y][CurrentPosition.X] = FieldEnums.FillPoint;
                    }
                }
                else
                {
                    bool saveInfo = true;
                    CurrentPosition = stateList.Last().Point;
                    direction = stateList.Last().Direction;
                    stateList.RemoveAt(stateList.Count - 1);
                    switch (direction)
                    {
                        case Direction.Left:
                            direction = Direction.Down;
                            break;
                        case Direction.Down:
                            direction = Direction.Right;
                            break;
                        case Direction.Right:
                            direction = Direction.Up;
                            break;
                        case Direction.Up:
                            saveInfo = false;
                            break;
                    }
                    if (saveInfo)
                    {
                        CycledFiledState state = new CycledFiledState();
                        state.Point = CurrentPosition;
                        state.Direction = direction;
                        stateList.Add(state);
                    }
                }
                switch (direction)
                {
                    case Direction.Left:
                        CurrentPosition = CurrentPosition.Left;
                        break;
                    case Direction.Down:
                        CurrentPosition = CurrentPosition.Down;
                        break;
                    case Direction.Right:
                        CurrentPosition = CurrentPosition.Rigth;
                        break;
                    case Direction.Up:
                        CurrentPosition = CurrentPosition.Up;
                        break;
                }
            } while (stateList.Any());
        }

        public void FillField()
        {
            foreach(var point in StartPoints) 
            {
                CurrentPosition = point;
                //RecourciveFill();
                CycledFill();
            }
        }

        private bool CanFillPoint(Point point)
        {
            if (point.X < 0 || point.X >= MAX_X || point.Y < 0 || point.Y >= MAX_Y)
                return false;
            return (fieldEnums[point.Y][point.X] == FieldEnums.Space) || (fieldEnums[point.Y][point.X] == FieldEnums.StartPosition);
        }

        private void FillStartPoints(FieldEnums[][] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                for (int j = 0; j < field[i].Length; j++)
                {
                    if (field[i][j] == FieldEnums.StartPosition)
                    {
                        Point point = new Point(j, i);
                        StartPoints.Add(point);
                    }
                }
            }
        }

        public static FieldEnums[][] FillFieldFromFile(string fileName)
        {
            //initialize result
            FieldEnums[][] result = new FieldEnums[MAX_Y][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new FieldEnums[MAX_X];
            }
            //Initialize with space
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = FieldEnums.Space;
                }
            }

            string[] readLines = File.ReadAllLines(fileName);

            int rowCounter = 0;
            foreach (var line in readLines)
            {
                int positionCounter = 0;
                foreach (var symbol in line)
                {
                    switch (symbol)
                    {
                        case (char)FieldEnums.Space:
                            result[rowCounter][positionCounter] = FieldEnums.Space;
                            break;
                        case (char)FieldEnums.StartPosition:
                            result[rowCounter][positionCounter] = FieldEnums.StartPosition;
                            break;
                        default:
                            result[rowCounter][positionCounter] = FieldEnums.Border;
                            break;
                    }
                    positionCounter++;
                }
                rowCounter++;
            }

            return result;
        }

        public static void SaveFiledToFile(Field field, string outputFileName)
        {
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);
            List<string> result = new List<string>();
            foreach (var row in field.fieldEnums)
            {
                string resultString = "";
                foreach (var elem in row)
                {
                    resultString += (char)elem;
                }
                result.Add(resultString);
            }

            File.AppendAllLines(outputFileName, result);
        }
    }
}
