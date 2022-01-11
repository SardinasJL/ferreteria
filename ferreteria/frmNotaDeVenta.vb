Imports Microsoft.Reporting.WinForms
Imports System.Data.OleDb
Public Class frmNotaDeVenta
    Dim id_venta As Integer
    Sub New(ByVal _id As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id_venta = _id
    End Sub
    Private Sub frmNotaDeVenta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql As String = "SELECT id_venta, fecha, descripcion, unidad, ventas_detalle.cantidad AS cantidad, precio, (cantidad*precio) AS subtotal, nit, nombre FROM ((ventas INNER JOIN ventas_detalle ON ventas_detalle.id_venta = ventas.id) INNER JOIN articulos ON ventas_detalle.id_articulo = articulos.id) INNER JOIN clientes ON ventas.id_cliente = clientes.id WHERE ventas.id = " & id_venta
        Dim con As New OleDbConnection(_cadena_de_conexion)
        Dim DA As New OleDbDataAdapter(sql, con)
        Dim info As New datasetNotaDeVenta
        DA.Fill(info, "dataNotaDeVenta")

        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.Visible = True
        ReportViewer1.SetDisplayMode(DisplayMode.Normal)

        Dim rds As New ReportDataSource("datasetNotaDeVenta", info.Tables(0))
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(rds)
        ReportViewer1.RefreshReport()
    End Sub
End Class