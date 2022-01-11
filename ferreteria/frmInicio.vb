Public Class frmInicio
    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        If IsNothing(Application.OpenForms("frmClientes")) Then
            Dim frmClien As New frmClientes
            frmClien.MdiParent = Me
            frmClien.Show()
        Else
            Application.OpenForms("frmClientes").Activate()
        End If
    End Sub

    Private Sub ArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ArtículosToolStripMenuItem.Click
        If IsNothing(Application.OpenForms("frmArticulos")) Then
            Dim frmArticulos As New frmArticulos
            frmArticulos.MdiParent = Me
            frmArticulos.Show()
        Else
            Application.OpenForms("frmArticulos").Activate()
        End If
    End Sub

    Private Sub VentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentasToolStripMenuItem.Click
        If IsNothing(Application.OpenForms("frmVentas")) Then
            Dim frmVentas As New frmVentas
            frmVentas.MdiParent = Me
            frmVentas.Show()
        Else
            Application.OpenForms("frmVentas").Activate()
        End If
    End Sub
End Class
