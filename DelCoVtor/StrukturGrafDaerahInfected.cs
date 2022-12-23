using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.IO;
using Microsoft.Msagl.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DelCoVtor
{
    public class StrukturGrafDaerahInfected
    {
        public readonly Dictionary<DaerahInfected, List<DaerahInfected>> grafInfeksi;
        private readonly Dictionary<KeyValuePair<DaerahInfected, DaerahInfected>, double> tempData;
        public readonly Graph MSAGLGraph;

        //Define the constructor contains graf initation, tempData, GrafLibrary
        public StrukturGrafDaerahInfected()
        {
            tempData = new Dictionary<KeyValuePair<DaerahInfected, DaerahInfected>, double>();
            grafInfeksi = new Dictionary<DaerahInfected, List<DaerahInfected>>();
            MSAGLGraph = new Graph();
        }

        public void AddEdge(DaerahInfected datadaerah, DaerahInfected datamapping, double dataset)
        {
            if (!grafInfeksi.ContainsKey(datadaerah))
            {
                grafInfeksi.Add(datadaerah, new List<DaerahInfected>());
            }
            if (!grafInfeksi.ContainsKey(datamapping))
            {
                grafInfeksi.Add(datamapping, new List<DaerahInfected>());
            }
            else
            {
                Console.WriteLine("Data Tidak Valid");
            }
            MSAGLGraph.AddEdge(datadaerah.GetNamaDaerah(), datamapping.GetNamaDaerah());
            grafInfeksi[datadaerah].Add(datamapping);
            tempData.Add(new KeyValuePair<DaerahInfected, DaerahInfected>(datadaerah, datamapping), dataset);
        }


    public void DataQuery(DaerahInfected rootNode, int targetDay)
        {
            foreach (DaerahInfected daerahInfected in grafInfeksi.Keys)
            {
                daerahInfected.Reset();
            }
            rootNode.hariAwal = 0;
            var q = new Queue<DaerahInfected>();
            q.Enqueue(rootNode);
            while (q.Count > 0)
            {
                DaerahInfected timecounting = q.Dequeue();
                UpdateInfected(timecounting);
                foreach (DaerahInfected next in grafInfeksi[timecounting])
                {
                    if (ListDayCalculate(timecounting, next, targetDay) > 1)
                    {
                        UpdateInfected(timecounting, next);
                        int nextDay = TimeVirusSeperate(timecounting, next) + timecounting.hariAwal;
                        if (next.hariAwal > nextDay)
                        {
                            next.hariAwal = nextDay;
                            q.Enqueue(next);
                        }
                    }
                }
            }
        }
        private void UpdateInfected(DaerahInfected daerahInfected)
        {
            MSAGLGraph.FindNode(daerahInfected.GetNamaDaerah()).Attr.FillColor = Color.IndianRed;
        }

        private void UpdateInfected(DaerahInfected setX_, DaerahInfected setY_)
        {
            Edge edegGraf = MSAGLGraph.Edges.Where(edge => edge.Source == setX_.GetNamaDaerah() && edge.Target == setY_.GetNamaDaerah()).FirstOrDefault();
            if (edegGraf != null)
            {
                edegGraf.Attr.Color = Color.DarkGreen;
            }
            else
            {
                Console.WriteLine("Edge Graf Tidak Ada, Node Root harus punya edge ke Node lain!");
            }
        }

        public int TimeVirusSeperate(DaerahInfected setX_, DaerahInfected setY_)
        {
            //calculate the time so it can convert to next edge into graph
            double set1 = -4 * Math.Log((setX_.DataCountMasayarakat() * ListValueDaerah(setX_, setY_) - 1) / (setX_.DataCountMasayarakat() - 1));
            int pof = (int)Math.Ceiling(set1);
            if (pof == set1)
            {
                ++pof;
            }
            return pof;
        }

        public double ListValueDaerah(DaerahInfected setX_, DaerahInfected setY_)
        {
            // set value for Method ListValueDaerah
            return tempData[new KeyValuePair<DaerahInfected, DaerahInfected>(setX_, setY_)];
        }

        public double ListDayCalculate(DaerahInfected setX_, DaerahInfected setY_, int DayMax)
        {
            // set value for Method ListValueCalculate
            return setX_.InfectedByTheDuration(DayMax) * ListValueDaerah(setX_, setY_);
        }

    }
}

