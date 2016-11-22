using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Box2DX;
using Box2DX.Collision;
using Box2DX.Common;
using Box2DX.Dynamics;
using System.Drawing.Drawing2D;

namespace J_Gzimo
{
    public enum FormGizmoType { Null, Square, Circle, Triangle, PineBall, Trapezoid, L,Baffle, BaffleX };
    public enum KeyType { Up, Down, Left, Right, Null };
    public enum GizmoType { Circle, Rectangle, Polygon, Baffle,BaffleX };
    public enum GizmoAttribute { staticGizmo, dynamicGizmo, pineBall, track, absorber, baffle }
    public partial class Form1 : Form
    {
        int currentModel = 0;
        GizmoSystem gsystem = new GizmoSystem();
        FormGizmoType currentType = FormGizmoType.Null;
        int currentSize = 1;
        int currentAngle = 0;
        Draw drawBoard = new Draw();
        KeyType key = KeyType.Null;
        string defaultSceneFile = Application.StartupPath + @"/hello.bin";
        int id = -1;

        public Form1()
        {
            InitializeComponent();
            if (System.IO.File.Exists(defaultSceneFile))
            {
                gsystem.initialScene(defaultSceneFile);
            }
            gsystem.startGame();
            this.pictureBox1.Image = drawBoard.drawBaseMap();
        }

        /// <summary>
        /// 时间器触发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Image = drawBoard.drawFrame(true, gsystem);
        }

        /// <summary>
        /// pictureBox点击触发函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (currentModel)
            {
                case 0:
                    if (drawBoard.isAvailable(e.X, e.Y, gsystem.getRelativePoint(currentType, currentSize, currentAngle),-1))
                    {
                        id = gsystem.addGizmo(drawBoard.convertFormToWorld(e.X), drawBoard.convertFormToWorld(e.Y), currentSize, currentAngle, currentType, drawBoard.getWorldInterval());
                        drawBoard.fillGrid(e.X, e.Y, gsystem.getRelativePoint(currentType, currentSize, currentAngle), id);
                        gsystem.startGame();
                        this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                    }
                    else
                    {
                        MessageBox.Show("位置不和法");
                    }
                    break;
                case 1: 
                    id = drawBoard.deleteGizmo(e.X, e.Y);
                    gsystem.deleteGizmo(id);
                    gsystem.startGame();
                    this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                    id = -1;
                    break;
                case 2:
                    id = drawBoard.getGizmo(e.X, e.Y);
                    break;
                case 3:
                    id = drawBoard.getGizmo(e.X, e.Y);
                    gsystem.becomeAbsorber(id);
                    gsystem.startGame();
                    this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                    break;
                case 4:
                    id = drawBoard.getGizmo(e.X, e.Y);
                    gsystem.becomeTrack(id);
                    gsystem.startGame();
                    this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                    break;
                case 5:
                    id = drawBoard.getGizmo(e.X, e.Y);
                    gsystem.becomeDynamic(id);
                    gsystem.startGame();
                    this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                    break;
                case 6:
                    id = drawBoard.getGizmo(e.X, e.Y);
                    break;
            }
            this.label3.Text="当前GizmoId:"+id;

        }

        #region Gizmo buttonClick
        private void square_Click(object sender, EventArgs e)
        {
            addGizmo(FormGizmoType.Square);
        }

        private void triangle_Click(object sender, EventArgs e)
        {
            addGizmo(FormGizmoType.Triangle);
        }

        private void pineball_Click(object sender, EventArgs e)
        {
            addGizmo(FormGizmoType.PineBall);
        }

        private void circle_Click(object sender, EventArgs e)
        {
            addGizmo(FormGizmoType.Circle);
        }

        private void trapezoid_Click(object sender, EventArgs e)
        {
            addGizmo(FormGizmoType.Trapezoid);
        }

        private void L_Click(object sender, EventArgs e)
        {
            addGizmo(FormGizmoType.L);
        }

        private void addGizmo(FormGizmoType formGizmoType)
        {
            id = -1;
            this.label3.Text = "当前GizmoId:" + id;
            currentModel = 0;
            if (this.timer1.Enabled == true)
                this.timer1.Enabled = false;
            currentType = formGizmoType;
        }
        #endregion

        #region Operation buttonClick
        private void chooseGizmo_Click(object sender, EventArgs e)
        {
            currentModel = 6;
        }
        private void changeMode_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled == false)
            {
                this.textBox1.Visible = false;
                this.changeMode.Text = "编辑地图";
                currentModel = 6;
                id = -1;
                this.timer1.Enabled = true;
                this.startOver.Visible = true;
                this.chooseGizmo.Visible = false;
                this.square.Visible = false;
                this.triangle.Visible = false;
                this.pineball.Visible = false;
                this.L.Visible = false;
                this.delete.Visible = false;
                this.baffleX.Visible = false;
                this.bigger.Visible = false;
                this.smaller.Visible = false;
                this.rotate.Visible = false;
                this.absorb.Visible = false;
                this.track.Visible = false;
                this.dynamic.Visible = false;
                this.down.Visible = false;
                this.up.Visible = false;
                this.left.Visible = false;
                this.right.Visible = false;
                this.circle.Visible = false;
                this.trapezoid.Visible = false;
                this.baffle.Visible = false;
                this.label1.Visible = false;
                this.label2.Visible = false;
                this.label3.Visible = false;
                this.label4.Visible = false;
                this.label5.Visible = false;
            }
            else
            {
                this.textBox1.Visible = true;
                this.changeMode.Text = "开始游戏";
                this.startOver.Visible = false;
                this.chooseGizmo.Visible = true;
                this.square.Visible = true;
                this.triangle.Visible = true;
                this.pineball.Visible = true;
                this.L.Visible = true;
                this.delete.Visible = true;
                this.baffleX.Visible = true;
                this.bigger.Visible = true;
                this.smaller.Visible = true;
                this.rotate.Visible = true;
                this.absorb.Visible = true;
                this.track.Visible = true;
                this.dynamic.Visible = true;
                this.down.Visible = true;
                this.up.Visible = true;
                this.left.Visible = true;
                this.right.Visible = true;
                this.circle.Visible = true;
                this.trapezoid.Visible = true;
                this.baffle.Visible = true;
                this.label1.Visible = true;
                this.label2.Visible = true;
                this.label3.Visible = true;
                this.label4.Visible = true;
                this.label5.Visible = true;

                this.timer1.Enabled = false;
                currentType = FormGizmoType.Null;
            }
        }
        private void bigger_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                List<Point> points = gsystem.getChangeRelativePoint(0, id);
                if (drawBoard.isAvailable(points, id))
                {
                    int originalId = id;
                    id = gsystem.changeGizmo(drawBoard.getWorldPointXById(id), drawBoard.getWorldPointYById(id), 0, id, drawBoard.getWorldInterval());
                    drawBoard.fillGrid(points, id, originalId);
                    drawBoard.deleteGizmoById(originalId);
                    gsystem.startGame();
                    this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                }
                else
                {
                    MessageBox.Show("位置不和法");
                }
            }
            else
                currentSize++;
        }
        private void smaller_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                List<Point> points = gsystem.getChangeRelativePoint(1, id);
                if (points == null)
                {
                    MessageBox.Show("控件大小已为最小");
                    return;
                }
                if (drawBoard.isAvailable(points, id))
                {
                    int originalId = id;
                    id = gsystem.changeGizmo(drawBoard.getWorldPointXById(id), drawBoard.getWorldPointYById(id), 1, id, drawBoard.getWorldInterval());
                    drawBoard.fillGrid(points, id, originalId);
                    drawBoard.deleteGizmoById(originalId);
                    gsystem.startGame();
                    this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                }
                else
                {
                    MessageBox.Show("位置不和法");
                }

            }
            else
            {
                if (currentSize > 1)
                    currentSize--;
                else
                {
                    MessageBox.Show("控件大小已为最小");
                }
            }
        }
        private void rotate_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                List<Point> points = gsystem.getChangeRelativePoint(2, id);
                if (drawBoard.isAvailable(points, id))
                {
                    int originalId = id;
                    id = gsystem.changeGizmo(drawBoard.getWorldPointXById(id), drawBoard.getWorldPointYById(id), 2, id, drawBoard.getWorldInterval());
                    drawBoard.fillGrid(points, id, originalId);
                    drawBoard.deleteGizmoById(originalId);
                    gsystem.startGame();
                    this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                }
                else
                {
                    MessageBox.Show("位置不和法");
                }
            }
            else
            {
                if (currentAngle == 270)
                    currentAngle = 0;
                else
                    currentAngle += 90;
            }
        }
        private void delete_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                drawBoard.deleteGizmoById(id);
                gsystem.deleteGizmo(id);
                gsystem.startGame();
                this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
                id = -1;
            }
            this.timer1.Enabled = false;
            currentType = FormGizmoType.Null;
            currentModel = 1;
        }
        private void down_Click(object sender, EventArgs e)
        {
            currentModel = 2;
            key = KeyType.Down;
        }
        private void up_Click(object sender, EventArgs e)
        {
            currentModel = 2;
            key = KeyType.Up;
        }
        private void left_Click(object sender, EventArgs e)
        {
            currentModel = 2;
            key = KeyType.Left;
        }
        private void right_Click(object sender, EventArgs e)
        {
            currentModel = 2;
            key = KeyType.Right;
        }
        private void baffle_Click(object sender, EventArgs e)
        {
            currentModel = 0;
            if (this.timer1.Enabled == true)
                this.timer1.Enabled = false;
            currentType = FormGizmoType.Baffle;
        }
        private void absorb_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                gsystem.becomeAbsorber(id);
                gsystem.startGame();
                this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
            }
            currentModel = 3;
        }
        private void track_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                gsystem.becomeTrack(id);
                gsystem.startGame();
                this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
            }
            currentModel = 4;
        }
        private void dynamic_Click(object sender, EventArgs e)
        {
            if (id != -1)
            {
                gsystem.becomeDynamic(id);
                gsystem.startGame();
                this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
            }
            currentModel = 5;
        }
        /// <summary>
        /// 绑定按钮、按钮操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void keyDown(object sender, KeyEventArgs eventArgs)
        {
            if (id != -1 && currentModel == 2)
            {
                gsystem.bindKey(key, id, eventArgs.KeyCode.ToString());
                id = -1;
                MessageBox.Show("绑定成功");
            }
            else
            {
                gsystem.keyDownOperation(eventArgs.KeyCode.ToString());
            }
        }
        /// <summary>
        /// 设置默认按键操作交给keyDown函数运行
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            return false;
        }
        #endregion

        #region Setting buttonClick
        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "场景文件(*.bin)|*.bin";
            if (dialog.ShowDialog() == DialogResult.OK)  
            {
                string foldPath = dialog.FileName;
                gsystem.saveScene(foldPath,drawBoard);
                MessageBox.Show("保存成功:"+foldPath);
            }
        }
        private void 读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "场景文件(*.bin)|*.bin";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;
                drawBoard=gsystem.initialScene(file);
                MessageBox.Show("读取成功：" + file);
                gsystem.startGame();
            }
            this.pictureBox1.Image = drawBoard.drawFrame(false, gsystem);
        }
        #endregion

        private void baffleX_Click(object sender, EventArgs e)
        {
            currentModel = 0;
            if (this.timer1.Enabled == true)
                this.timer1.Enabled = false;
            currentType = FormGizmoType.BaffleX;
        }

        private void startOver_Click(object sender, EventArgs e)
        {
            gsystem.startGame();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gsystem = new GizmoSystem();
            this.pictureBox1.Image = drawBoard.drawBaseMap();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                drawBoard = new Draw(Convert.ToInt32(textBox1.Text));
                gsystem.startGame();
                this.pictureBox1.Image = drawBoard.drawBaseMap();
            }catch(Exception et)
            {
                return;
            }
        }
    }
}
