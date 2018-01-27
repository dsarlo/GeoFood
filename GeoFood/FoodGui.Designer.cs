namespace GeoFood
{
    partial class FoodGui
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
            this._submitButton = new System.Windows.Forms.Button();
            this._prefLabel = new System.Windows.Forms.Label();
            this._foodPrefDrop = new System.Windows.Forms.ComboBox();
            this._zipLabel = new System.Windows.Forms.Label();
            this._zipTxtbox = new System.Windows.Forms.TextBox();
            this._bgPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._restPic = new System.Windows.Forms.PictureBox();
            this._restPrice = new System.Windows.Forms.Label();
            this._restRate = new System.Windows.Forms.Label();
            this._restName = new System.Windows.Forms.Label();
            this._bgPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._restPic)).BeginInit();
            this.SuspendLayout();
            // 
            // _submitButton
            // 
            this._submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._submitButton.Location = new System.Drawing.Point(116, 142);
            this._submitButton.Name = "_submitButton";
            this._submitButton.Size = new System.Drawing.Size(154, 51);
            this._submitButton.TabIndex = 1;
            this._submitButton.Text = "Generate a Restaurant!";
            this._submitButton.UseVisualStyleBackColor = true;
            // 
            // _prefLabel
            // 
            this._prefLabel.AutoSize = true;
            this._prefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._prefLabel.Location = new System.Drawing.Point(88, 15);
            this._prefLabel.Name = "_prefLabel";
            this._prefLabel.Size = new System.Drawing.Size(212, 20);
            this._prefLabel.TabIndex = 1;
            this._prefLabel.Text = "General Food Preference";
            // 
            // _foodPrefDrop
            // 
            this._foodPrefDrop.FormattingEnabled = true;
            this._foodPrefDrop.Location = new System.Drawing.Point(131, 38);
            this._foodPrefDrop.Name = "_foodPrefDrop";
            this._foodPrefDrop.Size = new System.Drawing.Size(121, 21);
            this._foodPrefDrop.TabIndex = 2;
            // 
            // _zipLabel
            // 
            this._zipLabel.AutoSize = true;
            this._zipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._zipLabel.Location = new System.Drawing.Point(154, 75);
            this._zipLabel.Name = "_zipLabel";
            this._zipLabel.Size = new System.Drawing.Size(81, 20);
            this._zipLabel.TabIndex = 4;
            this._zipLabel.Text = "Zip Code";
            // 
            // _zipTxtbox
            // 
            this._zipTxtbox.Location = new System.Drawing.Point(143, 98);
            this._zipTxtbox.Name = "_zipTxtbox";
            this._zipTxtbox.Size = new System.Drawing.Size(100, 20);
            this._zipTxtbox.TabIndex = 5;
            // 
            // _bgPanel
            // 
            this._bgPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._bgPanel.Controls.Add(this.panel2);
            this._bgPanel.Controls.Add(this._zipTxtbox);
            this._bgPanel.Controls.Add(this._zipLabel);
            this._bgPanel.Controls.Add(this._foodPrefDrop);
            this._bgPanel.Controls.Add(this._prefLabel);
            this._bgPanel.Controls.Add(this._submitButton);
            this._bgPanel.Location = new System.Drawing.Point(12, 12);
            this._bgPanel.Name = "_bgPanel";
            this._bgPanel.Size = new System.Drawing.Size(390, 338);
            this._bgPanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this._restPic);
            this.panel2.Controls.Add(this._restPrice);
            this.panel2.Controls.Add(this._restRate);
            this.panel2.Controls.Add(this._restName);
            this.panel2.Location = new System.Drawing.Point(18, 217);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 100);
            this.panel2.TabIndex = 6;
            // 
            // _restPic
            // 
            this._restPic.BackgroundImage = global::GeoFood.Properties.Resources.restaurant_e1456862749354;
            this._restPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._restPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._restPic.InitialImage = null;
            this._restPic.Location = new System.Drawing.Point(248, 3);
            this._restPic.Name = "_restPic";
            this._restPic.Size = new System.Drawing.Size(100, 92);
            this._restPic.TabIndex = 8;
            this._restPic.TabStop = false;
            // 
            // _restPrice
            // 
            this._restPrice.AutoSize = true;
            this._restPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._restPrice.Location = new System.Drawing.Point(17, 63);
            this._restPrice.Name = "_restPrice";
            this._restPrice.Size = new System.Drawing.Size(36, 20);
            this._restPrice.TabIndex = 7;
            this._restPrice.Text = "$$$";
            // 
            // _restRate
            // 
            this._restRate.AutoSize = true;
            this._restRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._restRate.Location = new System.Drawing.Point(16, 38);
            this._restRate.Name = "_restRate";
            this._restRate.Size = new System.Drawing.Size(82, 25);
            this._restRate.TabIndex = 6;
            this._restRate.Text = "★★★★☆";
            // 
            // _restName
            // 
            this._restName.AutoSize = true;
            this._restName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._restName.Location = new System.Drawing.Point(16, 18);
            this._restName.Name = "_restName";
            this._restName.Size = new System.Drawing.Size(162, 20);
            this._restName.TabIndex = 5;
            this._restName.Text = "Bippity Boop\'s Cucina";
            // 
            // FoodGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 365);
            this.Controls.Add(this._bgPanel);
            this.Name = "FoodGui";
            this.Text = "GeoFood";
            this._bgPanel.ResumeLayout(false);
            this._bgPanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._restPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.Label _prefLabel;
        private System.Windows.Forms.ComboBox _foodPrefDrop;
        private System.Windows.Forms.Label _zipLabel;
        private System.Windows.Forms.TextBox _zipTxtbox;
        private System.Windows.Forms.Panel _bgPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label _restName;
        private System.Windows.Forms.Label _restRate;
        private System.Windows.Forms.Label _restPrice;
        private System.Windows.Forms.PictureBox _restPic;
    }
}

