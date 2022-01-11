Public Class frmVentasDetalle
    Dim id As Integer
    Sub New(ByVal _id As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id = _id
    End Sub
    Public Sub cargarDetalle()
        Dim sql As String = "SELECT ventas_detalle.id, ventas_detalle.id_articulo, articulos.descripcion, ventas_detalle.cantidad, articulos.precio, ventas_detalle.cantidad*articulos.precio AS subtotal FROM ventas_detalle INNER JOIN articulos ON ventas_detalle.id_articulo = articulos.id WHERE ventas_detalle.id_venta=" & id
        Dim obj As New crud
        obj.consulta(DataGridView1, sql)
        Dim sqlGetTotal As String = "SELECT sum(ventas_detalle.cantidad*articulos.precio) FROM ventas_detalle INNER JOIN articulos ON ventas_detalle.id_articulo = articulos.id GROUP BY ventas_detalle.id_venta HAVING ventas_detalle.id_venta=" & id
        Dim total As DataTable = obj.datos(sqlGetTotal)
        txtTotal.Text = total.Rows(0)(0)
    End Sub

    Private Sub frmVentasDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDetalle()
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim frmVentasDetalleNuevo As New frmVentasDetalleNuevo(id)
        frmVentasDetalleNuevo.ShowDialog()
        cargarDetalle()
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
        Dim sql As String = "DELETE FROM ventas_detalle WHERE id=" & id
        Dim obj As New crud
        If obj.operaciones(sql) = True Then
            cargarDetalle()
        End If
    End Sub
    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Close()
    End Sub
End Class