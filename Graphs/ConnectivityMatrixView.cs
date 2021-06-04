using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphsAlgorithms;

namespace Graphs
{
    class ConnectivityMatrixView
    {
        private System.Windows.Forms.GroupBox workspace;
        private GraphsAlgorithms.Interfaces.IGraph graph;
        private GraphsAlgorithms.GraphsTypes graphType = GraphsAlgorithms.GraphsTypes.Simple;
        private int pointCount = 0;
        private string linkAbscenseValue = "-9999";
        private readonly string namingPattern = "{0}_{1}";
        private readonly string linkBaseName = "linkName";
        private readonly string pointBaseName = "pointName";
        private string[] pointsDefaultNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K" };
        private string[] simpleGraphPositions = { "x", "🗘" };
        private string[] directedGraphPositions = { "x", "🗘", "⮭", "⮨" };

        public ConnectivityMatrixView(System.Windows.Forms.GroupBox space, int count, string linkAbscenseValue)
        {
            this.workspace = space;
            this.pointCount = count;
            this.linkAbscenseValue = linkAbscenseValue;
            this.BuildView();
        }

        public void ChangeLinkAbscense(string value)
        {
            if (graphType != GraphsAlgorithms.GraphsTypes.Weight) {
                linkAbscenseValue = value;
                return;
            };
            for (int i = 0; i < this.pointCount; i++)
            {
                for (int j = 0; j < this.pointCount; j++)
                {
                    if (i == j) continue;
                    string linkName = string.Format(linkBaseName + namingPattern, i, j);
                    var input = (System.Windows.Forms.TextBox)this.workspace.Controls.Find(linkName, false)[0];
                    if (input.Text == linkAbscenseValue) input.Text = value;
                }
            }
            linkAbscenseValue = value;
        }


        public GraphsAlgorithms.Interfaces.IGraph GetGraph()
        {
            GraphsAlgorithms.Interfaces.IGraph graph = new GraphsAlgorithms.Data.UndirectedGraph((uint)this.pointCount);
            switch (this.graphType) {
                case GraphsAlgorithms.GraphsTypes.Simple:
                    this.fillGraph(ref graph);
                    break;
                case GraphsAlgorithms.GraphsTypes.Directed:
                    graph = new GraphsAlgorithms.Data.DirectedGraph((uint)this.pointCount);
                    this.fillGraph(ref graph);
                    break;
                case GraphsAlgorithms.GraphsTypes.Weight:
                    var weightedGraph = new GraphsAlgorithms.Data.WeightedGraph((uint)this.pointCount);
                    this.fillWeightedGraph(ref weightedGraph);
                    return weightedGraph;
            }
            return graph;
        }

        public void ChangeGraphType(GraphsAlgorithms.GraphsTypes type)
        {
            this.graphType = type;
            this.BuildView();
        }

        public void ChangePointsCount(int count)
        {
            this.pointCount = count;
            this.BuildView();
        }

        private void fillGraph(ref GraphsAlgorithms.Interfaces.IGraph graph)
        {
            var points = this.getGraphsPoints();
            graph.AddPoints(points);
            for (int x = 0; x < this.pointCount; x++)
            {
                for (int y = 0; y < x; y++)
                {
                    if (x == y) continue;
                    string linkName = string.Format(linkBaseName + namingPattern, x, y);
                    var input = (System.Windows.Forms.Button)this.workspace.Controls.Find(linkName, false)[0];
                    if (this.graphType == GraphsAlgorithms.GraphsTypes.Simple)
                    {
                        if (input.Text == this.simpleGraphPositions[1])
                            graph.AddLink(points[x], points[y]);
                    }
                    else if (this.graphType == GraphsAlgorithms.GraphsTypes.Directed)
                    {
                        if (input.Text == this.directedGraphPositions[1])
                        {
                            graph.AddLink(points[x], points[y]);
                            graph.AddLink(points[y], points[x]);
                        }
                        if (input.Text == this.directedGraphPositions[2])
                            graph.AddLink(points[y], points[x]);
                        if (input.Text == this.directedGraphPositions[3])
                            graph.AddLink(points[x], points[y]);
                    }
                }
            }
        }

        private void fillWeightedGraph(ref GraphsAlgorithms.Data.WeightedGraph graph)
        {
            var points = this.getGraphsPoints();
            graph.AddPoints(points);
            for (int x = 0; x < this.pointCount; x++)
            {
                for (int y = 0; y < this.pointCount; y++)
                {
                    if (x == y) continue;
                    string linkName = string.Format(linkBaseName + namingPattern, x, y);
                    var input = (System.Windows.Forms.TextBox)this.workspace.Controls.Find(linkName, false)[0];
                    if (input.Text == linkAbscenseValue) continue;
                    var value = Int32.Parse(input.Text);
                    graph.AddLink(points[x], points[y], value);
                }
            }
        }

        private string getAlternativeLinkValue(string item)
        {
            switch (graphType)
            {
                case GraphsAlgorithms.GraphsTypes.Simple:
                    return item;
                case GraphsAlgorithms.GraphsTypes.Directed:
                    if (item == directedGraphPositions[2]) return directedGraphPositions[3];
                    if (item == directedGraphPositions[3]) return directedGraphPositions[2];
                    return item;
                default:
                    throw new Exception("This graph type is unsupported for alternative value method");
            }
        }

        private string[] getGraphsPoints()
        {
            string[] points = new string[this.pointCount];
            for (int i = 0; i< this.pointCount; i++)
            {
                var name = string.Format(pointBaseName + namingPattern, "X", i);
                var input = (System.Windows.Forms.TextBox)this.workspace.Controls.Find(name, false)[0];
                points[i] = input.Text;
            }
            return points;
        }

        private (int, int) parseButtonNameIndexes(string name)
        {
            name = name.Replace(linkBaseName, "");
            string[] indexes = name.Split('_');
            var x = Int32.Parse(indexes[0]);
            var y = Int32.Parse(indexes[1]);
            return (x, y);
        }

        private (string, int) parsePointNameIndex(string name)
        {
            name = name.Replace(pointBaseName, "");
            string[] indexes = name.Split('_');
            var axis = indexes[0];
            var index = Int32.Parse(indexes[1]);
            return (axis, index);
        }

        private string getNextItem(string item, string[] arr)
        {
            int index = Array.IndexOf(arr, item);
            if (arr.Length == 0) throw new Exception("Array is empty");
            if (index == -1) throw new Exception("Item is not in this arr");
            if (index == arr.Length - 1) return arr[0];
            return arr[index + 1];
        }

        private void BuildView()
        {
            this.workspace.Controls.Clear();
            this.BuildViewPoints();
            this.BuildViewLinks();
        }

        private void BuildViewLinks()
        {
            for (int i = 0; i < this.pointCount; i++)
            {
                for (int j = 0; j < this.pointCount; j++)
                {
                    this.workspace.Controls.Add(LinksField(i, j));
                }
            }
        }

        private void ghraphLinkClicked(object sender, EventArgs e)
        {
            var button = (System.Windows.Forms.Button)sender;
            if(graphType == GraphsAlgorithms.GraphsTypes.Simple)
                button.Text = getNextItem(button.Text, simpleGraphPositions);
            if (graphType == GraphsAlgorithms.GraphsTypes.Directed)
                button.Text = getNextItem(button.Text, directedGraphPositions);
            (int x, int y) = parseButtonNameIndexes(button.Name);
            string alternativeButtonName = string.Format(linkBaseName + namingPattern, y, x);
            var alternativeButton = (System.Windows.Forms.Button)this.workspace.Controls.Find(alternativeButtonName, false)[0];
            alternativeButton.Text = getAlternativeLinkValue(button.Text);
            alternativeButton.Focus();
        }

        private System.Windows.Forms.Control LinksField(int indexX, int indexY)
        {
            int marginTop = 20;
            int marginLeft = 10;
            int spaceBetween = 10;
            System.Windows.Forms.Control control;
            switch (this.graphType)
            {
                case GraphsTypes.Simple:
                    control = new System.Windows.Forms.Button();
                    control.Click += this.ghraphLinkClicked;
                    control.Text = this.simpleGraphPositions[0];
                    break;
                case GraphsTypes.Directed:
                    control = new System.Windows.Forms.Button();
                    control.Text = this.directedGraphPositions[0];
                    control.Click += this.ghraphLinkClicked;
                    break;
                case GraphsTypes.Weight:
                    control = new System.Windows.Forms.TextBox();
                    control.Text = linkAbscenseValue;
                    ((System.Windows.Forms.TextBox)control).TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                    break;
                default:
                    throw new ArgumentException("Parameter graphType is not defined");
            }

            control.Font = new System.Drawing.Font(control.Font.FontFamily, 12);
            control.Name = string.Format(linkBaseName+namingPattern, indexX, indexY);
            control.Height = 30;
            control.Width = 40;
            control.Top = marginTop;
            control.Left = marginLeft;
            control.Top += (indexY + 1) * (20 + spaceBetween);
            control.Left += (indexX + 1) * (30 + spaceBetween);
            if (indexX == indexY)
            {
                control.Enabled = false;
                control.Text = "";
                return control;
            }
            
            if (this.graphType == GraphsTypes.Weight)
            {
                ((System.Windows.Forms.TextBox)control).MinimumSize = new System.Drawing.Size(30, 26);
                ((System.Windows.Forms.TextBox)control).Font = new System.Drawing.Font(control.Font.FontFamily, 8);
            }
            return control;

        }

        private void BuildViewPoints()
        {
            for (int i = 0; i < this.pointCount; i++)
            {
                this.workspace.Controls.Add(PointNameField(i, true));
                this.workspace.Controls.Add(PointNameField(i, false));
            }
        }


        private void ghraphPointNameChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox field = (System.Windows.Forms.TextBox)sender;
            (string axis, int index) = parsePointNameIndex(field.Name);
            string altPointNameField = string.Format(pointBaseName + namingPattern, axis == "Y" ? "X" : "Y", index);
            var altPointName = (System.Windows.Forms.TextBox)this.workspace.Controls.Find(altPointNameField, false)[0];
            altPointName.Text = field.Text;
        }


        private System.Windows.Forms.TextBox PointNameField(int index, bool axisX) 
        {
            int marginTop = 25;
            int marginLeft = 10;

            int spaceBetween = 10;

            System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox();
            textBox.Name = string.Format(pointBaseName+namingPattern, axisX ? "X" : "Y" , index);
            textBox.Text = this.pointsDefaultNames[index];
            textBox.TextChanged += this.ghraphPointNameChanged;
            textBox.Tag = "point-name";
            textBox.Top = marginTop;
            textBox.Left = marginLeft;
            if (!axisX) textBox.Top += (index + 1) * (20 + spaceBetween);
            if (axisX) textBox.Left += (index + 1) * (30 + spaceBetween);
            textBox.Height = 30;
            textBox.Width = 40;
            textBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            return textBox;
        }
    }
}
