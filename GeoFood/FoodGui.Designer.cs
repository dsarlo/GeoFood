﻿namespace GeoFood
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodGui));
            this._submitButton = new System.Windows.Forms.Button();
            this._genPanel = new System.Windows.Forms.Panel();

            this._restaurantPanel = new System.Windows.Forms.Panel();
            this._restRatePbox = new System.Windows.Forms.PictureBox();
            this._restPic = new System.Windows.Forms.PictureBox();
            this._restPrice = new System.Windows.Forms.Label();
            this._restName = new System.Windows.Forms.Label();
            this._loadPanel = new System.Windows.Forms.Panel();
            this._prefPanel = new System.Windows.Forms.Panel();
            this._prefNext = new System.Windows.Forms.Button();
            this._prefLabel = new System.Windows.Forms.Label();
            this._foodPrefDrop = new System.Windows.Forms.ComboBox();
            this._genPanel.SuspendLayout();

            this._restaurantPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._restRatePbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._restPic)).BeginInit();
            this._prefPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _submitButton
            // 
            this._submitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._submitButton.Location = new System.Drawing.Point(117, 83);
            this._submitButton.Name = "_submitButton";
            this._submitButton.Size = new System.Drawing.Size(154, 51);
            this._submitButton.TabIndex = 1;
            this._submitButton.Text = "Generate a Restaurant!";
            this._submitButton.UseVisualStyleBackColor = true;
            this._submitButton.Click += new System.EventHandler(this._submitButton_Click);
            // 
            // _genPanel
            // 
            this._genPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._genPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._genPanel.Controls.Add(this._restaurantPanel);
            this._genPanel.Controls.Add(this._submitButton);
            this._genPanel.Location = new System.Drawing.Point(12, 13);
            this._genPanel.Name = "_genPanel";
            this._genPanel.Size = new System.Drawing.Size(389, 277);
            this._genPanel.TabIndex = 0;
            // 
            // _restaurantPanel
            // 
            this._restaurantPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._restaurantPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._restaurantPanel.Controls.Add(this._restRatePbox);
            this._restaurantPanel.Controls.Add(this._restPic);
            this._restaurantPanel.Controls.Add(this._restPrice);
            this._restaurantPanel.Controls.Add(this._restName);
            this._restaurantPanel.Location = new System.Drawing.Point(18, 154);
            this._restaurantPanel.Name = "_restaurantPanel";
            this._restaurantPanel.Size = new System.Drawing.Size(353, 100);
            this._restaurantPanel.TabIndex = 6;
            // 
            // _restRatePbox
            // 
            this._restRatePbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._restRatePbox.Location = new System.Drawing.Point(21, 43);
            this._restRatePbox.Name = "_restRatePbox";
            this._restRatePbox.Size = new System.Drawing.Size(92, 17);
            this._restRatePbox.TabIndex = 9;
            this._restRatePbox.TabStop = false;
            // 
            // _restPic
            // 
            this._restPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._restPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._restPic.InitialImage = null;
            this._restPic.Location = new System.Drawing.Point(248, 3);
            this._restPic.Name = "_restPic";
            this._restPic.Size = new System.Drawing.Size(100, 92);
            this._restPic.TabIndex = 8;
            this._restPic.TabStop = false;
            // 
            // _restRatePbox
            // 
            this._restRatePbox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this._restRatePbox.Location = new System.Drawing.Point(21, 43);
            this._restRatePbox.Name = "_restRatePbox";
            this._restRatePbox.Size = new System.Drawing.Size(92, 17);
            this._restRatePbox.TabIndex = 9;
            this._restRatePbox.TabStop = false;
            // 
            // _restPic
            // 
            this._restPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
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
            this._restPrice.Size = new System.Drawing.Size(0, 20);
            this._restPrice.TabIndex = 7;
            // 
            // _restName
            // 
            this._restName.AutoSize = true;
            this._restName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._restName.Location = new System.Drawing.Point(17, 19);
            this._restName.Name = "_restName";
            this._restName.Size = new System.Drawing.Size(0, 20);
            this._restName.TabIndex = 5;
            // 
            // _loadPanel
            // 
            this._loadPanel.Location = new System.Drawing.Point(12, 311);
            this._loadPanel.Name = "_loadPanel";
            this._loadPanel.Size = new System.Drawing.Size(389, 278);
            this._loadPanel.TabIndex = 2;
            // 
            // _prefPanel
            // 
            this._prefPanel.BackColor = System.Drawing.Color.White;
            this._prefPanel.BackgroundImage = global::GeoFood.Properties.Resources.prefbg2;
            this._prefPanel.Controls.Add(this._prefNext);
            this._prefPanel.Controls.Add(this._prefLabel);
            this._prefPanel.Controls.Add(this._foodPrefDrop);
            this._prefPanel.Location = new System.Drawing.Point(12, 12);
            this._prefPanel.Name = "_prefPanel";
            this._prefPanel.Size = new System.Drawing.Size(389, 278);
            this._prefPanel.TabIndex = 1;
            // 
            // _prefNext
            // 
            this._prefNext.BackColor = System.Drawing.Color.Transparent;
            this._prefNext.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("_prefNext.BackgroundImage")));
            this._prefNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this._prefNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._prefNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._prefNext.ForeColor = System.Drawing.Color.Transparent;
            this._prefNext.Location = new System.Drawing.Point(254, 219);
            this._prefNext.Name = "_prefNext";
            this._prefNext.Size = new System.Drawing.Size(121, 51);
            this._prefNext.TabIndex = 7;
            this._prefNext.UseVisualStyleBackColor = false;
            this._prefNext.Click += new System.EventHandler(this._prefNext_Click);
            // 
            // _prefLabel
            // 
            this._prefLabel.AutoSize = true;
            this._prefLabel.BackColor = System.Drawing.Color.Transparent;
            this._prefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._prefLabel.Location = new System.Drawing.Point(36, 95);
            this._prefLabel.Name = "_prefLabel";
            this._prefLabel.Size = new System.Drawing.Size(211, 20);
            this._prefLabel.TabIndex = 1;
            this._prefLabel.Text = "What are you hungry for?";
            // 
            // _foodPrefDrop
            // 
            this._foodPrefDrop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._foodPrefDrop.ForeColor = System.Drawing.Color.Black;
            this._foodPrefDrop.FormattingEnabled = true;
            this._foodPrefDrop.Location = new System.Drawing.Point(115, 144);
            this._foodPrefDrop.Name = "_foodPrefDrop";
            this._foodPrefDrop.Size = new System.Drawing.Size(158, 28);
            this._foodPrefDrop.TabIndex = 2;
            this._foodPrefDrop.SelectedIndexChanged += new System.EventHandler(this._foodPrefDrop_SelectedIndexChanged);
            // 
            // FoodGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 302);
            this.Controls.Add(this._loadPanel);
            this.Controls.Add(this._prefPanel);
            this.Controls.Add(this._genPanel);
            this.Name = "FoodGui";
            this.Text = "GeoFood";
            this._genPanel.ResumeLayout(false);

            this._restaurantPanel.ResumeLayout(false);
            this._restaurantPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._restRatePbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._restPic)).EndInit();
            this._prefPanel.ResumeLayout(false);
            this._prefPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _submitButton;
        private System.Windows.Forms.Label _prefLabel;
        private System.Windows.Forms.ComboBox _foodPrefDrop;
        private System.Windows.Forms.Panel _genPanel;
        private System.Windows.Forms.Panel _restaurantPanel;
        private System.Windows.Forms.Label _restName;
        private System.Windows.Forms.Label _restPrice;
        private System.Windows.Forms.PictureBox _restPic;
        private System.Windows.Forms.PictureBox _restRatePbox;
        private System.Windows.Forms.Panel _prefPanel;
        private System.Windows.Forms.Button _prefNext;
        private System.Windows.Forms.Panel _loadPanel;
    }
}

