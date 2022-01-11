Imports System.Text.RegularExpressions 'Esta librería se importa para validar los datos
Public Class frmClientesNuevoEditar
    Dim id As Integer
    Public Sub New(Optional ByVal _id As Integer = 0)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id = _id
    End Sub
    Public Sub cargarDatos()
        If id <> 0 Then
            Dim sql As String = "select * from clientes where id=" & id
            Dim obj As New crud
            Dim cliente As DataTable = obj.datos(sql)
            txtNit.Text = cliente.Rows(0)("nit")
            txtNombre.Text = cliente.Rows(0)("nombre")
        End If
    End Sub
    Private Sub frmClientesNuevo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
    End Sub
    Public Sub upsert()
        Dim nit As String = txtNit.Text
        Dim nombre As String = txtNombre.Text
        Dim sql As String
        Dim obj As New crud
        If id = 0 Then 'Si el id=0 se hace un insert, caso contrario se hace un update
            sql = "insert into clientes(nit, nombre) values(" & nit & ", '" & nombre & "')"
        Else
            sql = "update clientes set nit='" & nit & "', nombre='" & nombre & "' where id=" & id
        End If
        If obj.operaciones(sql) = True Then
            Close()
        End If
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Regex.IsMatch(txtNit.Text, "^[0-9]{5,10}$") = False Then
            MsgBox("El campo NIT no es válido")
            txtNit.Focus()
            Exit Sub
        End If
        If Regex.IsMatch(txtNombre.Text, "^[a-zA-ZáéíóúÁÉÍÓÚëï ]{3,40}$") = False Then
            MsgBox("El campo Nombre no es válido")
            txtNombre.Focus()
            Exit Sub
        End If
        upsert()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class