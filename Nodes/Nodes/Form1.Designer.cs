namespace Nodes
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.nodesView1 = new Nodes.NodesView();
            this.label1 = new System.Windows.Forms.Label();
            this.NodeInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nodesView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Создать граф";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nodesView1
            // 
            this.nodesView1.Location = new System.Drawing.Point(2, 4);
            this.nodesView1.Name = "nodesView1";
            this.nodesView1.Size = new System.Drawing.Size(616, 412);
            this.nodesView1.TabIndex = 0;
            this.nodesView1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(624, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Нажать кнопку \"Создать граф\". \r\nЗатем левой и правой кнопкой \r\nмыши выбрать 2 вер" +
    "шины.";
            // 
            // NodeInfo
            // 
            this.NodeInfo.AutoSize = true;
            this.NodeInfo.Location = new System.Drawing.Point(633, 129);
            this.NodeInfo.Name = "NodeInfo";
            this.NodeInfo.Size = new System.Drawing.Size(0, 13);
            this.NodeInfo.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NodeInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nodesView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nodesView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NodesView nodesView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NodeInfo;
    }
}

