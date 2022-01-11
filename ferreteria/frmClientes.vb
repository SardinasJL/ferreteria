Public Class frmClientes

    Public Sub cargarDatos(Optional ByVal nit As String = "", Optional ByVal nombre As String = "")
        Dim sql As String = "select * from clientes where nit like '%" & nit & "%' and nombre like '%" & nombre & "%'"
        Dim obj As New crud
        obj.consulta(DataGridView1, sql)
    End Sub

    Private Sub frmClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub

    Private Sub txtNit_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNit.KeyUp
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub

    Private Sub txtNombre_KeyUp(sender As Object, e As KeyEventArgs) Handles txtNombre.KeyUp
        cargarDatos(txtNit.Text, txtNombre.Text)
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim frmClientesNuevo As New frmClientesNuevoEditar()
        frmClientesNuevo.ShowDialog()
        cargarDatos(txtNit.Text, txtNombre.Text)
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
        Dim frmClientesEditar As New frmClientesNuevoEditar(id)
        frmClientesEditar.ShowDialog()
        cargarDatos(txtNit.Text, txtNombre.Text)
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim Borrar As DialogResult
        Borrar = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If (Borrar = DialogResult.Yes) Then
            Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
            Dim sql As String = "DELETE FROM clientes WHERE id=" & id
            Dim obj As New crud
            obj.operaciones(sql)
            cargarDatos(txtNit.Text, txtNombre.Text)
        End If
    End Sub
End Class