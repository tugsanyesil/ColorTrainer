using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Accord;
using Accord.Math;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using static ColorTrainer.Exts;

namespace ColorTrainer
{
    public partial class ColorTrainerForm : Form
    {
        Bitmap ColorMapBitmap;
        Brain Brain;
        public ColorTrainerForm()
        {
            InitializeComponent();
            ColorMapBitmap = new Bitmap(256, 256);
            Radio_CheckedChanged(null, EventArgs.Empty);
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioR.Checked)
            {
                for (int x = 0; x < ColorMapBitmap.Width; x++)
                {
                    for (int y = 0; y < ColorMapBitmap.Height; y++)
                    {
                        ColorMapBitmap.SetPixel(x, y, Color.FromArgb(Slider.Value, x, y));
                    }
                }
            }
            else if (RadioG.Checked)
            {
                for (int x = 0; x < ColorMapBitmap.Width; x++)
                {
                    for (int y = 0; y < ColorMapBitmap.Height; y++)
                    {
                        ColorMapBitmap.SetPixel(x, y, Color.FromArgb(x, Slider.Value, y));
                    }
                }
            }
            else if (RadioB.Checked)
            {
                for (int x = 0; x < ColorMapBitmap.Width; x++)
                {
                    for (int y = 0; y < ColorMapBitmap.Height; y++)
                    {
                        ColorMapBitmap.SetPixel(x, y, Color.FromArgb(x, y, Slider.Value));
                    }
                }
            }
            ColorMap.Image = ColorMapBitmap;
        }

        private void Slider_ValueChanged(object sender, EventArgs e)
        {
            Radio_CheckedChanged(null, EventArgs.Empty);
        }

        private void ColorMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (CategoryList.SelectedIndex != -1)
            {
                ColorList.Items.Add(new ColorCategory(ColorMapBitmap.GetPixel(e.X, e.Y), (string)CategoryList.SelectedItem));
            }
        }

        private void ColorMap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ColorBox.BackColor = ColorMapBitmap.GetPixel(e.X, e.Y);
        }

        private void ButtonDeleteColor_Click(object sender, EventArgs e)
        {
            if (ColorList.SelectedIndex != -1)
            {
                ColorList.Items.RemoveAt(ColorList.SelectedIndex);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            Brain = new Brain(0.63f, new int[] { 3, 10, 1 });
        }

        List<ColorCategory> Items;
        private void ButtonClearBrain_Click(object sender, EventArgs e)
        {
            Items = new List<ColorCategory>();
            foreach (var i in ColorList.Items)
            {
                Items.Add((ColorCategory)i);
            }

            var Categories = new List<string>();
            foreach (var i in CategoryList.Items)
            {
                Categories.Add((string)i);
            }

            Brain = new Brain(0.63f, new int[] { 3, 10, CategoryList.Items.Count }) { Categories = Categories.ToArray() };
        }

        private void ButtonTrain_Click(object sender, EventArgs e)
        {
            if (!TrainTimer.Enabled)
            {
                Items = new List<ColorCategory>();
                foreach (var i in ColorList.Items)
                {
                    Items.Add((ColorCategory)i);
                }
                Perceptions = Items.ConvertAll(i => i.Color.ColorToKnowledge()).ToArray();
                HiddenTruths = Items.ConvertAll(i => CategoryList.Items.IndexOf(i.Category).OneArray(CategoryList.Items.Count)).ToArray();
            }
            ButtonTrain.BackColor = (TrainTimer.Enabled = !TrainTimer.Enabled) ? SystemColors.ButtonHighlight : SystemColors.ButtonFace;
        }

        int TrainIteration = 0;
        float J = 0f;
        float mJ = 0f;//max index cost
        float[][] Perceptions;
        float[][] HiddenTruths;
        private void TrainTimer_Tick(object sender, EventArgs e)
        {
            if (null != Brain && 0 != Perceptions.Length)
            {
                for (int i = 0; i < Perceptions.Length; i++)
                {
                    Brain.Revolution(Perceptions[i], HiddenTruths[i]);
                    /*var iterlim = 0;
                    while (MaxIndex(Brain.UseIt(Perceptions[i])) != MaxIndex(HiddenTruths[i]) && iterlim++ < 10) { Brain.Revolution(Perceptions[i], HiddenTruths[i]); }*/
                }
                J = 0;
                mJ = 0;
                if (++TrainIteration % 100 == 0)
                {
                    for (int i = 0; i < Perceptions.Length; i++)
                    {
                        var b = Brain.UseIt(Perceptions[i]);
                        J += HiddenTruths[i].Subtract(b).Sum(f => Math.Abs(f));
                        mJ += Convert.ToInt32(MaxIndex(b) != MaxIndex(HiddenTruths[i]));
                    }
                    J /= Perceptions.Length * Brain.Neurons.Last();
                    mJ /= Perceptions.Length;

                    LabelTrain.Text =
                        "Iteration : " + TrainIteration + "\n" +
                        "        J : " + J + "\n" +
                        "       mJ : " + mJ;
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            ((BrainData)Brain).Save("Brain_" + MapNameBox.Text + ".xml");
            MapList.Items.Add("Brain_" + MapNameBox.Text);
        }

        private void ButtonQ_Click(object sender, EventArgs e)
        {
            var c = 0;
            LabelQ.Text = "";
            var results = Brain.UseIt(ColorBox.BackColor.ColorToKnowledge()).ToList();

            for (int r = 0; r < results.Count; r++)
            {
                LabelQ.Text += 100 * results[r] + "% " + Brain.Categories[c++] + "\n";
            }
        }

        private void ButtonDeleteMap_Click(object sender, EventArgs e)
        {
            if (MapList.SelectedIndex != -1)
            {
                var FileName = Path.Combine(Application.StartupPath, (string)(MapList.SelectedItem) + ".xml");
                if (File.Exists(FileName)) { File.Delete(FileName); }
                MapList.Items.RemoveAt(MapList.SelectedIndex);
            }
        }

        private void MapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MapList.SelectedIndex != -1)
            {
                Brain = Exts.Load<BrainData>(Path.Combine(Application.StartupPath, MapList.SelectedItem.ToString() + ".xml"));

                CategoryList.Items.Clear();
                foreach (var i in Brain.Categories)
                {
                    CategoryList.Items.Add(i);
                }
            }
        }

        private void ButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            if (CategoryList.SelectedIndex != -1)
            {
                CategoryList.Items.RemoveAt(CategoryList.SelectedIndex);
            }
        }

        private void ButtonAddCategory_Click(object sender, EventArgs e)
        {
            CategoryList.Items.Add(CategoryNameBox.Text);
        }

        private void ButtonResetSelection_Click(object sender, EventArgs e)
        {
            CategoryList.SelectedIndex = -1;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            Directory.GetFiles(Application.StartupPath).Select(s => Path.GetFileNameWithoutExtension(s)).Where(s => s.Contains("Brain_")).ToList().ForEach(s => MapList.Items.Add(s));
        }
    }

    public class ColorCategory
    {
        public Color Color;
        public string Category;

        public ColorCategory(Color Color, string Category)
        {
            this.Color = Color;
            this.Category = Category;
        }

        public override string ToString()
        {
            return Color.ToString() + " " + Category;
        }
    }

    public static class Exts
    {
        public static int MaxIndex(float[] Array) => Array.Select((value, index) => new { Value = value, Index = index }).Aggregate((a, b) => (a.Value > b.Value) ? a : b).Index;
        public static float[] ColorToKnowledge(this Color C) => new float[] { C.R / 255f, C.G / 255f, C.B / 255f };
        public static float[] ColorEnumToKnowledge(this Colors C) { var ret = new float[Enum.GetNames(typeof(Colors)).Length]; ret[(int)C] = 1f; return ret; }
        public static Colors KnowledgeToColorEnum(this float[] f) { f.Max(out int i); return (Colors)i; }
        public enum Colors { Black, Red, Blue, Pink, Purple }
        public static float[] OneArray(this int i, int Count) { var f = Vector.Zeros<float>(Count); f[i] = 1; return f; }


        public static void Save(this object Object, string Path)
        {
            if (!File.Exists(Path)) { File.Create(Path).Close(); }
            using (XmlWriter XmlWriter = XmlWriter.Create(Path, new XmlWriterSettings() { Indent = true }))
            {
                new XmlSerializer(Object.GetType()).Serialize(XmlWriter, Object);
            }
        }

        public static T Load<T>(this string Path)
        {
            using (XmlReader XmlReader = XmlReader.Create(Path))
            {
                return (T)(new XmlSerializer(typeof(T)).Deserialize(XmlReader));
            }
        }
    }

    public class BrainData
    {
        public float LearningRate;
        public int[] Neurons;
        public string[] Categories;
        public float[][][] Ws;
        public float[][] Bs;

        public BrainData() { }

        public static implicit operator Brain(BrainData d)
        {
            return new Brain(d.LearningRate, d.Neurons)
            {
                Categories = d.Categories,
                Ws = d.Ws.ToList().ConvertAll(W => W.ToMatrix()).ToArray(),
                Bs = d.Bs
            };
        }

        public static implicit operator BrainData(Brain c)
        {
            return new BrainData()
            {
                LearningRate = c.LearningRate,
                Neurons = c.Neurons,
                Categories = c.Categories,
                Ws = c.Ws.ToList().ConvertAll(W => W.ToJagged()).ToArray(),
                Bs = c.Bs
            };
        }
    }

    public class Brain
    {
        public float Sigmoid(float z) => 1f / (1f + (float)Math.Exp(-z));
        public float SigmoidPrime(float z) => Sigmoid(z) * (1 - Sigmoid(z));

        public float LearningRate;
        public int[] Neurons;
        public string[] Categories;
        public float[][] As;
        public float[][,] Ws;
        public float[][] Bs;
        public float[][] Zs;

        public float[] X => As[0];
        public float[] Y => As[As.Length - 1];

        public Brain() { }
        public Brain(float LearningRate, int[] Neurons) : this(LearningRate, Neurons, Enumerable.Range(1, Neurons.Length).ToList().ConvertAll(c => "Class " + c).ToArray()) { }
        public Brain(float LearningRate, int[] Neurons, string[] Categories)
        {
            Random Random = new Random();
            this.LearningRate = LearningRate;
            this.Neurons = Neurons;
            this.Categories = Categories;
            As = new float[Neurons.Length][];
            Ws = new float[Neurons.Length - 1][,];
            Bs = new float[Neurons.Length - 1][];
            Zs = new float[Neurons.Length - 1][];

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                As[n] = new float[Neurons[n]];
                Ws[n] = new float[Neurons[n], Neurons[n + 1]];
                Bs[n] = new float[Neurons[n + 1]];
                Zs[n] = new float[Neurons[n + 1]];

                Ws[n] = Matrix.Random(Neurons[n], Neurons[n + 1], -1f / Neurons[n + 1], 1f / Neurons[n + 1]);
                Bs[n] = Vector.Random(Neurons[n + 1], -1f / Neurons[n + 1], 1f / Neurons[n + 1]);
            }
            As[Neurons.Length - 1] = new float[Neurons[Neurons.Length - 1]];
        }

        public float[] UseIt(float[] Perception)
        {
            As[0] = Perception;
            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                Zs[n] = As[n].Dot(Ws[n]).Add(Bs[n]);
                As[n + 1] = Zs[n].Apply(Sigmoid);
            }

            return Y;
        }

        int iter = 0;
        public void Revolution(float[] Perception, float[] HiddenTruth)
        {
            iter = (iter + 1) % 50;
            LearningRate = (0.63f - 0.001f) * (iter / 50f) + 0.001f;
            var o = FindDerivation(Perception, HiddenTruth);

            float[][,] dWs = (float[][,])o[0];
            float[][] dBs = (float[][])o[1];

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                Ws[n] = Ws[n].Add(dWs[n].Multiply(-LearningRate));
                Bs[n] = Bs[n].Add(dBs[n].Multiply(-LearningRate));
            }
        }

        public void Coup(float[][] AK47, float[][] MilitaryForces)
        {
            float[][,] dWs = new float[Neurons.Length - 1][,];
            float[][] dBs = new float[Neurons.Length - 1][];
            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                dWs[n] = Matrix.Create(Neurons[n], Neurons[n + 1], 0f);
                dBs[n] = Vector.Create(Neurons[n + 1], 0f);
            }

            for (int i = 0; i < AK47.Length; i++)
            {
                var o = FindDerivation(AK47[i], MilitaryForces[i]);

                float[][,] idWs = (float[][,])o[0];
                float[][] idBs = (float[][])o[1];

                for (int n = 0; n < Neurons.Length - 1; n++)
                {
                    dWs[n] = dWs[n].Add(idWs[n]);
                    dBs[n] = dBs[n].Add(idBs[n]);
                }
            }

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                Ws[n] = Ws[n].Subtract(dWs[n].Multiply(LearningRate /* AK47.Length*/));
                Bs[n] = Bs[n].Subtract(dBs[n].Multiply(LearningRate /* AK47.Length*/));
            }
        }

        public object[] FindDerivation(float[] Perception, float[] HiddenTruth)
        {
            this.UseIt(Perception);

            float[][] dBs = new float[Neurons.Length - 1][];

            dBs[Neurons.Length - 2] = Y.Subtract(HiddenTruth).Multiply(Zs[Neurons.Length - 2].Apply(SigmoidPrime));
            for (int n = Neurons.Length - 3; n >= 0; n--)
            {
                dBs[n] = dBs[n + 1].DotWithTransposed(Ws[n + 1]).Multiply(Zs[n].Apply(SigmoidPrime));
            }

            float[][,] dWs = new float[Neurons.Length - 1][,];

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                dWs[n] = Matrix.TransposeAndDot(As[n], dBs[n].ToMatrix());
            }

            return new object[] { dWs, dBs };
        }

        public override string ToString()
        {
            string s = "";

            for (int n = 0; n < Neurons.Length - 1; n++)
            {
                s += $"{n}. Layer\n\n\n";
                s += $"As[{n}] " + As[n].ToCSharp() + "\n";
                s += $"Ws[{n}] " + Ws[n].ToCSharp() + "\n";
                s += $"Bs[{n}] " + Bs[n].ToCSharp() + "\n";
                s += $"Zs[{n}] " + Zs[n].ToCSharp() + "\n\n\n";
            }
            s += "Y" + Y.ToCSharp() + "\n\n";

            return s;
        }
    }
}
