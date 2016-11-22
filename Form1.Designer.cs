namespace J_Gzimo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.changeMode = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.square = new System.Windows.Forms.Button();
            this.triangle = new System.Windows.Forms.Button();
            this.pineball = new System.Windows.Forms.Button();
            this.circle = new System.Windows.Forms.Button();
            this.trapezoid = new System.Windows.Forms.Button();
            this.L = new System.Windows.Forms.Button();
            this.bigger = new System.Windows.Forms.Button();
            this.smaller = new System.Windows.Forms.Button();
            this.rotate = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.absorb = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.baffle = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.场景ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.track = new System.Windows.Forms.Button();
            this.dynamic = new System.Windows.Forms.Button();
            this.chooseGizmo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.baffleX = new System.Windows.Forms.Button();
            this.startOver = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(0, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(801, 801);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // changeMode
            // 
            this.changeMode.BackColor = System.Drawing.Color.Transparent;
            this.changeMode.ForeColor = System.Drawing.Color.DimGray;
            this.changeMode.Location = new System.Drawing.Point(831, 67);
            this.changeMode.Name = "changeMode";
            this.changeMode.Size = new System.Drawing.Size(75, 23);
            this.changeMode.TabIndex = 1;
            this.changeMode.Text = "开始游戏";
            this.changeMode.UseVisualStyleBackColor = false;
            this.changeMode.Click += new System.EventHandler(this.changeMode_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // square
            // 
            this.square.BackColor = System.Drawing.Color.Transparent;
            this.square.Image = ((System.Drawing.Image)(resources.GetObject("square.Image")));
            this.square.Location = new System.Drawing.Point(831, 207);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(75, 29);
            this.square.TabIndex = 2;
            this.square.UseVisualStyleBackColor = false;
            this.square.Click += new System.EventHandler(this.square_Click);
            // 
            // triangle
            // 
            this.triangle.BackColor = System.Drawing.Color.Transparent;
            this.triangle.Image = ((System.Drawing.Image)(resources.GetObject("triangle.Image")));
            this.triangle.Location = new System.Drawing.Point(831, 242);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(75, 29);
            this.triangle.TabIndex = 3;
            this.triangle.UseVisualStyleBackColor = false;
            this.triangle.Click += new System.EventHandler(this.triangle_Click);
            // 
            // pineball
            // 
            this.pineball.BackColor = System.Drawing.Color.Transparent;
            this.pineball.Image = ((System.Drawing.Image)(resources.GetObject("pineball.Image")));
            this.pineball.Location = new System.Drawing.Point(831, 277);
            this.pineball.Name = "pineball";
            this.pineball.Size = new System.Drawing.Size(75, 29);
            this.pineball.TabIndex = 4;
            this.pineball.UseVisualStyleBackColor = false;
            this.pineball.Click += new System.EventHandler(this.pineball_Click);
            // 
            // circle
            // 
            this.circle.BackColor = System.Drawing.Color.Transparent;
            this.circle.Image = ((System.Drawing.Image)(resources.GetObject("circle.Image")));
            this.circle.Location = new System.Drawing.Point(831, 312);
            this.circle.Name = "circle";
            this.circle.Size = new System.Drawing.Size(75, 29);
            this.circle.TabIndex = 5;
            this.circle.UseVisualStyleBackColor = false;
            this.circle.Click += new System.EventHandler(this.circle_Click);
            // 
            // trapezoid
            // 
            this.trapezoid.BackColor = System.Drawing.Color.Transparent;
            this.trapezoid.Image = ((System.Drawing.Image)(resources.GetObject("trapezoid.Image")));
            this.trapezoid.Location = new System.Drawing.Point(831, 347);
            this.trapezoid.Name = "trapezoid";
            this.trapezoid.Size = new System.Drawing.Size(75, 23);
            this.trapezoid.TabIndex = 6;
            this.trapezoid.UseVisualStyleBackColor = false;
            this.trapezoid.Click += new System.EventHandler(this.trapezoid_Click);
            // 
            // L
            // 
            this.L.BackColor = System.Drawing.Color.Transparent;
            this.L.Image = ((System.Drawing.Image)(resources.GetObject("L.Image")));
            this.L.Location = new System.Drawing.Point(831, 376);
            this.L.Name = "L";
            this.L.Size = new System.Drawing.Size(75, 23);
            this.L.TabIndex = 7;
            this.L.UseVisualStyleBackColor = false;
            this.L.Click += new System.EventHandler(this.L_Click);
            // 
            // bigger
            // 
            this.bigger.BackColor = System.Drawing.Color.Transparent;
            this.bigger.ForeColor = System.Drawing.Color.DimGray;
            this.bigger.Location = new System.Drawing.Point(831, 485);
            this.bigger.Name = "bigger";
            this.bigger.Size = new System.Drawing.Size(27, 24);
            this.bigger.TabIndex = 8;
            this.bigger.Text = "+";
            this.bigger.UseVisualStyleBackColor = false;
            this.bigger.Click += new System.EventHandler(this.bigger_Click);
            // 
            // smaller
            // 
            this.smaller.BackColor = System.Drawing.Color.Transparent;
            this.smaller.ForeColor = System.Drawing.Color.DimGray;
            this.smaller.Location = new System.Drawing.Point(874, 485);
            this.smaller.Name = "smaller";
            this.smaller.Size = new System.Drawing.Size(23, 24);
            this.smaller.TabIndex = 9;
            this.smaller.Text = "——";
            this.smaller.UseVisualStyleBackColor = false;
            this.smaller.Click += new System.EventHandler(this.smaller_Click);
            // 
            // rotate
            // 
            this.rotate.BackColor = System.Drawing.Color.Transparent;
            this.rotate.ForeColor = System.Drawing.Color.DimGray;
            this.rotate.Location = new System.Drawing.Point(831, 515);
            this.rotate.Name = "rotate";
            this.rotate.Size = new System.Drawing.Size(75, 23);
            this.rotate.TabIndex = 10;
            this.rotate.Text = "旋转";
            this.rotate.UseVisualStyleBackColor = false;
            this.rotate.Click += new System.EventHandler(this.rotate_Click);
            // 
            // delete
            // 
            this.delete.BackColor = System.Drawing.Color.Transparent;
            this.delete.ForeColor = System.Drawing.Color.DimGray;
            this.delete.Location = new System.Drawing.Point(831, 407);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 11;
            this.delete.Text = "删除控件";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // absorb
            // 
            this.absorb.BackColor = System.Drawing.Color.Transparent;
            this.absorb.ForeColor = System.Drawing.Color.DimGray;
            this.absorb.Location = new System.Drawing.Point(828, 693);
            this.absorb.Name = "absorb";
            this.absorb.Size = new System.Drawing.Size(39, 23);
            this.absorb.TabIndex = 12;
            this.absorb.Text = "吸收";
            this.absorb.UseVisualStyleBackColor = false;
            this.absorb.Click += new System.EventHandler(this.absorb_Click);
            // 
            // down
            // 
            this.down.BackColor = System.Drawing.Color.Transparent;
            this.down.ForeColor = System.Drawing.Color.DimGray;
            this.down.Location = new System.Drawing.Point(828, 588);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(39, 23);
            this.down.TabIndex = 13;
            this.down.Text = "down";
            this.down.UseVisualStyleBackColor = false;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // up
            // 
            this.up.BackColor = System.Drawing.Color.Transparent;
            this.up.ForeColor = System.Drawing.Color.DimGray;
            this.up.Location = new System.Drawing.Point(874, 588);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(47, 23);
            this.up.TabIndex = 14;
            this.up.Text = "up";
            this.up.UseVisualStyleBackColor = false;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.Transparent;
            this.left.ForeColor = System.Drawing.Color.DimGray;
            this.left.Location = new System.Drawing.Point(828, 617);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(39, 23);
            this.left.TabIndex = 15;
            this.left.Text = "left";
            this.left.UseVisualStyleBackColor = false;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.Transparent;
            this.right.ForeColor = System.Drawing.Color.DimGray;
            this.right.Location = new System.Drawing.Point(874, 617);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(47, 23);
            this.right.TabIndex = 16;
            this.right.Text = "right";
            this.right.UseVisualStyleBackColor = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.ForeColor = System.Drawing.Color.SkyBlue;
            this.label1.Location = new System.Drawing.Point(832, 565);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "按钮绑定";
            // 
            // baffle
            // 
            this.baffle.BackColor = System.Drawing.Color.Transparent;
            this.baffle.Image = ((System.Drawing.Image)(resources.GetObject("baffle.Image")));
            this.baffle.Location = new System.Drawing.Point(831, 172);
            this.baffle.Name = "baffle";
            this.baffle.Size = new System.Drawing.Size(75, 29);
            this.baffle.TabIndex = 18;
            this.baffle.UseVisualStyleBackColor = false;
            this.baffle.Click += new System.EventHandler(this.baffle_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.场景ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 25);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 场景ToolStripMenuItem
            // 
            this.场景ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建ToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.场景ToolStripMenuItem.Name = "场景ToolStripMenuItem";
            this.场景ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.场景ToolStripMenuItem.Text = "场景";
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "读取";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.读取ToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "保存";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.ForeColor = System.Drawing.Color.SkyBlue;
            this.label2.Location = new System.Drawing.Point(827, 670);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Gizmo特性";
            // 
            // track
            // 
            this.track.BackColor = System.Drawing.Color.Transparent;
            this.track.ForeColor = System.Drawing.Color.DimGray;
            this.track.Location = new System.Drawing.Point(874, 693);
            this.track.Name = "track";
            this.track.Size = new System.Drawing.Size(47, 23);
            this.track.TabIndex = 21;
            this.track.Text = "轨道";
            this.track.UseVisualStyleBackColor = false;
            this.track.Click += new System.EventHandler(this.track_Click);
            // 
            // dynamic
            // 
            this.dynamic.BackColor = System.Drawing.Color.Transparent;
            this.dynamic.ForeColor = System.Drawing.Color.DimGray;
            this.dynamic.Location = new System.Drawing.Point(828, 722);
            this.dynamic.Name = "dynamic";
            this.dynamic.Size = new System.Drawing.Size(39, 23);
            this.dynamic.TabIndex = 22;
            this.dynamic.Text = "可动";
            this.dynamic.UseVisualStyleBackColor = false;
            this.dynamic.Click += new System.EventHandler(this.dynamic_Click);
            // 
            // chooseGizmo
            // 
            this.chooseGizmo.BackColor = System.Drawing.Color.Transparent;
            this.chooseGizmo.ForeColor = System.Drawing.Color.DimGray;
            this.chooseGizmo.Location = new System.Drawing.Point(831, 143);
            this.chooseGizmo.Name = "chooseGizmo";
            this.chooseGizmo.Size = new System.Drawing.Size(75, 23);
            this.chooseGizmo.TabIndex = 23;
            this.chooseGizmo.Text = "选中Gizmo";
            this.chooseGizmo.UseVisualStyleBackColor = false;
            this.chooseGizmo.Click += new System.EventHandler(this.chooseGizmo_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.ForeColor = System.Drawing.Color.LightPink;
            this.label3.Location = new System.Drawing.Point(814, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "当前GizmoId:-1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.ForeColor = System.Drawing.Color.SkyBlue;
            this.label4.Location = new System.Drawing.Point(827, 462);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Gizmo修改";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F);
            this.label5.ForeColor = System.Drawing.Color.SkyBlue;
            this.label5.Location = new System.Drawing.Point(838, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Gizmo";
            // 
            // baffleX
            // 
            this.baffleX.Location = new System.Drawing.Point(831, 437);
            this.baffleX.Name = "baffleX";
            this.baffleX.Size = new System.Drawing.Size(75, 23);
            this.baffleX.TabIndex = 27;
            this.baffleX.Text = "baffleX";
            this.baffleX.UseVisualStyleBackColor = true;
            this.baffleX.Click += new System.EventHandler(this.baffleX_Click);
            // 
            // startOver
            // 
            this.startOver.BackColor = System.Drawing.Color.Transparent;
            this.startOver.ForeColor = System.Drawing.Color.DimGray;
            this.startOver.Location = new System.Drawing.Point(831, 108);
            this.startOver.Name = "startOver";
            this.startOver.Size = new System.Drawing.Size(75, 23);
            this.startOver.TabIndex = 28;
            this.startOver.Text = "重新开始";
            this.startOver.UseVisualStyleBackColor = false;
            this.startOver.Visible = false;
            this.startOver.Click += new System.EventHandler(this.startOver_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(817, 774);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 29;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(952, 824);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.startOver);
            this.Controls.Add(this.baffleX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chooseGizmo);
            this.Controls.Add(this.dynamic);
            this.Controls.Add(this.track);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.baffle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.up);
            this.Controls.Add(this.down);
            this.Controls.Add(this.absorb);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.rotate);
            this.Controls.Add(this.smaller);
            this.Controls.Add(this.bigger);
            this.Controls.Add(this.L);
            this.Controls.Add(this.trapezoid);
            this.Controls.Add(this.circle);
            this.Controls.Add(this.pineball);
            this.Controls.Add(this.triangle);
            this.Controls.Add(this.square);
            this.Controls.Add(this.changeMode);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button changeMode;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button square;
        private System.Windows.Forms.Button triangle;
        private System.Windows.Forms.Button pineball;
        private System.Windows.Forms.Button circle;
        private System.Windows.Forms.Button trapezoid;
        private System.Windows.Forms.Button L;
        private System.Windows.Forms.Button baffle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 场景ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button chooseGizmo;
        private System.Windows.Forms.Button bigger;
        private System.Windows.Forms.Button smaller;
        private System.Windows.Forms.Button rotate;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button absorb;
        private System.Windows.Forms.Button down;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button track;
        private System.Windows.Forms.Button dynamic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button baffleX;
        private System.Windows.Forms.Button startOver;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}

