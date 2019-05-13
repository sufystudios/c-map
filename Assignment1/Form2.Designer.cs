namespace Assignment1
{
    partial class QuestionForm
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
            this.addEvent = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.message = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Button();
            this.connectID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Connect = new System.Windows.Forms.Button();
            this.tracklogID = new System.Windows.Forms.TextBox();
            this.addToTrack = new System.Windows.Forms.Button();
            this.EventType = new System.Windows.Forms.ComboBox();
            this.eventypelabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.filedialog = new System.Windows.Forms.OpenFileDialog();
            this.filetext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addEvent
            // 
            this.addEvent.Location = new System.Drawing.Point(314, 120);
            this.addEvent.Name = "addEvent";
            this.addEvent.Size = new System.Drawing.Size(75, 23);
            this.addEvent.TabIndex = 0;
            this.addEvent.Text = "Add Event";
            this.addEvent.UseVisualStyleBackColor = true;
            this.addEvent.Click += new System.EventHandler(this.addEvent_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(12, 317);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 0;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // message
            // 
            this.message.Location = new System.Drawing.Point(12, 120);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(296, 20);
            this.message.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Event";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Left Click=Add, Right Click=Delete or Inspect";
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(94, 317);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 5;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // connectID
            // 
            this.connectID.Location = new System.Drawing.Point(12, 192);
            this.connectID.Name = "connectID";
            this.connectID.Size = new System.Drawing.Size(100, 20);
            this.connectID.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Connect To Marker ID:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Connect
            // 
            this.Connect.Location = new System.Drawing.Point(12, 218);
            this.Connect.Name = "Connect";
            this.Connect.Size = new System.Drawing.Size(75, 23);
            this.Connect.TabIndex = 8;
            this.Connect.Text = "Connect";
            this.Connect.UseVisualStyleBackColor = true;
            this.Connect.Click += new System.EventHandler(this.Connect_Click);
            // 
            // tracklogID
            // 
            this.tracklogID.Location = new System.Drawing.Point(266, 78);
            this.tracklogID.Name = "tracklogID";
            this.tracklogID.Size = new System.Drawing.Size(42, 20);
            this.tracklogID.TabIndex = 9;
            // 
            // addToTrack
            // 
            this.addToTrack.Location = new System.Drawing.Point(115, 75);
            this.addToTrack.Name = "addToTrack";
            this.addToTrack.Size = new System.Drawing.Size(143, 23);
            this.addToTrack.TabIndex = 10;
            this.addToTrack.Text = "Add To EventID Tracklog";
            this.addToTrack.UseVisualStyleBackColor = true;
            this.addToTrack.Click += new System.EventHandler(this.button1_Click);
            // 
            // EventType
            // 
            this.EventType.FormattingEnabled = true;
            this.EventType.Items.AddRange(new object[] {
            "tweet",
            "tracklog",
            "video",
            "photo",
            "facebook-status-update"});
            this.EventType.Location = new System.Drawing.Point(266, 147);
            this.EventType.Name = "EventType";
            this.EventType.Size = new System.Drawing.Size(121, 21);
            this.EventType.TabIndex = 11;
            // 
            // eventypelabel
            // 
            this.eventypelabel.AutoSize = true;
            this.eventypelabel.Location = new System.Drawing.Point(190, 150);
            this.eventypelabel.Name = "eventypelabel";
            this.eventypelabel.Size = new System.Drawing.Size(59, 13);
            this.eventypelabel.TabIndex = 12;
            this.eventypelabel.Text = "EventType";
            this.eventypelabel.Click += new System.EventHandler(this.label4_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(266, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Pick File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // filedialog
            // 
            this.filedialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // filetext
            // 
            this.filetext.Location = new System.Drawing.Point(266, 202);
            this.filetext.Name = "filetext";
            this.filetext.Size = new System.Drawing.Size(100, 20);
            this.filetext.TabIndex = 14;
            // 
            // QuestionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 352);
            this.Controls.Add(this.filetext);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.eventypelabel);
            this.Controls.Add(this.EventType);
            this.Controls.Add(this.addToTrack);
            this.Controls.Add(this.tracklogID);
            this.Controls.Add(this.Connect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.connectID);
            this.Controls.Add(this.update);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.message);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.addEvent);
            this.Name = "QuestionForm";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addEvent;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.TextBox connectID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Connect;
        private System.Windows.Forms.TextBox tracklogID;
        private System.Windows.Forms.Button addToTrack;
        private System.Windows.Forms.ComboBox EventType;
        private System.Windows.Forms.Label eventypelabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog filedialog;
        private System.Windows.Forms.TextBox filetext;
    }
}