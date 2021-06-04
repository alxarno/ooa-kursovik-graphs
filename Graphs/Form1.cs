using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphsAlgorithms.Algorithms;

namespace Graphs
{
    public partial class MainForm : Form
    {
        private Graphs.ConnectivityMatrixView matrixView;

        public MainForm()
        {
            InitializeComponent();
            this.matrixView = new Graphs.ConnectivityMatrixView(this.MatrixGroup, 4, "-9999");
            this.graphPointsCountComboBox.SelectedIndex = 3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void graphPointsCountComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.matrixView.ChangePointsCount(Int32.Parse(this.graphPointsCountComboBox.Text));
        }

        private void OnChangedGraphType(object sender, EventArgs e)
        {
            this.simpleGraphRadioButton.Checked = false;
            this.directedGraphRadioButton.Checked = false;
            this.weightedGraphRadioButton.Checked = false;

            switch (((System.Windows.Forms.RadioButton)sender).Name) {
                case "simpleGraphRadioButton":
                    this.simpleGraphRadioButton.Checked = true;
                    this.linkAbsenceValueGroup.Visible = false;
                    this.matrixView.ChangeGraphType(GraphsAlgorithms.GraphsTypes.Simple);
                    break;
                case "directedGraphRadioButton":
                    this.directedGraphRadioButton.Checked = true;
                    this.linkAbsenceValueGroup.Visible = false;
                    this.matrixView.ChangeGraphType(GraphsAlgorithms.GraphsTypes.Directed);
                    break;
                case "weightedGraphRadioButton":
                    this.weightedGraphRadioButton.Checked = true;
                    this.linkAbsenceValueGroup.Visible = true;
                    this.matrixView.ChangeGraphType(GraphsAlgorithms.GraphsTypes.Weight);
                    break;
            }
        }

        private void linkAbscenseValueTextBox_TextChanged(object sender, EventArgs e)
        {
            this.matrixView.ChangeLinkAbscense(this.linkAbscenseValueTextBox.Text);
        }

        private void cycles_Click(object sender, EventArgs e)
        {
            cyclesLogsTextBox.Clear();
            cyclesResultsTextBox.Clear();
            var graph = this.matrixView.GetGraph();
            var (cyclesResults, cyclesLogs) = CyclesDetector.IsCyclic(graph);
            cyclesLogsTextBox.Text = String.Join(Environment.NewLine, cyclesLogs);
            if (cyclesResults) cyclesResultsTextBox.Text = "Граф содержит цикл";
            else cyclesResultsTextBox.Text = "Граф не содержит цикл";
        }

        private void Tabs_VisibleChanged(object sender, EventArgs e)
        {
            pathesSourceList.Items.Clear();
            var graph = this.matrixView.GetGraph();
            foreach(var point in graph.Points)
            {
                pathesSourceList.Items.Add(point);
            }
        }

        private void pathesExecButton_Click(object sender, EventArgs e)
        {
            var check = pathesSourceList.SelectedItem.ToString();
            if (check == "") return;
            var graph = this.matrixView.GetGraph();
            var logs = BreadthFirstSearcher.PrintAll(graph, check);
            pathesLogs.Text = String.Join(Environment.NewLine, logs);
        }

        private void ShortesPath_Enter(object sender, EventArgs e)
        {
            shortPathSource.Items.Clear();
            shortPathDestination.Items.Clear();
            var graph = this.matrixView.GetGraph();
            foreach (var point in graph.Points)
            {
                shortPathSource.Items.Add(point);
                shortPathDestination.Items.Add(point);
            }
        }

        private void shortPathExec_Click(object sender, EventArgs e)
        {
            var graph = this.matrixView.GetGraph();
            var dijkstra = new DijkstraShortestPaths(graph);
            var (result, logs) = dijkstra.FindShortestPath(shortPathSource.SelectedItem.ToString(), shortPathDestination.SelectedItem.ToString());
            shortPathLogs.Text = String.Join(Environment.NewLine, logs);
            shortPathLogs.Text += Environment.NewLine;
            shortPathLogs.Text += "Найденый путь:";
            shortPathLogs.Text += Environment.NewLine;
            shortPathLogs.Text += String.Join(" -> ", result);
        }
    }
}
