namespace quadUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonSendPacket = new System.Windows.Forms.Button();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxoutgoing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._dataGridViewQuadParams = new System.Windows.Forms.DataGridView();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._pictureBoxConnectiom = new System.Windows.Forms.PictureBox();
            this._pbIgnition = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIncoming = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewQuadParams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxConnectiom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbIgnition)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 124);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(82, 60);
            this.buttonConnect.TabIndex = 0;
            this.buttonConnect.Text = "Broadcast Network";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonSendPacket
            // 
            this.buttonSendPacket.Location = new System.Drawing.Point(376, 419);
            this.buttonSendPacket.Name = "buttonSendPacket";
            this.buttonSendPacket.Size = new System.Drawing.Size(43, 23);
            this.buttonSendPacket.TabIndex = 5;
            this.buttonSendPacket.Text = "Send";
            this.buttonSendPacket.UseVisualStyleBackColor = true;
            this.buttonSendPacket.Click += new System.EventHandler(this.buttonSendPacket_Click);
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(12, 393);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(407, 20);
            this.textBoxMessage.TabIndex = 8;
            this.textBoxMessage.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 376);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "outgoing message";
            // 
            // textBoxoutgoing
            // 
            this.textBoxoutgoing.Location = new System.Drawing.Point(12, 350);
            this.textBoxoutgoing.Name = "textBoxoutgoing";
            this.textBoxoutgoing.ReadOnly = true;
            this.textBoxoutgoing.Size = new System.Drawing.Size(407, 20);
            this.textBoxoutgoing.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "outgoing data";
            // 
            // _dataGridViewQuadParams
            // 
            this._dataGridViewQuadParams.AllowUserToAddRows = false;
            this._dataGridViewQuadParams.AllowUserToDeleteRows = false;
            this._dataGridViewQuadParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewQuadParams.ColumnHeadersVisible = false;
            this._dataGridViewQuadParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKey,
            this.colValue});
            this._dataGridViewQuadParams.Location = new System.Drawing.Point(119, 93);
            this._dataGridViewQuadParams.MultiSelect = false;
            this._dataGridViewQuadParams.Name = "_dataGridViewQuadParams";
            this._dataGridViewQuadParams.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._dataGridViewQuadParams.RowHeadersVisible = false;
            this._dataGridViewQuadParams.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this._dataGridViewQuadParams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this._dataGridViewQuadParams.Size = new System.Drawing.Size(187, 113);
            this._dataGridViewQuadParams.TabIndex = 17;
            // 
            // colKey
            // 
            this.colKey.HeaderText = "Key";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            // 
            // _pictureBoxConnectiom
            // 
            this._pictureBoxConnectiom.Image = global::quadUI.Properties.Resources.red;
            this._pictureBoxConnectiom.Location = new System.Drawing.Point(197, 48);
            this._pictureBoxConnectiom.Name = "_pictureBoxConnectiom";
            this._pictureBoxConnectiom.Size = new System.Drawing.Size(28, 28);
            this._pictureBoxConnectiom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this._pictureBoxConnectiom.TabIndex = 19;
            this._pictureBoxConnectiom.TabStop = false;
            // 
            // _pbIgnition
            // 
            this._pbIgnition.Enabled = false;
            this._pbIgnition.Image = global::quadUI.Properties.Resources.start;
            this._pbIgnition.Location = new System.Drawing.Point(322, 104);
            this._pbIgnition.Name = "_pbIgnition";
            this._pbIgnition.Size = new System.Drawing.Size(100, 102);
            this._pbIgnition.TabIndex = 16;
            this._pbIgnition.TabStop = false;
            this._pbIgnition.Click += new System.EventHandler(this._pbIgnition_Click);
            this._pbIgnition.MouseEnter += new System.EventHandler(this._pbIgnition_MouseEnter);
            this._pbIgnition.MouseLeave += new System.EventHandler(this._pbIgnition_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(162, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Connection Status";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "incoming data";
            // 
            // textBoxIncoming
            // 
            this.textBoxIncoming.Location = new System.Drawing.Point(12, 311);
            this.textBoxIncoming.Name = "textBoxIncoming";
            this.textBoxIncoming.ReadOnly = true;
            this.textBoxIncoming.Size = new System.Drawing.Size(407, 20);
            this.textBoxIncoming.TabIndex = 21;
            // 
            // Main
            // 
            this.AcceptButton = this.buttonSendPacket;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 458);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIncoming);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._pictureBoxConnectiom);
            this.Controls.Add(this._dataGridViewQuadParams);
            this.Controls.Add(this._pbIgnition);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxoutgoing);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.buttonSendPacket);
            this.Controls.Add(this.buttonConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quadcopter Control Panel";
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewQuadParams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBoxConnectiom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pbIgnition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonSendPacket;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxoutgoing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox _pbIgnition;
        private System.Windows.Forms.DataGridView _dataGridViewQuadParams;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.PictureBox _pictureBoxConnectiom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIncoming;
    }
}

