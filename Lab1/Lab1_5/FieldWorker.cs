using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab1_5
{
    public class FieldWorker
    {
        //Разделить FieldWorker от Field!!!
        public const int MAX_X = 100;
        public const int MAX_Y = 100;

        //не понятное поле
        private FieldEnums[][] fieldEnums;
        //То, что не меняет значение после выхода между функциями
        private Point CurrentPosition { get; set; }
        public FieldEnums[][] Field 
        {
            get => fieldEnums;
            set
            {
                fieldEnums = value;
                FillStartPoints(fieldEnums);
            }
        }

        //Вынести в Fill
        public List<Point> StartPoints { get; } = new List<Point>();

        //private void RecourciveFill()
        //{
        //    if (CanFillPoint(CurrentPosition))
        //    {
        //        if (fieldEnums[CurrentPosition.Y][CurrentPosition.X] != FieldEnums.StartPosition)
        //        {
        //            fieldEnums[CurrentPosition.Y][CurrentPosition.X] = FieldEnums.FillPoint;
        //        }
        //        CurrentPosition = CurrentPosition.Left;
        //        RecourciveFill(); //Left
        //        CurrentPosition = CurrentPosition.Rigth.Down;
        //        RecourciveFill(); //Down
        //        CurrentPosition = CurrentPosition.Up.Rigth;
        //        RecourciveFill(); //Right
        //        CurrentPosition = CurrentPosition.Left.Up;
        //        RecourciveFill(); //Up
        //        CurrentPosition = CurrentPosition.Down;
        //    }
        //}

        private void CycledFill()
        {
            Direction direction = SetDefaultDirection();
            List<FieldState> stateList = new List<FieldState>();
            do
            {
                if (CanFillPoint(CurrentPosition))
                {
                    direction = SetDefaultDirection();
                    FillPoint(stateList, CurrentPosition, direction);
                }
                else
                {
                    bool saveInfoIntoStateList = true;

                    direction = SetLastGoodState(stateList);
                    
                    if (CanSwitchDirection(direction))
                        direction = SwitchDirection(direction);
                    else
                        saveInfoIntoStateList = false;

                    if (saveInfoIntoStateList)
                    {
                        SaveState(stateList, CurrentPosition, direction);
                    }
                }
                MoveCurrentPosition(direction);
            } while (stateList.Any());
        }

        private Direction SetDefaultDirection()
        {
            return Direction.Left;
        }

        private Direction SetLastGoodState(List<FieldState> stateList)
        {
            CurrentPosition = stateList.Last().Point;
            var resultDirection = stateList.Last().Direction;
            stateList.RemoveAt(stateList.Count - 1);
            return resultDirection;
        }

        private void MoveCurrentPosition(Direction direction)
        {
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
        }

        private bool CanSwitchDirection(Direction direction)
        {
            return direction != Direction.Up;
        }

        private Direction SwitchDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    return Direction.Down;
                case Direction.Down:
                    return Direction.Right;
                case Direction.Right:
                    return Direction.Up;
                default:
                    return Direction.Up;
            }
        }

        private void FillPoint(List<FieldState> stateList, Point currentPosition, Direction direction)
        {
            direction = Direction.Left;
            SaveState(stateList, currentPosition, direction);
            if (fieldEnums[CurrentPosition.Y][CurrentPosition.X] != FieldEnums.StartPosition)
            {
                fieldEnums[CurrentPosition.Y][CurrentPosition.X] = FieldEnums.FillPoint;
            }
        }

        private void SaveState(List<FieldState> stateList, Point currentPosition, Direction direction)
        {
            FieldState state = new FieldState();
            state.Point = CurrentPosition;
            state.Direction = direction;
            stateList.Add(state);
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

        public static FieldEnums[][] LoadFieldFromFile(string fileName)
        {
            //initialize result
            FieldEnums[][] result = GetFieldEnumsInstance();

            string[] readLines = File.ReadAllLines(fileName);

            int rowCounter = 0;
            foreach (var line in readLines)
            {
                FillLine(line, ref result, rowCounter);
                rowCounter++;
            }

            return result;
        }

        private static void FillLine(string line, ref FieldEnums[][] result, int rowCounter)
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
        }

        private static FieldEnums[][] GetFieldEnumsInstance()
        {
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

            return result;
        }

        public static void SaveFieldToFile(FieldWorker field, string outputFileName)
        {
            RewriteFile(outputFileName);

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

        private static void RewriteFile(string outputFileName)
        {
            if (File.Exists(outputFileName))
                File.Delete(outputFileName);
        }
    }
}
