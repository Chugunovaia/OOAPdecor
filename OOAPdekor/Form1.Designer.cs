namespace OOAPdekor
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
			this.map_panel = new System.Windows.Forms.Panel();
			this.start = new System.Windows.Forms.Button();
			this.castle = new System.Windows.Forms.Button();
			this.knight = new System.Windows.Forms.Button();
			this.map_panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// map_panel
			// 
			this.map_panel.Controls.Add(this.start);
			this.map_panel.Location = new System.Drawing.Point(7, 6);
			this.map_panel.Name = "map_panel";
			this.map_panel.Size = new System.Drawing.Size(631, 549);
			this.map_panel.TabIndex = 0;
			// 
			// start
			// 
			this.start.Location = new System.Drawing.Point(257, 235);
			this.start.Name = "start";
			this.start.Size = new System.Drawing.Size(115, 38);
			this.start.TabIndex = 0;
			this.start.Text = "start";
			this.start.UseVisualStyleBackColor = true;
			this.start.Click += new System.EventHandler(this.start_Click);
			// 
			// castle
			// 
			this.castle.Location = new System.Drawing.Point(56, 612);
			this.castle.Name = "castle";
			this.castle.Size = new System.Drawing.Size(115, 38);
			this.castle.TabIndex = 0;
			this.castle.Text = "new castle";
			this.castle.UseVisualStyleBackColor = true;
			this.castle.Visible = false;
			this.castle.Click += new System.EventHandler(this.castle_Click);
			// 
			// knight
			// 
			this.knight.Location = new System.Drawing.Point(442, 612);
			this.knight.Name = "knight";
			this.knight.Size = new System.Drawing.Size(115, 38);
			this.knight.TabIndex = 0;
			this.knight.Text = "new knight";
			this.knight.UseVisualStyleBackColor = true;
			this.knight.Visible = false;
			this.knight.Click += new System.EventHandler(this.knight_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(736, 767);
			this.Controls.Add(this.knight);
			this.Controls.Add(this.castle);
			this.Controls.Add(this.map_panel);
			this.Name = "Form1";
			this.Text = "Form1";
			this.map_panel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel map_panel;
		private System.Windows.Forms.Button start;
		private System.Windows.Forms.Button castle;
		private System.Windows.Forms.Button knight;
	}
}

