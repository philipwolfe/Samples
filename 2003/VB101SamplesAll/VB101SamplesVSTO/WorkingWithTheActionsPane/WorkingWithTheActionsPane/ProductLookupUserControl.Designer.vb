<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ProductLookupUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.insertProductInfoButton = New System.Windows.Forms.Button
        Me.productsListBox = New System.Windows.Forms.ListBox
        Me.productBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.adventureWorks_DataDataSet = New WorkingWithTheActionsPane.AdventureWorks_DataDataSet
        Me.productTableAdapter = New WorkingWithTheActionsPane.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter
        Me.label1 = New System.Windows.Forms.Label
        CType(Me.productBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'insertProductInfoButton
        '
        Me.insertProductInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.insertProductInfoButton.Location = New System.Drawing.Point(46, 166)
        Me.insertProductInfoButton.Name = "insertProductInfoButton"
        Me.insertProductInfoButton.Size = New System.Drawing.Size(116, 23)
        Me.insertProductInfoButton.TabIndex = 5
        Me.insertProductInfoButton.Text = "Insert Product Info"
        Me.insertProductInfoButton.UseVisualStyleBackColor = True
        '
        'productsListBox
        '
        Me.productsListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.productsListBox.DataSource = Me.productBindingSource
        Me.productsListBox.DisplayMember = "Name"
        Me.productsListBox.FormattingEnabled = True
        Me.productsListBox.Location = New System.Drawing.Point(3, 22)
        Me.productsListBox.Name = "productsListBox"
        Me.productsListBox.Size = New System.Drawing.Size(202, 134)
        Me.productsListBox.TabIndex = 4
        '
        'productBindingSource
        '
        Me.productBindingSource.DataMember = "Product"
        Me.productBindingSource.DataSource = Me.adventureWorks_DataDataSet
        '
        'adventureWorks_DataDataSet
        '
        Me.adventureWorks_DataDataSet.DataSetName = "AdventureWorks_DataDataSet"
        Me.adventureWorks_DataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'productTableAdapter
        '
        Me.productTableAdapter.ClearBeforeFill = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(3, 5)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(123, 13)
        Me.label1.TabIndex = 3
        Me.label1.Text = "Product Info Lookup"
        '
        'ProductLookupUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.insertProductInfoButton)
        Me.Controls.Add(Me.productsListBox)
        Me.Controls.Add(Me.label1)
        Me.Name = "ProductLookupUserControl"
        Me.Size = New System.Drawing.Size(209, 195)
        CType(Me.productBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.adventureWorks_DataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents insertProductInfoButton As System.Windows.Forms.Button
    Private WithEvents productsListBox As System.Windows.Forms.ListBox
    Private WithEvents productBindingSource As System.Windows.Forms.BindingSource
    Public WithEvents adventureWorks_DataDataSet As WorkingWithTheActionsPane.AdventureWorks_DataDataSet
    Private WithEvents productTableAdapter As WorkingWithTheActionsPane.AdventureWorks_DataDataSetTableAdapters.ProductTableAdapter
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
