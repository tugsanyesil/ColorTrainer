namespace ColorTrainer
{
    partial class ColorTrainerForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Slider = new System.Windows.Forms.TrackBar();
            this.ColorMap = new System.Windows.Forms.PictureBox();
            this.RadioR = new System.Windows.Forms.RadioButton();
            this.RadioG = new System.Windows.Forms.RadioButton();
            this.RadioB = new System.Windows.Forms.RadioButton();
            this.ColorList = new System.Windows.Forms.ListBox();
            this.ButtonDeleteColor = new System.Windows.Forms.Button();
            this.ButtonClear = new System.Windows.Forms.Button();
            this.ButtonTrain = new System.Windows.Forms.Button();
            this.LabelTrain = new System.Windows.Forms.Label();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.MapNameBox = new System.Windows.Forms.TextBox();
            this.MapList = new System.Windows.Forms.ListBox();
            this.ButtonDeleteMap = new System.Windows.Forms.Button();
            this.ButtonQ = new System.Windows.Forms.Button();
            this.LabelQ = new System.Windows.Forms.Label();
            this.TrainTimer = new System.Windows.Forms.Timer(this.components);
            this.ColorBox = new System.Windows.Forms.Panel();
            this.CategoryList = new System.Windows.Forms.ListBox();
            this.ButtonDeleteCategory = new System.Windows.Forms.Button();
            this.CategoryNameBox = new System.Windows.Forms.TextBox();
            this.ButtonAddCategory = new System.Windows.Forms.Button();
            this.ButtonClearBrain = new System.Windows.Forms.Button();
            this.ButtonResetSelection = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorMap)).BeginInit();
            this.SuspendLayout();
            // 
            // Slider
            // 
            this.Slider.Location = new System.Drawing.Point(278, 81);
            this.Slider.Maximum = 255;
            this.Slider.Name = "Slider";
            this.Slider.Size = new System.Drawing.Size(462, 45);
            this.Slider.TabIndex = 0;
            this.Slider.ValueChanged += new System.EventHandler(this.Slider_ValueChanged);
            // 
            // ColorMap
            // 
            this.ColorMap.Location = new System.Drawing.Point(16, 12);
            this.ColorMap.Name = "ColorMap";
            this.ColorMap.Size = new System.Drawing.Size(256, 256);
            this.ColorMap.TabIndex = 2;
            this.ColorMap.TabStop = false;
            this.ColorMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColorMap_MouseClick);
            this.ColorMap.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ColorMap_MouseDoubleClick);
            // 
            // RadioR
            // 
            this.RadioR.AutoSize = true;
            this.RadioR.Location = new System.Drawing.Point(278, 12);
            this.RadioR.Name = "RadioR";
            this.RadioR.Size = new System.Drawing.Size(33, 17);
            this.RadioR.TabIndex = 3;
            this.RadioR.Text = "R";
            this.RadioR.UseVisualStyleBackColor = true;
            this.RadioR.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // RadioG
            // 
            this.RadioG.AutoSize = true;
            this.RadioG.Checked = true;
            this.RadioG.Location = new System.Drawing.Point(278, 35);
            this.RadioG.Name = "RadioG";
            this.RadioG.Size = new System.Drawing.Size(33, 17);
            this.RadioG.TabIndex = 4;
            this.RadioG.TabStop = true;
            this.RadioG.Text = "G";
            this.RadioG.UseVisualStyleBackColor = true;
            this.RadioG.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // RadioB
            // 
            this.RadioB.AutoSize = true;
            this.RadioB.Location = new System.Drawing.Point(278, 58);
            this.RadioB.Name = "RadioB";
            this.RadioB.Size = new System.Drawing.Size(32, 17);
            this.RadioB.TabIndex = 5;
            this.RadioB.Text = "B";
            this.RadioB.UseVisualStyleBackColor = true;
            this.RadioB.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // ColorList
            // 
            this.ColorList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ColorList.FormattingEnabled = true;
            this.ColorList.Location = new System.Drawing.Point(278, 119);
            this.ColorList.Name = "ColorList";
            this.ColorList.Size = new System.Drawing.Size(250, 147);
            this.ColorList.TabIndex = 6;
            // 
            // ButtonDeleteColor
            // 
            this.ButtonDeleteColor.Location = new System.Drawing.Point(534, 119);
            this.ButtonDeleteColor.Name = "ButtonDeleteColor";
            this.ButtonDeleteColor.Size = new System.Drawing.Size(100, 30);
            this.ButtonDeleteColor.TabIndex = 7;
            this.ButtonDeleteColor.Text = "Delete";
            this.ButtonDeleteColor.UseVisualStyleBackColor = true;
            this.ButtonDeleteColor.Click += new System.EventHandler(this.ButtonDeleteColor_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Location = new System.Drawing.Point(640, 119);
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(100, 30);
            this.ButtonClear.TabIndex = 8;
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.UseVisualStyleBackColor = true;
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // ButtonTrain
            // 
            this.ButtonTrain.Location = new System.Drawing.Point(534, 191);
            this.ButtonTrain.Name = "ButtonTrain";
            this.ButtonTrain.Size = new System.Drawing.Size(100, 30);
            this.ButtonTrain.TabIndex = 9;
            this.ButtonTrain.Text = "Train";
            this.ButtonTrain.UseVisualStyleBackColor = true;
            this.ButtonTrain.Click += new System.EventHandler(this.ButtonTrain_Click);
            // 
            // LabelTrain
            // 
            this.LabelTrain.AutoSize = true;
            this.LabelTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelTrain.Location = new System.Drawing.Point(538, 233);
            this.LabelTrain.Name = "LabelTrain";
            this.LabelTrain.Size = new System.Drawing.Size(17, 20);
            this.LabelTrain.TabIndex = 10;
            this.LabelTrain.Text = "J";
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(534, 155);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(100, 30);
            this.ButtonSave.TabIndex = 11;
            this.ButtonSave.Text = "Save as";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // MapNameBox
            // 
            this.MapNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MapNameBox.Location = new System.Drawing.Point(640, 156);
            this.MapNameBox.Name = "MapNameBox";
            this.MapNameBox.Size = new System.Drawing.Size(100, 27);
            this.MapNameBox.TabIndex = 12;
            // 
            // MapList
            // 
            this.MapList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MapList.FormattingEnabled = true;
            this.MapList.ItemHeight = 16;
            this.MapList.Location = new System.Drawing.Point(16, 274);
            this.MapList.Name = "MapList";
            this.MapList.Size = new System.Drawing.Size(184, 132);
            this.MapList.TabIndex = 13;
            this.MapList.SelectedIndexChanged += new System.EventHandler(this.MapList_SelectedIndexChanged);
            // 
            // ButtonDeleteMap
            // 
            this.ButtonDeleteMap.Location = new System.Drawing.Point(16, 414);
            this.ButtonDeleteMap.Name = "ButtonDeleteMap";
            this.ButtonDeleteMap.Size = new System.Drawing.Size(184, 30);
            this.ButtonDeleteMap.TabIndex = 14;
            this.ButtonDeleteMap.Text = "Delete";
            this.ButtonDeleteMap.UseVisualStyleBackColor = true;
            this.ButtonDeleteMap.Click += new System.EventHandler(this.ButtonDeleteMap_Click);
            // 
            // ButtonQ
            // 
            this.ButtonQ.Location = new System.Drawing.Point(206, 274);
            this.ButtonQ.Name = "ButtonQ";
            this.ButtonQ.Size = new System.Drawing.Size(100, 30);
            this.ButtonQ.TabIndex = 16;
            this.ButtonQ.Text = "What is that?";
            this.ButtonQ.UseVisualStyleBackColor = true;
            this.ButtonQ.Click += new System.EventHandler(this.ButtonQ_Click);
            // 
            // LabelQ
            // 
            this.LabelQ.AutoSize = true;
            this.LabelQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LabelQ.Location = new System.Drawing.Point(313, 278);
            this.LabelQ.Name = "LabelQ";
            this.LabelQ.Size = new System.Drawing.Size(32, 20);
            this.LabelQ.TabIndex = 17;
            this.LabelQ.Text = "0%";
            // 
            // TrainTimer
            // 
            this.TrainTimer.Interval = 1;
            this.TrainTimer.Tick += new System.EventHandler(this.TrainTimer_Tick);
            // 
            // ColorBox
            // 
            this.ColorBox.Location = new System.Drawing.Point(206, 310);
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.Size = new System.Drawing.Size(100, 100);
            this.ColorBox.TabIndex = 18;
            // 
            // CategoryList
            // 
            this.CategoryList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CategoryList.FormattingEnabled = true;
            this.CategoryList.ItemHeight = 16;
            this.CategoryList.Location = new System.Drawing.Point(317, 12);
            this.CategoryList.Name = "CategoryList";
            this.CategoryList.Size = new System.Drawing.Size(211, 68);
            this.CategoryList.TabIndex = 19;
            // 
            // ButtonDeleteCategory
            // 
            this.ButtonDeleteCategory.Location = new System.Drawing.Point(534, 12);
            this.ButtonDeleteCategory.Name = "ButtonDeleteCategory";
            this.ButtonDeleteCategory.Size = new System.Drawing.Size(100, 30);
            this.ButtonDeleteCategory.TabIndex = 20;
            this.ButtonDeleteCategory.Text = "Delete";
            this.ButtonDeleteCategory.UseVisualStyleBackColor = true;
            this.ButtonDeleteCategory.Click += new System.EventHandler(this.ButtonDeleteCategory_Click);
            // 
            // CategoryNameBox
            // 
            this.CategoryNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CategoryNameBox.Location = new System.Drawing.Point(640, 52);
            this.CategoryNameBox.Name = "CategoryNameBox";
            this.CategoryNameBox.Size = new System.Drawing.Size(100, 27);
            this.CategoryNameBox.TabIndex = 21;
            // 
            // ButtonAddCategory
            // 
            this.ButtonAddCategory.Location = new System.Drawing.Point(534, 51);
            this.ButtonAddCategory.Name = "ButtonAddCategory";
            this.ButtonAddCategory.Size = new System.Drawing.Size(100, 30);
            this.ButtonAddCategory.TabIndex = 22;
            this.ButtonAddCategory.Text = "Add";
            this.ButtonAddCategory.UseVisualStyleBackColor = true;
            this.ButtonAddCategory.Click += new System.EventHandler(this.ButtonAddCategory_Click);
            // 
            // ButtonClearBrain
            // 
            this.ButtonClearBrain.Location = new System.Drawing.Point(640, 191);
            this.ButtonClearBrain.Name = "ButtonClearBrain";
            this.ButtonClearBrain.Size = new System.Drawing.Size(100, 30);
            this.ButtonClearBrain.TabIndex = 24;
            this.ButtonClearBrain.Text = "Clear Brain";
            this.ButtonClearBrain.UseVisualStyleBackColor = true;
            this.ButtonClearBrain.Click += new System.EventHandler(this.ButtonClearBrain_Click);
            // 
            // ButtonResetSelection
            // 
            this.ButtonResetSelection.Location = new System.Drawing.Point(640, 12);
            this.ButtonResetSelection.Name = "ButtonResetSelection";
            this.ButtonResetSelection.Size = new System.Drawing.Size(100, 30);
            this.ButtonResetSelection.TabIndex = 25;
            this.ButtonResetSelection.Text = "Reset Selection";
            this.ButtonResetSelection.UseVisualStyleBackColor = true;
            this.ButtonResetSelection.Click += new System.EventHandler(this.ButtonResetSelection_Click);
            // 
            // ColorTrainerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 461);
            this.Controls.Add(this.ButtonResetSelection);
            this.Controls.Add(this.ButtonClearBrain);
            this.Controls.Add(this.ButtonAddCategory);
            this.Controls.Add(this.CategoryNameBox);
            this.Controls.Add(this.ButtonDeleteCategory);
            this.Controls.Add(this.CategoryList);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.LabelQ);
            this.Controls.Add(this.ButtonQ);
            this.Controls.Add(this.ButtonDeleteMap);
            this.Controls.Add(this.MapList);
            this.Controls.Add(this.MapNameBox);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.LabelTrain);
            this.Controls.Add(this.ButtonTrain);
            this.Controls.Add(this.ButtonClear);
            this.Controls.Add(this.ButtonDeleteColor);
            this.Controls.Add(this.ColorList);
            this.Controls.Add(this.RadioB);
            this.Controls.Add(this.RadioG);
            this.Controls.Add(this.RadioR);
            this.Controls.Add(this.ColorMap);
            this.Controls.Add(this.Slider);
            this.Name = "ColorTrainerForm";
            this.Text = "ColorTrainerForm";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ColorMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar Slider;
        private System.Windows.Forms.PictureBox ColorMap;
        private System.Windows.Forms.RadioButton RadioR;
        private System.Windows.Forms.RadioButton RadioG;
        private System.Windows.Forms.RadioButton RadioB;
        private System.Windows.Forms.ListBox ColorList;
        private System.Windows.Forms.Button ButtonDeleteColor;
        private System.Windows.Forms.Button ButtonClear;
        private System.Windows.Forms.Button ButtonTrain;
        private System.Windows.Forms.Label LabelTrain;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox MapNameBox;
        private System.Windows.Forms.ListBox MapList;
        private System.Windows.Forms.Button ButtonDeleteMap;
        private System.Windows.Forms.Button ButtonQ;
        private System.Windows.Forms.Label LabelQ;
        private System.Windows.Forms.Timer TrainTimer;
        private System.Windows.Forms.Panel ColorBox;
        private System.Windows.Forms.ListBox CategoryList;
        private System.Windows.Forms.Button ButtonDeleteCategory;
        private System.Windows.Forms.TextBox CategoryNameBox;
        private System.Windows.Forms.Button ButtonAddCategory;
        private System.Windows.Forms.Button ButtonClearBrain;
        private System.Windows.Forms.Button ButtonResetSelection;
    }
}

