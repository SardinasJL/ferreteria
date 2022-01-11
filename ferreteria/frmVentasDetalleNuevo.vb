Imports System.Text.RegularExpressions
Public Class frmVentasDetalleNuevo
    Dim id_venta As Integer
    Sub New(ByVal _id As Integer)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id_venta = _id
    End Sub
    Public Sub cargarArticulos(ByVal descripcion As String)
        Dim sql As String = "SELECT * FROM articulos WHERE descripcion LIKE '%" & descripcion & "%'"
        Dim obj As New crud
        obj.consulta(DataGridView1, sql)
    End Sub

    Public Sub insert()
        Dim id_articulo As Integer = DataGridView1.CurrentRow.Cells("id").Value
        Dim cantidad As Integer = txtCantidad.Text
        Dim sql As String = "INSERT INTO ventas_detalle(id_venta, id_articulo, cantidad) VALUES ('" & id_venta & "', '" & id_articulo & "', '" & cantidad & "')"
        Dim obj As New crud
        If obj.operaciones(sql) = True Then
            Close()
        End If
    End Sub
    Private Sub frmVentasDetalleNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarArticulos(txtDescripcion.Text)
    End Sub

    Private Sub txtDescripcion_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyUp
        cargarArticulos(txtDescripcion.Text)
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        If Regex.IsMatch(txtCantidad.Text, "^[0-9]{1,5}$") = False Then
            MsgBox("El campo Cantidad es inválido")
            txtCantidad.Focus()
            Exit Sub
        End If
        insert()
    End Sub
End Class