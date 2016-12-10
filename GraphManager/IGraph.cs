using System.Collections.Generic;

namespace GraphManager
{
    public interface IGraph
    {
        void AddLine(List<double> x, List<double> y);
        void Clear();
        void Clear(int index);
        void Update();
    }
}