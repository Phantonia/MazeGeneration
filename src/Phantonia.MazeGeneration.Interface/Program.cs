using Phantonia.Structures;

IGraphProvider prov = new RectangularGraphProvider(width: 4, height: 3);

Graph<int> graph = prov.GenerateGraph();