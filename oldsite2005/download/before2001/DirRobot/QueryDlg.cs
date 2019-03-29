using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace DirRobot
{
	/// <summary>
	/// Summary description for QueryDlg.
	/// </summary>
	public class QueryDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textDlg;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnQuit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public QueryDlg()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.textDlg = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.btnQuit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// textDlg
			// 
			this.textDlg.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.textDlg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textDlg.Location = new System.Drawing.Point(8, 8);
			this.textDlg.Multiline = true;
			this.textDlg.Name = "textDlg";
			this.textDlg.ReadOnly = true;
			this.textDlg.Size = new System.Drawing.Size(392, 168);
			this.textDlg.TabIndex = 0;
			this.textDlg.TabStop = false;
			this.textDlg.Text = "";
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
			this.button1.Location = new System.Drawing.Point(8, 216);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "Yes";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.No;
			this.button2.Location = new System.Drawing.Point(104, 216);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "No";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(192, 216);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(80, 32);
			this.button3.TabIndex = 1;
			this.button3.Text = "No to all";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// btnQuit
			// 
			this.btnQuit.DialogResult = System.Windows.Forms.DialogResult.Abort;
			this.btnQuit.Location = new System.Drawing.Point(320, 216);
			this.btnQuit.Name = "btnQuit";
			this.btnQuit.Size = new System.Drawing.Size(80, 32);
			this.btnQuit.TabIndex = 1;
			this.btnQuit.Text = "Quit";
			// 
			// QueryDlg
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.CancelButton = this.btnQuit;
			this.ClientSize = new System.Drawing.Size(408, 269);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.textDlg,
																		  this.button2,
																		  this.button3,
																		  this.btnQuit});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Location = new System.Drawing.Point(200, 0);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "QueryDlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Robot Query";
			this.ResumeLayout(false);

		}
		#endregion

		private DlgResult dlgResult;
		/// <summary>
		/// Show Modal dialog box wth the query string, and the buttons as specified by nKind, Return the button result
		/// </summary>
		public DlgResult ShowMe(string strQuery, DlgType nKind)
		{
			textDlg.Text = strQuery;
			// build buttons
			button3.Visible = (nKind == DlgType.YESNO_NOTOALL_QUIT);
			btnQuit.Visible = ((nKind == DlgType.YESNO_QUIT) || (nKind== DlgType.YESNO_NOTOALL_QUIT));
			dlgResult = DlgResult.Quit;
			ShowDialog();
			return dlgResult;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			dlgResult = DlgResult.Yes;
			
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			dlgResult = DlgResult.No;
		}
		private void button3_Click(object sender, System.EventArgs e)
		{
			dlgResult = DlgResult.Notoall;
			Close();
		}
	}
	public enum DlgType
	{YESNO, YESNO_QUIT, YESNO_NOTOALL_QUIT}
	public enum DlgResult
	{Yes,No,Notoall,Quit}
		
}
