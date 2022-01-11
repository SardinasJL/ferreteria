Public Class frmVentas
    Public Sub cargarDatos(Optional ByVal nit As String = "", Optional ByVal nombre As String = "")
        Dim inicio As String = txtInicio.Text
        Dim fin As String = txtFin.Text
        'Las campos de las fechas deben ir entre # para ser reconocidos por Access
        Dim sql As String = "SELECT ventas.id, clientes.nit, clientes.nombre, ventas.fecha FROM ventas INNER JOIN clientes ON ventas.id_cliente = clientes.id WHERE clientes.nit LIKE '%" & nit & "%' AND ventas.fecha >= #" & inicio & "# AND ventas.fecha <= #" & fin & "#"
        Dim obj As New crud
        obj.consulta(DataGridView1, sql)
    End Sub
    Private Sub frmVentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim fin As Date = Date.Now.ToString("d/M/yyyy")
        Dim inicio As Date = fin.AddDays(-15).ToString("d/M/yyyy")
        txtFin.Text = fin
        txtInicio.Text = inicio
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub
    Private Sub txtNit_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNit.KeyUp
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub
    Private Sub txtNombre_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyUp
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub
    Private Sub txtInicio_ValueChanged(sender As Object, e As EventArgs) Handles txtInicio.ValueChanged
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub
    Private Sub txtFin_ValueChanged(sender As Object, e As EventArgs) Handles txtFin.ValueChanged
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim frmVentasNuevoEditar As New frmVentasNuevoEditar
        frmVentasNuevoEditar.ShowDialog()
        cargarDatos(txtNit.Text, txtNombre.Text)
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub
    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
        Dim frmVentasNuevoEditar As New frmVentasNuevoEditar(id)
        frmVentasNuevoEditar.ShowDialog()
        cargarDatos(txtNit.Text, txtNombre.Text)
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub
    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
        Dim frmVentasDetalle As New frmVentasDetalle(id)
        frmVentasDetalle.ShowDialog()
        cargarDatos(txtNit.Text, txtNombre.Text)
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub
    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Borrar As DialogResult
        Borrar = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If (Borrar = DialogResult.Yes) Then
            Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
            Dim sql As String = "DELETE FROM ventas WHERE id = " & id
            Dim obj As New crud
            If obj.operaciones(sql) Then
                cargarDatos(txtNit.Text, txtNombre.Text)
            End If
        End If
    End Sub
    Private Sub btnNotaDeVenta_Click(sender As Object, e As EventArgs) Handles btnNotaDeVenta.Click
        Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
        Dim frmNotaDeVenta As New frmNotaDeVenta(id)
        frmNotaDeVenta.ShowDialog()
    End Sub
End Class