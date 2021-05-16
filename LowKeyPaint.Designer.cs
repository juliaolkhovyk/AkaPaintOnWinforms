namespace LowKeyPaintOnWinForms
{
    partial class LowKeyPaint
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
            this.pen = new System.Windows.Forms.Button();
            this.line = new System.Windows.Forms.Button();
            this.color = new System.Windows.Forms.Button();
            this.square = new System.Windows.Forms.Button();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.thicknessScrollBar = new System.Windows.Forms.HScrollBar();
            this.thicknessLabel = new System.Windows.Forms.Label();
            this.thicknessValue = new System.Windows.Forms.Label();
            this.circle = new System.Windows.Forms.Button();
            this.saveFile = new System.Windows.Forms.Button();
            this.openFile = new System.Windows.Forms.Button();
            this.eraser = new System.Windows.Forms.Button();
            this.cleanCanvas = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pen
            // 
            this.pen.Location = new System.Drawing.Point(13, 13);
            this.pen.Name = "pen";
            this.pen.Size = new System.Drawing.Size(75, 23);
            this.pen.TabIndex = 1;
            this.pen.Text = "Pen";
            this.pen.UseVisualStyleBackColor = true;
            this.pen.Click += new System.EventHandler(this.pen_Click);
            // 
            // line
            // 
            this.line.Location = new System.Drawing.Point(12, 42);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(75, 23);
            this.line.TabIndex = 2;
            this.line.Text = "Line";
            this.line.UseVisualStyleBackColor = true;
            this.line.Click += new System.EventHandler(this.line_Click);
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(11, 158);
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(75, 23);
            this.color.TabIndex = 4;
            this.color.Text = "Color";
            this.color.UseVisualStyleBackColor = true;
            this.color.Click += new System.EventHandler(this.color_Click);
            // 
            // square
            // 
            this.square.Location = new System.Drawing.Point(11, 71);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(75, 23);
            this.square.TabIndex = 5;
            this.square.Text = "Square";
            this.square.UseVisualStyleBackColor = true;
            this.square.Click += new System.EventHandler(this.square_Click);
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.canvas.Location = new System.Drawing.Point(117, 15);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(678, 534);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.canvas.TabIndex = 6;
            this.canvas.TabStop = false;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // thicknessScrollBar
            // 
            this.thicknessScrollBar.Location = new System.Drawing.Point(6, 223);
            this.thicknessScrollBar.Minimum = 1;
            this.thicknessScrollBar.Name = "thicknessScrollBar";
            this.thicknessScrollBar.Size = new System.Drawing.Size(108, 17);
            this.thicknessScrollBar.TabIndex = 11;
            this.thicknessScrollBar.Value = 5;
            this.thicknessScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.thicknessScrollBar_Scroll);
            // 
            // thicknessLabel
            // 
            this.thicknessLabel.AutoSize = true;
            this.thicknessLabel.Location = new System.Drawing.Point(12, 201);
            this.thicknessLabel.Name = "thicknessLabel";
            this.thicknessLabel.Size = new System.Drawing.Size(56, 13);
            this.thicknessLabel.TabIndex = 12;
            this.thicknessLabel.Text = "Thickness";
            // 
            // thicknessValue
            // 
            this.thicknessValue.AutoSize = true;
            this.thicknessValue.Location = new System.Drawing.Point(73, 201);
            this.thicknessValue.Name = "thicknessValue";
            this.thicknessValue.Size = new System.Drawing.Size(13, 13);
            this.thicknessValue.TabIndex = 13;
            this.thicknessValue.Text = "5";
            // 
            // circle
            // 
            this.circle.Location = new System.Drawing.Point(13, 100);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(75, 23);
            this.circle.TabIndex = 14;
            this.circle.Text = "Circle";
            this.circle.UseVisualStyleBackColor = true;
            this.circle.Click += new System.EventHandler(this.circle_Click);
            // 
            // saveFile
            // 
            this.saveFile.Location = new System.Drawing.Point(13, 413);
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(75, 23);
            this.saveFile.TabIndex = 15;
            this.saveFile.Text = "Save";
            this.saveFile.UseVisualStyleBackColor = true;
            this.saveFile.Click += new System.EventHandler(this.saveFile_Click);
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(15, 384);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(75, 23);
            this.openFile.TabIndex = 16;
            this.openFile.Text = "Open";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // eraser
            // 
            this.eraser.Location = new System.Drawing.Point(13, 129);
            this.eraser.Name = "eraser";
            this.eraser.Size = new System.Drawing.Size(75, 23);
            this.eraser.TabIndex = 17;
            this.eraser.Text = "Eraser";
            this.eraser.UseVisualStyleBackColor = true;
            this.eraser.Click += new System.EventHandler(this.eraser_Click);
            // 
            // cleanCanvas
            // 
            this.cleanCanvas.Location = new System.Drawing.Point(11, 442);
            this.cleanCanvas.Name = "cleanCanvas";
            this.cleanCanvas.Size = new System.Drawing.Size(75, 23);
            this.cleanCanvas.TabIndex = 20;
            this.cleanCanvas.Text = "Clean";
            this.cleanCanvas.UseVisualStyleBackColor = true;
            this.cleanCanvas.Click += new System.EventHandler(this.cleanCanvas_Click);
            // 
            // LowKeyPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.cleanCanvas);
            this.Controls.Add(this.eraser);
            this.Controls.Add(this.openFile);
            this.Controls.Add(this.saveFile);
            this.Controls.Add(this.circle);
            this.Controls.Add(this.thicknessValue);
            this.Controls.Add(this.thicknessLabel);
            this.Controls.Add(this.thicknessScrollBar);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.square);
            this.Controls.Add(this.color);
            this.Controls.Add(this.line);
            this.Controls.Add(this.pen);
            this.Name = "LowKeyPaint";
            this.Text = "LowKeyPaint";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LowKeyPaint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button pen;
        private System.Windows.Forms.Button line;
        private System.Windows.Forms.Button color;
        private System.Windows.Forms.Button square;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.HScrollBar thicknessScrollBar;
        private System.Windows.Forms.Label thicknessLabel;
        private System.Windows.Forms.Label thicknessValue;
        private System.Windows.Forms.Button circle;
        private System.Windows.Forms.Button saveFile;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.Button eraser;
        private System.Windows.Forms.Button cleanCanvas;
    }
}

