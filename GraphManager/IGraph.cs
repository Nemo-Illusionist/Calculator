namespace GraphManager {
    public interface IGraph {
        void Add(ZedGraph.PointPairList ppList, double x, double y);
        void Update();
    }
}