using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nodes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            nodesView1.Clear();
            nodesView1.AddNode(CreateNodes.CreateRandomNodes(nodesView1, 100, 5));
            nodesView1.Refresh();
            nodesView1.MouseMove += CreateInfo;
        }

        //  Метод, который находит узлы, на который указывет мышь и возвращает данные о нём
        public void CreateInfo(object sender, MouseEventArgs e)
        {
            Node findNode = (sender as NodesView).FindNode(e.Location);
            if (findNode != null)
            {
                NodeInfo.Text = findNode.Location.ToString() + "\n\n";
                NodeInfo.Text += "Пути: \n";
                foreach (Node theNode in findNode.PathToOtherNodes.Keys)
                {
                    NodeInfo.Text += theNode.Location.ToString() + "\n";
                }
            }
            else NodeInfo.Text = "";


        }

    }
}
