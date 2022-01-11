<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotaDeVenta
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.datasetNotaDeVenta = New ferreteria.datasetNotaDeVenta()
        Me.dataNotaDeVentaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.datasetNotaDeVenta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataNotaDeVentaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "datasetNotaDeVenta"
        ReportDataSource1.Value = Me.dataNotaDeVentaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "ferreteria.notaDeVenta.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 12)
        Me.ReportViewer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(813, 436)
        Me.ReportViewer1.TabIndex = 0
        '
        'datasetNotaDeVenta
        '
        Me.datasetNotaDeVenta.DataSetName = "datasetNotaDeVenta"
        Me.datasetNotaDeVenta.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'dataNotaDeVentaBindingSource
        '
        Me.dataNotaDeVentaBindingSource.DataMember = "dataNotaDeVenta"
        Me.dataNotaDeVentaBindingSource.DataSource = Me.datasetNotaDeVenta
        '
        'frmNotaDeVenta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 460)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "frmNotaDeVenta"
        Me.Text = "frmNotaDeVenta"
        CType(Me.datasetNotaDeVenta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataNotaDeVentaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents dataNotaDeVentaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents datasetNotaDeVenta As ferreteria.datasetNotaDeVenta
End Class
