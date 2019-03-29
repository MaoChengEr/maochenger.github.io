using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace DirRobot
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class AgentWnd : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox txtOutput;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.TextBox RootPath;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterColum;
		private System.Windows.Forms.DataGrid dataGridColumn;
		private DirRobot.dsColumn dsColumn1;
		private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapterArticle;
		private DirRobot.dsRobArticle dsRobArticle1;
		private System.Windows.Forms.DataGrid dataRobArticle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Button btnShowResult;
		private System.Windows.Forms.Button update;
		private System.Windows.Forms.Button btnChangeDB;
		private System.Data.OleDb.OleDbConnection oleDbConnection1;
		private System.Data.OleDb.OleDbCommand oleDbSelectCommand2;
		private System.Data.OleDb.OleDbCommand oleDbInsertCommand2;
		private System.Data.OleDb.OleDbCommand oleDbUpdateCommand2;
		private System.Data.OleDb.OleDbCommand oleDbDeleteCommand2;

		private QueryDlg queryDlg;
		public AgentWnd()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			queryDlg = new QueryDlg();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.RootPath = new System.Windows.Forms.TextBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.oleDbDataAdapterColum = new System.Data.OleDb.OleDbDataAdapter();
			this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
			this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
			this.dataGridColumn = new System.Windows.Forms.DataGrid();
			this.dsColumn1 = new DirRobot.dsColumn();
			this.oleDbDataAdapterArticle = new System.Data.OleDb.OleDbDataAdapter();
			this.dsRobArticle1 = new DirRobot.dsRobArticle();
			this.dataRobArticle = new System.Windows.Forms.DataGrid();
			this.panel1 = new System.Windows.Forms.Panel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.btnShowResult = new System.Windows.Forms.Button();
			this.update = new System.Windows.Forms.Button();
			this.btnChangeDB = new System.Windows.Forms.Button();
			this.oleDbSelectCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbInsertCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbUpdateCommand2 = new System.Data.OleDb.OleDbCommand();
			this.oleDbDeleteCommand2 = new System.Data.OleDb.OleDbCommand();
			((System.ComponentModel.ISupportInitialize)(this.dataGridColumn)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsColumn1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRobArticle1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRobArticle)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// RootPath
			// 
			this.RootPath.Location = new System.Drawing.Point(8, 32);
			this.RootPath.Name = "RootPath";
			this.RootPath.Size = new System.Drawing.Size(400, 21);
			this.RootPath.TabIndex = 0;
			this.RootPath.Text = "C:\\BroodingNet\\programs";
			// 
			// btnStart
			// 
			this.btnStart.Location = new System.Drawing.Point(8, 64);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(88, 24);
			this.btnStart.TabIndex = 1;
			this.btnStart.Text = "Go!";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(176, 112);
			this.txtOutput.Multiline = true;
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.Size = new System.Drawing.Size(344, 24);
			this.txtOutput.TabIndex = 2;
			this.txtOutput.Text = "";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(416, 32);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(32, 21);
			this.btnBrowse.TabIndex = 3;
			this.btnBrowse.Text = "...";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// oleDbDataAdapterColum
			// 
			this.oleDbDataAdapterColum.DeleteCommand = this.oleDbDeleteCommand1;
			this.oleDbDataAdapterColum.InsertCommand = this.oleDbInsertCommand1;
			this.oleDbDataAdapterColum.SelectCommand = this.oleDbSelectCommand1;
			this.oleDbDataAdapterColum.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											new System.Data.Common.DataTableMapping("Table", "ANclass", new System.Data.Common.DataColumnMapping[] {
																																																					   new System.Data.Common.DataColumnMapping("Nclass", "Nclass"),
																																																					   new System.Data.Common.DataColumnMapping("locked", "locked"),
																																																					   new System.Data.Common.DataColumnMapping("Nclassid", "Nclassid"),
																																																					   new System.Data.Common.DataColumnMapping("content", "content"),
																																																					   new System.Data.Common.DataColumnMapping("order", "order"),
																																																					   new System.Data.Common.DataColumnMapping("relativePath", "relativePath")})});
			this.oleDbDataAdapterColum.UpdateCommand = this.oleDbUpdateCommand1;
			this.oleDbDataAdapterColum.RowUpdated += new System.Data.OleDb.OleDbRowUpdatedEventHandler(this.oleDbDataAdapter1_RowUpdated);
			// 
			// oleDbDeleteCommand1
			// 
			this.oleDbDeleteCommand1.CommandText = "DELETE FROM ANclass WHERE (Nclassid = ?) AND (Nclass = ? OR ? IS NULL AND Nclass " +
				"IS NULL) AND (content = ? OR ? IS NULL AND content IS NULL) AND (locked = ?) AND" +
				" (relativePath = ? OR ? IS NULL AND relativePath IS NULL)";
			this.oleDbDeleteCommand1.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nclassid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Nclassid", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nclass", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Nclass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nclass1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Nclass", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_content", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "content", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_content1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "content", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_locked", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "locked", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_relativePath", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "relativePath", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_relativePath1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "relativePath", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbConnection1
			// 
			this.oleDbConnection1.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source=C:\lxzsrc\DirRobot\bin\Debug\article.mdb;Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False";
			// 
			// oleDbInsertCommand1
			// 
			this.oleDbInsertCommand1.CommandText = "INSERT INTO ANclass(Nclass, locked, content, [order], relativePath) VALUES (?, ?," +
				" ?, ?, ?)";
			this.oleDbInsertCommand1.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nclass", System.Data.OleDb.OleDbType.VarWChar, 50, "Nclass"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("locked", System.Data.OleDb.OleDbType.Boolean, 2, "locked"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("content", System.Data.OleDb.OleDbType.VarWChar, 0, "content"));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("order", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "order", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("relativePath", System.Data.OleDb.OleDbType.VarWChar, 255, "relativePath"));
			// 
			// oleDbSelectCommand1
			// 
			this.oleDbSelectCommand1.CommandText = "SELECT Nclass, locked, Nclassid, content, [order], relativePath FROM ANclass";
			this.oleDbSelectCommand1.Connection = this.oleDbConnection1;
			// 
			// oleDbUpdateCommand1
			// 
			this.oleDbUpdateCommand1.CommandText = @"UPDATE ANclass SET Nclass = ?, locked = ?, content = ?, [order] = ?, relativePath = ? WHERE (Nclassid = ?) AND (Nclass = ? OR ? IS NULL AND Nclass IS NULL) AND (content = ? OR ? IS NULL AND content IS NULL) AND (locked = ?) AND (relativePath = ? OR ? IS NULL AND relativePath IS NULL)";
			this.oleDbUpdateCommand1.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nclass", System.Data.OleDb.OleDbType.VarWChar, 50, "Nclass"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("locked", System.Data.OleDb.OleDbType.Boolean, 2, "locked"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("content", System.Data.OleDb.OleDbType.VarWChar, 0, "content"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("order", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "order", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("relativePath", System.Data.OleDb.OleDbType.VarWChar, 255, "relativePath"));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nclassid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Nclassid", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nclass", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Nclass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nclass1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Nclass", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_content", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "content", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_content1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "content", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_locked", System.Data.OleDb.OleDbType.Boolean, 2, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "locked", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_relativePath", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "relativePath", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand1.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_relativePath1", System.Data.OleDb.OleDbType.VarWChar, 255, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "relativePath", System.Data.DataRowVersion.Original, null));
			// 
			// dataGridColumn
			// 
			this.dataGridColumn.CaptionText = "Column";
			this.dataGridColumn.DataMember = "ANclass";
			this.dataGridColumn.DataSource = this.dsColumn1;
			this.dataGridColumn.Dock = System.Windows.Forms.DockStyle.Left;
			this.dataGridColumn.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGridColumn.Name = "dataGridColumn";
			this.dataGridColumn.Size = new System.Drawing.Size(160, 240);
			this.dataGridColumn.TabIndex = 4;
			this.dataGridColumn.Click += new System.EventHandler(this.dataGridColumn_Click);
			// 
			// dsColumn1
			// 
			this.dsColumn1.DataSetName = "dsColumn";
			this.dsColumn1.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.dsColumn1.Namespace = "http://www.tempuri.org/dsColumn.xsd";
			// 
			// oleDbDataAdapterArticle
			// 
			this.oleDbDataAdapterArticle.DeleteCommand = this.oleDbDeleteCommand2;
			this.oleDbDataAdapterArticle.InsertCommand = this.oleDbInsertCommand2;
			this.oleDbDataAdapterArticle.SelectCommand = this.oleDbSelectCommand2;
			this.oleDbDataAdapterArticle.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
																											  new System.Data.Common.DataTableMapping("Table", "RobArticle", new System.Data.Common.DataColumnMapping[] {
																																																							new System.Data.Common.DataColumnMapping("articleid", "articleid"),
																																																							new System.Data.Common.DataColumnMapping("classid", "classid"),
																																																							new System.Data.Common.DataColumnMapping("content", "content"),
																																																							new System.Data.Common.DataColumnMapping("Nclassid", "Nclassid"),
																																																							new System.Data.Common.DataColumnMapping("order", "order"),
																																																							new System.Data.Common.DataColumnMapping("title", "title"),
																																																							new System.Data.Common.DataColumnMapping("hits", "hits"),
																																																							new System.Data.Common.DataColumnMapping("Nkey", "Nkey"),
																																																							new System.Data.Common.DataColumnMapping("writefrom", "writefrom"),
																																																							new System.Data.Common.DataColumnMapping("writer", "writer")})});
			this.oleDbDataAdapterArticle.UpdateCommand = this.oleDbUpdateCommand2;
			// 
			// dsRobArticle1
			// 
			this.dsRobArticle1.DataSetName = "dsRobArticle";
			this.dsRobArticle1.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.dsRobArticle1.Namespace = "http://www.tempuri.org/dsRobArticle.xsd";
			// 
			// dataRobArticle
			// 
			this.dataRobArticle.CaptionText = "Articles";
			this.dataRobArticle.DataMember = "RobArticle";
			this.dataRobArticle.DataSource = this.dsRobArticle1;
			this.dataRobArticle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataRobArticle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataRobArticle.Location = new System.Drawing.Point(168, 0);
			this.dataRobArticle.Name = "dataRobArticle";
			this.dataRobArticle.Size = new System.Drawing.Size(416, 240);
			this.dataRobArticle.TabIndex = 5;
			// 
			// panel1
			// 
			this.panel1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.dataRobArticle,
																				 this.splitter1,
																				 this.dataGridColumn});
			this.panel1.Location = new System.Drawing.Point(8, 144);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(584, 240);
			this.panel1.TabIndex = 6;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(160, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 240);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// btnShowResult
			// 
			this.btnShowResult.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnShowResult.Location = new System.Drawing.Point(488, 64);
			this.btnShowResult.Name = "btnShowResult";
			this.btnShowResult.Size = new System.Drawing.Size(88, 23);
			this.btnShowResult.TabIndex = 7;
			this.btnShowResult.Text = "Show Result";
			this.btnShowResult.Click += new System.EventHandler(this.btnShowResult_Click);
			// 
			// update
			// 
			this.update.Location = new System.Drawing.Point(8, 112);
			this.update.Name = "update";
			this.update.Size = new System.Drawing.Size(136, 23);
			this.update.TabIndex = 8;
			this.update.Text = "verify-->update";
			this.update.Click += new System.EventHandler(this.update_Click);
			// 
			// btnChangeDB
			// 
			this.btnChangeDB.Location = new System.Drawing.Point(464, 32);
			this.btnChangeDB.Name = "btnChangeDB";
			this.btnChangeDB.Size = new System.Drawing.Size(112, 23);
			this.btnChangeDB.TabIndex = 9;
			this.btnChangeDB.Text = "change database";
			this.btnChangeDB.Click += new System.EventHandler(this.btnChangeDB_Click);
			// 
			// oleDbSelectCommand2
			// 
			this.oleDbSelectCommand2.CommandText = "SELECT articleid, classid, content, Nclassid, [order], title, hits, Nkey, writefr" +
				"om, writer FROM RobArticle WHERE (Nclassid = ?)";
			this.oleDbSelectCommand2.Connection = this.oleDbConnection1;
			this.oleDbSelectCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nclassid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Nclassid", System.Data.DataRowVersion.Current, null));
			// 
			// oleDbInsertCommand2
			// 
			this.oleDbInsertCommand2.CommandText = "INSERT INTO RobArticle(classid, content, Nclassid, [order], title, hits, Nkey, wr" +
				"itefrom, writer) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)";
			this.oleDbInsertCommand2.Connection = this.oleDbConnection1;
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("classid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "classid", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("content", System.Data.OleDb.OleDbType.VarWChar, 0, "content"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nclassid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Nclassid", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("order", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "order", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("title", System.Data.OleDb.OleDbType.VarWChar, 50, "title"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("hits", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "hits", System.Data.DataRowVersion.Current, null));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nkey", System.Data.OleDb.OleDbType.VarWChar, 50, "Nkey"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("writefrom", System.Data.OleDb.OleDbType.VarWChar, 0, "writefrom"));
			this.oleDbInsertCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("writer", System.Data.OleDb.OleDbType.VarWChar, 50, "writer"));
			// 
			// oleDbUpdateCommand2
			// 
			this.oleDbUpdateCommand2.CommandText = @"UPDATE RobArticle SET classid = ?, content = ?, Nclassid = ?, [order] = ?, title = ?, hits = ?, Nkey = ?, writefrom = ?, writer = ? WHERE (articleid = ?) AND (Nkey = ? OR ? IS NULL AND Nkey IS NULL) AND (content = ? OR ? IS NULL AND content IS NULL) AND (title = ? OR ? IS NULL AND title IS NULL) AND (writefrom = ? OR ? IS NULL AND writefrom IS NULL) AND (writer = ? OR ? IS NULL AND writer IS NULL)";
			this.oleDbUpdateCommand2.Connection = this.oleDbConnection1;
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("classid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "classid", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("content", System.Data.OleDb.OleDbType.VarWChar, 0, "content"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nclassid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "Nclassid", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("order", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "order", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("title", System.Data.OleDb.OleDbType.VarWChar, 50, "title"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("hits", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "hits", System.Data.DataRowVersion.Current, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Nkey", System.Data.OleDb.OleDbType.VarWChar, 50, "Nkey"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("writefrom", System.Data.OleDb.OleDbType.VarWChar, 0, "writefrom"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("writer", System.Data.OleDb.OleDbType.VarWChar, 50, "writer"));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_articleid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "articleid", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nkey", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Nkey", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param92", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_content", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "content", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param94", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_title", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "title", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param96", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_writefrom", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "writefrom", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param98", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_writer", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "writer", System.Data.DataRowVersion.Original, null));
			this.oleDbUpdateCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Param100", System.Data.OleDb.OleDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "", System.Data.DataRowVersion.Original, null));
			// 
			// oleDbDeleteCommand2
			// 
			this.oleDbDeleteCommand2.CommandText = @"DELETE FROM RobArticle WHERE (articleid = ?) AND (Nkey = ? OR ? IS NULL AND Nkey IS NULL) AND (content = ? OR ? IS NULL AND content IS NULL) AND (title = ? OR ? IS NULL AND title IS NULL) AND (writefrom = ? OR ? IS NULL AND writefrom IS NULL) AND (writer = ? OR ? IS NULL AND writer IS NULL)";
			this.oleDbDeleteCommand2.Connection = this.oleDbConnection1;
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_articleid", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(10)), ((System.Byte)(0)), "articleid", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nkey", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Nkey", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_Nkey1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "Nkey", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_content", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "content", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_content1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "content", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_title", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "title", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_title1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "title", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_writefrom", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "writefrom", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_writefrom1", System.Data.OleDb.OleDbType.VarWChar, 0, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "writefrom", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_writer", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "writer", System.Data.DataRowVersion.Original, null));
			this.oleDbDeleteCommand2.Parameters.Add(new System.Data.OleDb.OleDbParameter("Original_writer1", System.Data.OleDb.OleDbType.VarWChar, 50, System.Data.ParameterDirection.Input, false, ((System.Byte)(0)), ((System.Byte)(0)), "writer", System.Data.DataRowVersion.Original, null));
			// 
			// AgentWnd
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(592, 389);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnChangeDB,
																		  this.update,
																		  this.btnShowResult,
																		  this.btnBrowse,
																		  this.txtOutput,
																		  this.btnStart,
																		  this.RootPath,
																		  this.panel1});
			this.MinimumSize = new System.Drawing.Size(536, 416);
			this.Name = "AgentWnd";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Directory Agent";
			this.Load += new System.EventHandler(this.AgentWnd_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridColumn)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsColumn1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dsRobArticle1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataRobArticle)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new AgentWnd());
		}

		private void AgentWnd_Load(object sender, System.EventArgs e)
		{
			string str = Path.GetDirectoryName(Application.ExecutablePath)+"\\article.mdb";
			oleDbConnection1.ConnectionString=string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source={0};Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False"
							, str);
			
			if(TestConnection()==false)
			{
				MessageBox.Show("we can not find the ariticle.mdb. Please locate it. if you fail twice, the application will be closed.");
				ChangeDBConnection();
			}
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			// Set RootPath with the full root path selected
			OpenFileDialog dlgOpenFile = new OpenFileDialog();
			if(dlgOpenFile.ShowDialog() == DialogResult.OK)
			{
				if(dlgOpenFile.CheckFileExists == true)
				{
					RootPath.Text = Path.GetDirectoryName( dlgOpenFile.FileName );
				}
			}
		}

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			// the following agent actions should be encapeculated in a sperate class
			
			// Set Current directory to the root of the path, so that we 
			// could use relative path there afterwards.
			Directory.SetCurrentDirectory(RootPath.Text);
			
			dsColumn1.Clear();
			oleDbDataAdapterColum.Fill(dsColumn1);
			// recursively do the job
			try
			{
				strRobOutput=""; // clear last result
				SingleDirAgent(RootPath.Text, 0,0,0,0);
				RobotOutput("The entire directory is searched without error.");
			}
			catch
			{
				// user has terminated the progress.
				RobotOutput("user has terminated the progress.");
			}
			RobotOutput("if there are locked column path, Unlock it if you want to update it with the robot.");
			RobotOutput("Please press the \"update dataset\" button to verify and update the database");
			btnShowResult_Click(null,null);
		}
		#region Agent Article writer
		/// <summary>
		/// Recursive function for dealing with contents in a diretory
		/// dir: the directory to be working in.
		/// instruction: 0 Agent will ask the user to decide whether an article or a subdirectory
		///					 is a colum or not.
		///				   1 Agent will assume that all contents in the dir should be 
		///	under the  colum specified by idColum
		///				   -1 Agent will assume that all contents in the dir should be
		///	treated like individual colums
		/// firstOrder: (when instruction =0) start from the firstOrder when creating a new colum
		///				 (when instruction =1) represent folder depth when creating pages in a colum
		/// secOrder: start from the secOrder when creating a page in a colum
		/// idColum: ID of a colum in the database, See instruction==1.
		/// [note]: an exception will be thrown if user terminate the progress
		/// </summary>
		public void SingleDirAgent(string dir, int instruction, int firstOrder, int secOrd, int idColum)
		{
			DirectoryInfo di = new DirectoryInfo(dir);
			
			if(instruction == 0)
			{
				// get a reference to each important file in that directory
				// HTML file articles
				FileInfo[] fiArr = di.GetFiles("*.htm*");
				
				// print out the names of the files
				foreach (FileInfo fri in fiArr)
				{
					// if column path has been locked in the database, we will skip it without  asking the user for instructions
					if(IsColumnPathLocked(fri.FullName) == true)
					{
						RobotOutput(fri.FullName+" is locked and has been skipped.");
						break;
					}
					// later change MessageBox to a user-created dialog with article preview
					// ...
					string quest = "Do you wish to treat the file "+fri.FullName
						+" as a colum?\r\n" + "If you choose NO, the file will not be added.\r\n"
						+"If you choose No to all, all remaining files and directories will be skipped";
					
					switch(queryDlg.ShowMe(quest, DlgType.YESNO_NOTOALL_QUIT))
					{
					case DlgResult.Yes:
					{
						// file is treated as a colum
						
						// create a new Single-File-Colum
						dsColumn.ANclassRow row = dsColumn1.ANclass.NewANclassRow();
						row["order"] = firstOrder++;
						row["Nclass"] = Path.GetFileNameWithoutExtension(fri.Name);
						row["content"] = "";
						// TODO: make fri.DirectoryName relative
						row["relativePath"] = fri.FullName;
						
						if(PrepareDsColumn(ref row)==true)
						{
							// Add page to Nclassid column
							dsRobArticle.RobArticleRow rA = dsRobArticle1.RobArticle.NewRobArticleRow();
							// TODO: add approprite content
							rA["writer"]="HTML";
							rA["writefrom"]=fri.FullName;
							rA["title"] = Path.GetFileNameWithoutExtension(fri.Name);
							rA["content"] = "";
							rA.hits=0;
							
							rA.Nclassid = row.Nclassid;
							dsRobArticle1.Clear();
							dsRobArticle1.RobArticle.AddRobArticleRow(rA);
							
							// update data store, since this column contains only this one page
							oleDbDataAdapterArticle.Update(dsRobArticle1);
							UpdateArticleTitle(row.Nclass);
						}
						
						break;
					}
					case DlgResult.No:
					{
						// file is NOT treated as a colum.Since there is no colum 
						// to contain it, the agent will neglect it.
						
						// output to report that fri(file) has been neglected by the user
						// ...
						break;
					}
					case DlgResult.Notoall:
					{
						string str = "All remaining files and subdirectories in "+dir+" have been skipped";
						MessageBox.Show(str,
							"notification", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
					default:
					{
						throw(new Exception("user ceased the agent."));
					}
					}
				}

				// Subdirectories in the work dir.
				// get a reference to each directory in that directory
				DirectoryInfo[] diArr = di.GetDirectories();

				// print out the names of the directories
				foreach (DirectoryInfo dri in diArr)
				{
					if(IsColumnPathLocked(dri.FullName) == true)
					{
						RobotOutput(dri.FullName+" is locked and has been skipped.");
						continue;
					}
					// later change MessageBox to a user-created dialog with article preview
					// ...
					string quest = "Do you wish all the contents in directory "+dri.FullName
						+" to be put in one colum(namely," +dri.Name +")? \r\n"
						+ "If you choose NO, the agent will look into the above directory, and ask for each individual files and subdirs in it.\r\n"
						+"If you choose No to all, the agent will not look into the above directory.";
					switch(queryDlg.ShowMe(quest, DlgType.YESNO_NOTOALL_QUIT))
					{
					case  DlgResult.Yes:
					{
						// dri is treated as a colum
						
						// create a new Directory-based-Colum
						// create a new Single-File-Colum
						dsColumn.ANclassRow row = dsColumn1.ANclass.NewANclassRow();
						row["order"] = firstOrder++;
						row["Nclass"] = dri.Name;
						row["content"] = dri.FullName;
						// TODO: make fri.DirectoryName relative
						row["relativePath"] = dri.FullName;
						
						if(PrepareDsColumn(ref row)==true)
						{
							// Add pages to Nclassid column
							dsRobArticle1.Clear();
							// recursive load with instruction==1
							SingleDirAgent(dri.FullName, 1,0,secOrd,row.Nclassid);
						
							oleDbDataAdapterArticle.Update(dsRobArticle1);
							UpdateArticleTitle(row.Nclass);
						}
						
						break;
					}
					case DlgResult.No:
					{
						// dri is NOT treated as a colum.the agent will look into the this directory, and ask for each individual files and subdirs in it.
						// recursive load with instruction==0
						SingleDirAgent(dri.FullName, 0,firstOrder,secOrd,0);
						break;
					}
					case DlgResult.Notoall:
					{
						break;
					}
					default:
					{
						throw(new Exception("user ceased the agent."));
					}
					}
				}
			}
			else if(instruction == 1)
			{
				// get a reference to each important file in that directory
				
				/// HTML file articles
				FileInfo[] fiArr = di.GetFiles("*.htm*");
				// print out the names of the files
				foreach (FileInfo fri in fiArr)
				{
						// Add page to Nclassid column
						dsRobArticle.RobArticleRow rA = dsRobArticle1.RobArticle.NewRobArticleRow();
						// TODO: add approprite content
						rA["title"] = string.Format("[{0}]{1}",
							firstOrder, Path.GetFileNameWithoutExtension(fri.Name));
						rA["writer"]="HTML";
						rA["writefrom"]=fri.FullName;
						rA["content"] = "";
						rA.hits=0;
						
						rA.Nclassid = idColum;
						rA.order = secOrd++;
						dsRobArticle1.RobArticle.AddRobArticleRow(rA);
				}
				///DOC file articles
				fiArr = di.GetFiles("*.doc");
				// print out the names of the files
				foreach (FileInfo fri in fiArr)
				{
						// Add page to Nclassid column
						dsRobArticle.RobArticleRow rA = dsRobArticle1.RobArticle.NewRobArticleRow();
						// TODO: add approprite content
						rA["title"] = string.Format("[{0}]{1}",
							firstOrder, Path.GetFileNameWithoutExtension(fri.Name));
						rA["writer"]="doc";
						rA["writefrom"]=fri.FullName;
						rA["content"] = "";
						rA.hits=0;

						rA.Nclassid = idColum;
						rA.order = secOrd++;
						dsRobArticle1.RobArticle.AddRobArticleRow(rA);
				}

				/// Image files(*.jpg) aritcles
				fiArr = di.GetFiles("*.jpg");
				
				if(fiArr.Length>0)
				{
					// Add page to Nclassid column
					dsRobArticle.RobArticleRow rA = dsRobArticle1.RobArticle.NewRobArticleRow();
					rA["title"] = string.Format("[{0}]images[{1}..]",
						firstOrder,Path.GetFileNameWithoutExtension(fiArr[0].Name));
					rA["writer"]="image";
					rA["writefrom"]="";
					rA["content"] = "Click the name to view the image.<br>";
					rA.hits=0;

					rA.Nclassid = idColum;
					rA.order = secOrd++;
					foreach (FileInfo fri in fiArr)
					{
						rA["content"] += string.Format("<a href=\"{0}\">{1}</a><br>",
							fri.FullName, fri.Name);
					}
					dsRobArticle1.RobArticle.AddRobArticleRow(rA);
				}
				
				/// ZIP files articles
				fiArr = di.GetFiles("*.zip");
				if(fiArr.Length>0)
				{
					// Add page to Nclassid column
					dsRobArticle.RobArticleRow rA = dsRobArticle1.RobArticle.NewRobArticleRow();
					rA["content"] = "The following files are downloadable.<br>";
					rA["title"]= string.Format("[{0}]downloads[{1}..]",
						firstOrder,Path.GetFileNameWithoutExtension(fiArr[0].Name));
					rA["writer"]="zip";
					rA["writefrom"]="";
					rA.hits=0;

					rA.Nclassid = idColum;
					rA.order = secOrd++;
					foreach (FileInfo fri in fiArr)
					{
						rA["content"] += string.Format("<a href=\"{0}\">{1}</a>...{2}bytes<br>",
							fri.FullName, fri.Name,fri.Length);
					}
					dsRobArticle1.RobArticle.AddRobArticleRow(rA);
				}
				// TODO: other file type articles
				//....


				// Subdirectories in the work dir.
				// get a reference to each directory in that directory
				DirectoryInfo[] diArr = di.GetDirectories();

				// print out the names of the directories
				foreach (DirectoryInfo dri in diArr)
				{
					SingleDirAgent(dri.FullName,1,firstOrder+1, secOrd, idColum);
				}
			}
			else if(instruction == -1)
			{
			}
		}

		#endregion
		private void oleDbDataAdapter1_RowUpdated(object sender, System.Data.OleDb.OleDbRowUpdatedEventArgs e)
		{
		
		}

		private void dataGridColumn_Click(object sender, System.EventArgs e)
		{
			if(dataGridColumn.IsSelected(dataGridColumn.CurrentCell.RowNumber))
			{
				// we will load data into the article datagrid
				dsRobArticle1.Clear();
				try{
					string Nclass = (string)dataGridColumn[dataGridColumn.CurrentCell.RowNumber,0];
					UpdateArticleTitle(Nclass);
					int Nclassid = (int)dataGridColumn[dataGridColumn.CurrentCell.RowNumber,2];
					oleDbDataAdapterArticle.SelectCommand.Parameters["Nclassid"].Value = Nclassid;
					oleDbDataAdapterArticle.Fill(dsRobArticle1);
				}
				catch
				{
					UpdateArticleTitle("");
				}
			}
		}

		/// <summary>
		/// Prepare the column for adding articles. There may be question dialogues within.
		/// Param: row: information about the new column to be prepared.
		/// return: true: A new column has been built. The dsArticle1 dataset has been prepared. 
		///	You can add articles into this dataset, and update when finished.
		///	the row.Nclassid,Nclass contains the the final Nclassid,Nclass that has been successfully prepared
		///	Note that they could be different from the ones originally passed to this function.
		///	In other words, the Nclassid,Nclass and content columns in the original database has been preserved.
		///			false: You got no permission to add any articles in this column,either it's locked
		///	or the user explicitly canceled it.
		/// </summary>
		public bool PrepareDsColumn(ref dsColumn.ANclassRow row)
		{
			// Add or update
			bool bDoUpdate = false;
			bool bAddPage = true;
			//int Nclassid = (int)row["Nclassid"]; // which column to add the new article to
			
			// check to see if the column has already in the column lists.
			// if yes,
			//	   ask the user to decide whether to replace it the new one
			// if no, Procceed to add the column.
			for(int i=0;i<dsColumn1.ANclass.Rows.Count;i++)
			{
				if(dsColumn1.ANclass.Rows[i]["relativePath"].Equals(row["relativePath"]))
				{
					// the column is in the list
					bDoUpdate = true;
					string quest = "A column with the name "+row["Nclass"]
						+" already exsit. Do you wish to replace it(as well as all its robot-based contents) with the new one?" + "If you choose NO, Old column and its content are preserved.";
					if(queryDlg.ShowMe(quest, DlgType.YESNO)==DlgResult.Yes )
					{
						// replace it(as well as all its robot-based contents) with the name one
						dsColumn1.ANclass.Rows[i]["order"] = row["order"];
						row["Nclass"] = dsColumn1.ANclass.Rows[i]["Nclass"];
						row["Nclassid"] = (int)dsColumn1.ANclass.Rows[i]["Nclassid"];
						
						// remove all contents in the list.

						string mySelectQuery = "DELETE FROM RobArticle WHERE(Nclassid="+dsColumn1.ANclass.Rows[i]["Nclassid"]+")";
						OleDbCommand myCommand = new OleDbCommand(mySelectQuery);
						myCommand.Connection = oleDbConnection1;
						oleDbConnection1.Open();
						myCommand.ExecuteNonQuery();
						myCommand.Connection.Close();

//						dsRobArticle1.Clear();
//						oleDbDataAdapterArticle.SelectCommand.Parameters["Nclassid"].Value = row["Nclassid"];
//						oleDbDataAdapterArticle.Fill(dsRobArticle1);
//						
//						for(int j=0;j<dsRobArticle1.RobArticle.Count;j++)
//							dsRobArticle1.RobArticle.Rows[j].Delete();
					}
					else
					{
						bAddPage = false;
					}
				}
			}
			
			if(bAddPage == true)
			{
				if(bDoUpdate == false)
				{
					// insert a column into the dataset and dataset
					dsColumn1.ANclass.AddANclassRow(row);
					oleDbDataAdapterColum.Update(dsColumn1);
					
					// Get the Nclassid of the newly created record and store in dataset.
					string mySelectQuery = "SELECT Nclassid FROM ANclass WHERE(relativePath='"+row.relativePath+"')";
					OleDbCommand myCommand = new OleDbCommand(mySelectQuery);
					myCommand.Connection = oleDbConnection1;
					oleDbConnection1.Open();
					OleDbDataReader reader =  myCommand.ExecuteReader();
					if(reader.Read() == true)
					{
						row["Nclassid"] = reader["Nclassid"];
						// this maks all the rowstates in the dataset to unchanged
						dsColumn1.ANclass.AcceptChanges();
					}
					myCommand.Connection.Close();

				}
			}	
			return bAddPage;
		}

		/// <summary>
		/// Load the datagrid title for articles
		/// </summary>
		public void UpdateArticleTitle(string title)
		{
			if(title.Length==0)
				title = "Articles";
			else
				title = "Articles in "+title;
			dataRobArticle.CaptionText=title;			
		}

		/// <summary>
		/// Check to see if the path  is in the column list and locked.
		/// return false if no such column is found in the list
		/// </summary>
		public bool IsColumnPathLocked(string path)
		{
			bool bIsLocked=false;
					
			// check to see if the column has already in the column lists.
			for(int i=0;i<dsColumn1.ANclass.Rows.Count;i++)
			{
				if(dsColumn1.ANclass.Rows[i]["relativePath"].Equals(path))
				{
					// the column is in the list
					// check if it's locked.
					try{
					bIsLocked = (bool)dsColumn1.ANclass.Rows[i]["locked"];
					}catch{bIsLocked = false;}
					return bIsLocked;
				}
			}
			return bIsLocked;
		}

		private string strRobOutput="";
		/// <summary>
		/// Add to the robot output string the sentence in the parameter
		/// </summary>
		public void RobotOutput(string sentence)
		{
			strRobOutput+=sentence+"\r\n";
		}

		private void btnShowResult_Click(object sender, System.EventArgs e)
		{
			if(strRobOutput.Length==0)
			{
				queryDlg.ShowMe("There are no results to display.\r\nPlease press start button to start.", DlgType.YESNO);
			}
			else
				queryDlg.ShowMe(strRobOutput, DlgType.YESNO);
		}

		/// <summary>
		/// update datasets after varifying
		/// </summary>
		private void update_Click(object sender, System.EventArgs e)
		{
			// validating the contents of the column Dataset
			strRobOutput="";
			bool bOK = true;
			foreach(dsColumn.ANclassRow r in  dsColumn1.ANclass.Rows)
			{
				//validate the existency of the path(file or directory) in each row
				try
				{
					if(r.RowState == DataRowState.Deleted)
						continue;
					bool bEx = Path.HasExtension(r.relativePath);
					if(((bEx==false)	&& (Directory.Exists(r.relativePath) == true)) ||
						((bEx==true) && (File.Exists(r.relativePath) == true)))
					{
						//file or directory does exist.
					}
					else
					{
						RobotOutput(r.relativePath+" does not exist. [id="+r.Nclassid.ToString()+"]");
						bOK = false;
					}
				}
				catch
				{
					RobotOutput(r.relativePath+" does not exist. [id="+r.Nclassid.ToString()+"]");
					bOK = false;
				}
			}
			if(bOK == true)
			{
				RobotOutput("no errors in the column dataset. Do you want to update now?");
			}
			else
			{
				strRobOutput="The following errors about the column dataset are found:\r\n"
					+strRobOutput;
			}
			
			// show results
			DlgResult res =  queryDlg.ShowMe(strRobOutput,DlgType.YESNO);
			
			// update dataset
			if(bOK == true)
			{
				if(res == DlgResult.Yes)
				{
					oleDbDataAdapterColum.Update(dsColumn1);
					oleDbDataAdapterArticle.Update(dsRobArticle1);
				}
			}
			else if(MessageBox.Show("There are errors in the datasets.Do you want to update anyway?","Alert", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				oleDbDataAdapterColum.Update(dsColumn1);
				oleDbDataAdapterArticle.Update(dsRobArticle1);					
			}
		}

		public bool TestConnection()
		{
			bool bOK = true;
			try
			{
				oleDbConnection1.Open();
				oleDbConnection1.Close();
			}
			catch
			{
				bOK=false;
			}
			return bOK;
		}

		public void ChangeDBConnection()
		{
			OpenFileDialog dlgOpenFile = new OpenFileDialog();
			dlgOpenFile.Filter = "(*.mdb)|*.mdb";
			int i=0;
			do
			{
				if(dlgOpenFile.ShowDialog() == DialogResult.OK)
				{
					if(dlgOpenFile.CheckFileExists == true)
					{
						oleDbConnection1.ConnectionString=string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Password="""";User ID=Admin;Data Source={0};Mode=Share Deny None;Extended Properties="""";Jet OLEDB:System database="""";Jet OLEDB:Registry Path="""";Jet OLEDB:Database Password="""";Jet OLEDB:Engine Type=5;Jet OLEDB:Database Locking Mode=1;Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Global Bulk Transactions=1;Jet OLEDB:New Database Password="""";Jet OLEDB:Create System Database=False;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False"
							,dlgOpenFile.FileName);
					}
				}
			}while((TestConnection() == false) && (i++<2));
		}

		private void btnChangeDB_Click(object sender, System.EventArgs e)
		{
			ChangeDBConnection();
		}
	}
}
