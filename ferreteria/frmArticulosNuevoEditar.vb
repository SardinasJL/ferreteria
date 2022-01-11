Imports System.Text.RegularExpressions
Public Class frmArticulosNuevoEditar
    Dim id As Integer
    Public Sub New(Optional ByVal _id As Integer = 0)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id = _id
    End Sub
    Public Sub cargarDatos()
        If id <> 0 Then
            Dim sql As String = "SELECT * FROM articulos WHERE id=" & id
            Dim obj As New crud
            Dim articulo As DataTable = obj.datos(sql)
            txtCantidad.Text = articulo.Rows(0)("cantidad")
            txtDescripcion.Text = articulo.Rows(0)("descripcion")
            txtPrecio.Text = articulo.Rows(0)("precio")
            txtUnidad.Text = articulo.Rows(0)("unidad")
        End If
    End Sub
    Private Sub frmArticulosNuevoEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Private Sub upsert()
        Dim cantidad As String = txtCantidad.Text
        Dim descripcion As String = txtDescripcion.Text
        Dim precio As String = txtPrecio.Text
        Dim unidad As String = txtUnidad.Text
        Dim sql As String
        Dim obj As New crud
        If id <> 0 Then
            sql = "UPDATE articulos SET cantidad='" & cantidad & "', descripcion='" & descripcion & "', precio='" & precio & "', unidad='" & unidad & "' WHERE id=" & id
        Else
            sql = "INSERT INTO articulos(cantidad, descripcion, precio, unidad) VALUES ('" & cantidad & "', '" & descripcion & "', '" & precio & "', '" & unidad & "')"
        End If
        If obj.operaciones(sql) = True Then
            Close()
        End If
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        'Se realizan las validaciones
        If Regex.IsMatch(txtCantidad.Text, "^[0-9]{1,3}$") = False Then
            MsgBox("El campo Cantidad es inválido")
            txtCantidad.Focus()
            Exit Sub
        End If
        If Regex.IsMatch(txtDescripcion.Text, "^[a-zA-Z0-9áéíóúÁÉÍÓÚ=\.' ]{3,40}$") = False Then
            MsgBox("El campo Descripcion es inválido")
            txtDescripcion.Focus()
            Exit Sub
        End If
        If Regex.IsMatch(txtPrecio.Text, "^[0-9]{1,10}\,{0,1}[0-9]{0,2}$") = False Then
            MsgBox("El campo Precio es inválido")
            txtPrecio.Focus()
            Exit Sub
        End If
        If Regex.IsMatch(txtUnidad.Text, "^[a-zA-ZáéíóúÁÉÍÓÚ.]{1,10}$") = False Then
            MsgBox("El campo Unidad es inválido")
            txtUnidad.Focus()
            Exit Sub
        End If
        upsert()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
   
End Class