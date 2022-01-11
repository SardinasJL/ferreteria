Public Class frmVentasNuevoEditar
    Dim id As Integer
    Public Sub New(Optional ByVal _id As Integer = 0)
        ' Llamada necesaria para el diseñador.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        id = _id
    End Sub
    Public Sub cargarClientes(ByVal nit As String, ByVal nombre As String)
        Dim sql As String = "SELECT id as id_cliente, nit, nombre FROM clientes WHERE nit LIKE '%" & nit & "%' AND nombre LIKE '%" & nombre & "%'"
        Dim obj As New crud
        obj.consulta(DataGridView1, sql)
    End Sub
    Public Sub cargarVenta()
        If id <> 0 Then
            Dim sql As String
            Dim obj As New crud
            sql = "SELECT clientes.id as id_cliente, clientes.nit as nit, clientes.nombre as nombre FROM ventas INNER JOIN clientes ON ventas.id_cliente = clientes.id WHERE ventas.id=" & id
            Dim venta As DataTable = obj.datos(Sql)
            txtNit.Text = venta.Rows(0)("nit")
            txtNombre.Text = venta.Rows(0)("nombre")
            obj.consulta(DataGridView1, Sql)
        End If
    End Sub
    Private Sub frmVentasNuevoEditar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarVenta()
    End Sub
    Private Sub txtNit_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNit.KeyUp
        cargarClientes(txtNit.Text, txtNombre.Text)
    End Sub
    Private Sub txtNombre_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyUp
        cargarClientes(txtNit.Text, txtNombre.Text)
    End Sub
    Public Sub upsert()
        Dim sql As String
        Dim obj As New crud
        Dim id_cliente As Integer = DataGridView1.CurrentRow.Cells("id_cliente").Value
        If id_cliente > 0 Then
            If id = 0 Then 'si el id de la venta es cero, se hace un insert, caso contrario, se hace un update
                sql = "INSERT INTO ventas (id_cliente, fecha) VALUES ('" & id_cliente & "', #" & Date.Now.ToString("d/M/yyyy") & "#)"
            Else
                sql = "UPDATE ventas SET id_cliente='" & id_cliente & "' WHERE id=" & id
            End If
            If obj.operaciones(sql) = True Then
                Close()
            End If
        Else
            MsgBox("Debe seleccionar un cliente")
        End If
    End Sub
    Private Sub btnNuevoCliente_Click(sender As Object, e As EventArgs) Handles btnNuevoCliente.Click
        Dim frmClientesNuevoEditar As New frmClientesNuevoEditar
        frmClientesNuevoEditar.ShowDialog()
        cargarClientes(txtNit.Text, txtNombre.Text)
    End Sub
    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        upsert()
    End Sub
    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Close()
    End Sub
End Class