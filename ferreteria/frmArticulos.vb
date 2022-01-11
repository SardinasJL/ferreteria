Public Class frmArticulos
    Public Sub cargarDatos(Optional ByVal descripcion As String = "")
        Dim sql As String = "select * from articulos where descripcion like '%" & descripcion & "%'"
        Dim crud As New crud
        crud.consulta(DataGridView1, sql)
    End Sub
    Private Sub frmArticulos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos(txtDescripcion.Text)
    End Sub
    Private Sub txtDescripcion_KeyUp(sender As Object, e As KeyEventArgs) Handles txtDescripcion.KeyUp
        cargarDatos(txtDescripcion.Text)
    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim frmArticulosNuevoEditar As New frmArticulosNuevoEditar
        frmArticulosNuevoEditar.ShowDialog()
        cargarDatos(txtDescripcion.Text)
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub

    Private Sub btnEditar_Click(sender As Object, e As EventArgs) Handles btnEditar.Click
        Dim indiceDeLaFilaActual As Integer = DataGridView1.CurrentRow.Index
        Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
        Dim frmArticulosNuevoEditar As New frmArticulosNuevoEditar(id)
        frmArticulosNuevoEditar.ShowDialog()
        cargarDatos(txtDescripcion.Text)
        _moverScrollAFila(DataGridView1, indiceDeLaFilaActual)
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Dim borrar As DialogResult
        borrar = MessageBox.Show("¿Desea eliminar el registro seleccionado?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
        If (borrar = DialogResult.Yes) Then
            Dim id As Integer = DataGridView1.CurrentRow.Cells("id").Value
            Dim sql As String = "DELETE FROM articulos WHERE id=" & id
            Dim obj As New crud
            If obj.operaciones(sql) = True Then
                cargarDatos(txtDescripcion.Text)
            End If
        End If
    End Sub
End Class