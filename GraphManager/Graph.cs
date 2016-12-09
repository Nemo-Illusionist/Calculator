using System.Collections.Generic;
using System.Drawing;
using ZedGraph;

namespace GraphManager {
    public class Graph : IGraph {
        private readonly ZedGraphControl _graph;
        public List<PointPairList> Points;

        public Graph(ZedGraphControl graph) {
            _graph = graph;
            DrawGraph();
        }

        private void DrawGraph() {
            Points = new List<PointPairList>();
            // Получим панель для рисования
            GraphPane pane = _graph.GraphPane;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();
            // Создадим список точек
            //_temperature = new PointPairList();
            //_task = new PointPairList();

            // Щрифт меток
            pane.XAxis.Scale.FontSpec.Size = pane.YAxis.Scale.FontSpec.Size = 8;
            Grid(pane);

            // Подпись осей
            pane.XAxis.Title.Text = "Значения X";
            pane.YAxis.Title.Text = "Значения Y";
            pane.XAxis.Title.FontSpec.Size = pane.YAxis.Title.FontSpec.Size = 10;
            Legend(pane);

            // Опорные точки выделяться не будут (SymbolType.None)
            //LineItem temperatureLine = pane.AddCurve("Температура", _temperature, Color.Red, SymbolType.None);
            //LineItem taskLine = pane.AddCurve("Задание", _task, Color.Black, SymbolType.None);
            Update();
        }

        private void Grid(GraphPane pane) {
            // Включаем отображение сетки по осям
            pane.XAxis.MajorGrid.IsVisible = pane.YAxis.MajorGrid.IsVisible = true;
            pane.XAxis.MinorGrid.IsVisible = pane.YAxis.MinorGrid.IsVisible = true;

            // Задаем вид пунктирной линии по осям:
            pane.XAxis.MajorGrid.DashOn = pane.YAxis.MajorGrid.DashOn = 2;
            pane.XAxis.MajorGrid.DashOff = pane.YAxis.MajorGrid.DashOff = 0;
            pane.XAxis.MinorGrid.DashOn = pane.YAxis.MinorGrid.DashOn = 1;
            pane.XAxis.MinorGrid.DashOff = pane.YAxis.MinorGrid.DashOff = 1;
        }

        private void Legend(GraphPane pane) {
            // Указываем, что расположение легенды мы будет задавать 
            // в виде координат левого нижнего угла
            pane.Legend.Position = LegendPos.InsideBotLeft;
            // Координаты будут отсчитываться в системе координат окна графика
            pane.Legend.Location.CoordinateFrame = CoordType.ChartFraction;

            // Задаем выравнивание, относительно которого мы будем задавать координаты
            // В данном случае мы будем располагать легенду справа внизу
            pane.Legend.Location.AlignH = AlignH.Left;
            pane.Legend.Location.AlignV = AlignV.Bottom;
            pane.Legend.FontSpec.Size = 8;
        }

        public void Add(double X, double Y) {
            //_temperature.Add(X, Y);
            Update();
        }

        public void Update() {
            _graph.AxisChange();
            _graph.Invalidate();
        }


    }
}
