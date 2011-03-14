<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.rtbOutput = New System.Windows.Forms.RichTextBox()
        Me.butGetZipDS = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.butGetDS = New System.Windows.Forms.Button()
        Me.butGetDSZipPlus = New System.Windows.Forms.Button()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.butGetDSZipPlus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.butGetDS)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rtbOutput)
        Me.SplitContainer1.Panel1.Controls.Add(Me.butGetZipDS)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(855, 410)
        Me.SplitContainer1.SplitterDistance = 89
        Me.SplitContainer1.TabIndex = 0
        '
        'rtbOutput
        '
        Me.rtbOutput.Dock = System.Windows.Forms.DockStyle.Right
        Me.rtbOutput.Location = New System.Drawing.Point(125, 0)
        Me.rtbOutput.Name = "rtbOutput"
        Me.rtbOutput.Size = New System.Drawing.Size(730, 89)
        Me.rtbOutput.TabIndex = 1
        Me.rtbOutput.Text = ""
        '
        'butGetZipDS
        '
        Me.butGetZipDS.Location = New System.Drawing.Point(12, 34)
        Me.butGetZipDS.Name = "butGetZipDS"
        Me.butGetZipDS.Size = New System.Drawing.Size(107, 23)
        Me.butGetZipDS.TabIndex = 0
        Me.butGetZipDS.Text = "Get Zip DS"
        Me.butGetZipDS.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(855, 317)
        Me.DataGridView1.TabIndex = 0
        '
        'butGetDS
        '
        Me.butGetDS.Location = New System.Drawing.Point(12, 63)
        Me.butGetDS.Name = "butGetDS"
        Me.butGetDS.Size = New System.Drawing.Size(107, 23)
        Me.butGetDS.TabIndex = 2
        Me.butGetDS.Text = "Get DS"
        Me.butGetDS.UseVisualStyleBackColor = True
        '
        'butGetDSZipPlus
        '
        Me.butGetDSZipPlus.Location = New System.Drawing.Point(12, 5)
        Me.butGetDSZipPlus.Name = "butGetDSZipPlus"
        Me.butGetDSZipPlus.Size = New System.Drawing.Size(107, 23)
        Me.butGetDSZipPlus.TabIndex = 3
        Me.butGetDSZipPlus.Text = "Get Zip DS+"
        Me.butGetDSZipPlus.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(855, 410)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmMain"
        Me.Text = "WebZip"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents rtbOutput As System.Windows.Forms.RichTextBox
    Friend WithEvents butGetZipDS As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents butGetDS As System.Windows.Forms.Button
    Friend WithEvents butGetDSZipPlus As System.Windows.Forms.Button

End Class
