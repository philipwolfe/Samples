Public Class Main
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents cmbKeys As System.Windows.Forms.ComboBox
	Friend WithEvents lblKeys As System.Windows.Forms.Label
	Friend WithEvents txtValue As System.Windows.Forms.TextBox
	Friend WithEvents lblValue As System.Windows.Forms.Label
	Friend WithEvents btnUpdate As System.Windows.Forms.Button
	Friend WithEvents btnDelete As System.Windows.Forms.Button
	Friend WithEvents lblEdit As System.Windows.Forms.Label
	Friend WithEvents lblNew As System.Windows.Forms.Label
	Friend WithEvents lblNewKey As System.Windows.Forms.Label
	Friend WithEvents txtNewKey As System.Windows.Forms.TextBox
	Friend WithEvents txtNewValue As System.Windows.Forms.TextBox
	Friend WithEvents lblNewValue As System.Windows.Forms.Label
	Friend WithEvents btnAdd As System.Windows.Forms.Button
	Friend WithEvents btnSave As System.Windows.Forms.Button
	Friend WithEvents lblCreatedBy As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.cmbKeys = New System.Windows.Forms.ComboBox()
		Me.lblKeys = New System.Windows.Forms.Label()
		Me.txtValue = New System.Windows.Forms.TextBox()
		Me.lblValue = New System.Windows.Forms.Label()
		Me.btnUpdate = New System.Windows.Forms.Button()
		Me.btnDelete = New System.Windows.Forms.Button()
		Me.lblEdit = New System.Windows.Forms.Label()
		Me.lblNew = New System.Windows.Forms.Label()
		Me.lblNewKey = New System.Windows.Forms.Label()
		Me.txtNewKey = New System.Windows.Forms.TextBox()
		Me.txtNewValue = New System.Windows.Forms.TextBox()
		Me.lblNewValue = New System.Windows.Forms.Label()
		Me.btnAdd = New System.Windows.Forms.Button()
		Me.btnSave = New System.Windows.Forms.Button()
		Me.lblCreatedBy = New System.Windows.Forms.Label()
		Me.SuspendLayout()
		'
		'cmbKeys
		'
		Me.cmbKeys.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbKeys.Location = New System.Drawing.Point(40, 32)
		Me.cmbKeys.Name = "cmbKeys"
		Me.cmbKeys.Size = New System.Drawing.Size(136, 21)
		Me.cmbKeys.TabIndex = 0
		'
		'lblKeys
		'
		Me.lblKeys.Location = New System.Drawing.Point(8, 32)
		Me.lblKeys.Name = "lblKeys"
		Me.lblKeys.Size = New System.Drawing.Size(32, 21)
		Me.lblKeys.TabIndex = 1
		Me.lblKeys.Text = "Keys:"
		Me.lblKeys.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtValue
		'
		Me.txtValue.Location = New System.Drawing.Point(216, 32)
		Me.txtValue.Name = "txtValue"
		Me.txtValue.Size = New System.Drawing.Size(136, 20)
		Me.txtValue.TabIndex = 1
		Me.txtValue.Text = ""
		'
		'lblValue
		'
		Me.lblValue.Location = New System.Drawing.Point(176, 32)
		Me.lblValue.Name = "lblValue"
		Me.lblValue.Size = New System.Drawing.Size(40, 21)
		Me.lblValue.TabIndex = 3
		Me.lblValue.Text = "Value:"
		Me.lblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnUpdate
		'
		Me.btnUpdate.Location = New System.Drawing.Point(360, 32)
		Me.btnUpdate.Name = "btnUpdate"
		Me.btnUpdate.Size = New System.Drawing.Size(56, 23)
		Me.btnUpdate.TabIndex = 2
		Me.btnUpdate.Text = "Update"
		'
		'btnDelete
		'
		Me.btnDelete.Location = New System.Drawing.Point(424, 32)
		Me.btnDelete.Name = "btnDelete"
		Me.btnDelete.Size = New System.Drawing.Size(56, 23)
		Me.btnDelete.TabIndex = 3
		Me.btnDelete.Text = "Delete"
		'
		'lblEdit
		'
		Me.lblEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEdit.Location = New System.Drawing.Point(8, 8)
		Me.lblEdit.Name = "lblEdit"
		Me.lblEdit.Size = New System.Drawing.Size(32, 16)
		Me.lblEdit.TabIndex = 6
		Me.lblEdit.Text = "Edit"
		'
		'lblNew
		'
		Me.lblNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNew.Location = New System.Drawing.Point(8, 72)
		Me.lblNew.Name = "lblNew"
		Me.lblNew.Size = New System.Drawing.Size(32, 16)
		Me.lblNew.TabIndex = 7
		Me.lblNew.Text = "New"
		'
		'lblNewKey
		'
		Me.lblNewKey.Location = New System.Drawing.Point(8, 96)
		Me.lblNewKey.Name = "lblNewKey"
		Me.lblNewKey.Size = New System.Drawing.Size(32, 21)
		Me.lblNewKey.TabIndex = 8
		Me.lblNewKey.Text = "Keys:"
		Me.lblNewKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'txtNewKey
		'
		Me.txtNewKey.Location = New System.Drawing.Point(40, 96)
		Me.txtNewKey.Name = "txtNewKey"
		Me.txtNewKey.Size = New System.Drawing.Size(136, 20)
		Me.txtNewKey.TabIndex = 4
		Me.txtNewKey.Text = ""
		'
		'txtNewValue
		'
		Me.txtNewValue.Location = New System.Drawing.Point(216, 96)
		Me.txtNewValue.Name = "txtNewValue"
		Me.txtNewValue.Size = New System.Drawing.Size(136, 20)
		Me.txtNewValue.TabIndex = 5
		Me.txtNewValue.Text = ""
		'
		'lblNewValue
		'
		Me.lblNewValue.Location = New System.Drawing.Point(176, 96)
		Me.lblNewValue.Name = "lblNewValue"
		Me.lblNewValue.Size = New System.Drawing.Size(40, 21)
		Me.lblNewValue.TabIndex = 10
		Me.lblNewValue.Text = "Value:"
		Me.lblNewValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'btnAdd
		'
		Me.btnAdd.Location = New System.Drawing.Point(360, 96)
		Me.btnAdd.Name = "btnAdd"
		Me.btnAdd.Size = New System.Drawing.Size(40, 23)
		Me.btnAdd.TabIndex = 6
		Me.btnAdd.Text = "Add"
		'
		'btnSave
		'
		Me.btnSave.Location = New System.Drawing.Point(408, 96)
		Me.btnSave.Name = "btnSave"
		Me.btnSave.TabIndex = 7
		Me.btnSave.Text = "Save to File"
		'
		'lblCreatedBy
		'
		Me.lblCreatedBy.ForeColor = System.Drawing.Color.Gray
		Me.lblCreatedBy.Location = New System.Drawing.Point(264, 8)
		Me.lblCreatedBy.Name = "lblCreatedBy"
		Me.lblCreatedBy.Size = New System.Drawing.Size(224, 16)
		Me.lblCreatedBy.TabIndex = 11
		Me.lblCreatedBy.Text = "Developed by Erik Porter of ErikPorter.com"
		Me.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'Main
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(488, 128)
		Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCreatedBy, Me.btnSave, Me.btnAdd, Me.txtNewValue, Me.lblNewValue, Me.txtNewKey, Me.lblNewKey, Me.lblNew, Me.lblEdit, Me.btnDelete, Me.btnUpdate, Me.lblValue, Me.txtValue, Me.lblKeys, Me.cmbKeys})
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
		Me.MaximizeBox = False
		Me.Name = "Main"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ConfigEditor Test Application"
		Me.ResumeLayout(False)

	End Sub

#End Region

	Private Const FileToOpen As String = "App.config"
	Private ConfigEdit As ConfigEditor.ConfigEditor

	Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Try
			ConfigEdit = New ConfigEditor.ConfigEditor(Application.StartupPath & "\" & FileToOpen)
			'ConfigEdit.AllowDuplicateKeys = True
			btnUpdate.Enabled = False
			btnAdd.Enabled = False
			cmbKeys.DataSource = ConfigEdit
		Catch err As Exception
			ShowError(err.Message)
			Exit Sub
		End Try
	End Sub

	Private Sub cmbKeys_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKeys.SelectedIndexChanged
		txtValue.Text = ConfigEdit.Item(CType(cmbKeys.SelectedItem, ConfigEditor.ConfigItem)).Value
		btnUpdate.Enabled = False
	End Sub

	Private Sub txtValue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValue.TextChanged
		btnUpdate.Enabled = txtValue.Text.Trim <> ""
	End Sub

	Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
		Try
			ConfigEdit.Item(CType(cmbKeys.SelectedItem, ConfigEditor.ConfigItem)).Value = txtValue.Text
			btnUpdate.Enabled = False
		Catch err As Exception
			ShowError(err.Message)
		End Try
	End Sub

	Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
		If MessageBox.Show("Are you sure you want to delete node '" & cmbKeys.Text & "'?", "ConfigEditor Test Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
			Try
				ConfigEdit.Remove(CType(cmbKeys.SelectedItem, ConfigEditor.ConfigItem))
				cmbKeys.BindingContext = New BindingContext()
				If ConfigEdit.Count = 0 Then
					txtValue.Text = ""
				End If
			Catch err As Exception
				ShowError(err.Message)
			End Try
		End If
	End Sub

	Private Sub txtNew_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNewKey.TextChanged, txtNewValue.TextChanged
		btnAdd.Enabled = txtNewKey.Text <> "" And txtNewValue.Text <> ""
	End Sub

	Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
		Try
			Dim Temp As ConfigEditor.ConfigItem = ConfigEdit.Add(txtNewKey.Text, txtNewValue.Text)
			txtNewKey.Text = ""
			txtNewValue.Text = ""
			cmbKeys.BindingContext = New BindingContext()
			cmbKeys.SelectedItem = Temp
			txtNewKey.Focus()
		Catch err As Exception
			ShowError(err.Message)
		End Try
	End Sub

	Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
		ConfigEdit.Save()
	End Sub

	Private Sub ShowError(ByVal Message As String)
		MessageBox.Show(Message, "ConfigEditor Test Application - Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
	End Sub
End Class