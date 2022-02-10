using Phantonia.Structures;

IGraphProvider prov = new RectangularGraphProvider(width: 4, height: 3);

GraphVertex<bool> graph = prov.GenerateGraph(defaultValue: false);
