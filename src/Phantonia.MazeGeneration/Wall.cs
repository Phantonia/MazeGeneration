namespace Phantonia.MazeGeneration;

public readonly record struct Wall(int LowerCellIndex, int HigherCellIndex);
