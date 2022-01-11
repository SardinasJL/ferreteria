Module variablesGlobales
    'Se debe proporcionar la ruta del archivo Access, por ejemplo: D:\stories.mdb
    'A menos que el archivo de Access se encuentra en la misma carpeta que el ejecutable, en ese caso solo hace falta escribir: stories.mdb
    Public _cadena_de_conexion As String = "Provider=Microsoft.Jet.OleDb.4.0; Data Source=ferreteria.mdb"
    'Pequeña función para mover el escroll de un datagridview
    Sub _moverScrollAFila(DataGridView As DataGridView, fila As Integer)
        'Se mueve el cursor y el scroll vertical a la fila recién insertada
        DataGridView.Rows(fila).Selected = True
        DataGridView.CurrentCell = DataGridView.Rows(fila).Cells(0)
        DataGridView.FirstDisplayedScrollingRowIndex = fila
    End Sub
  
End Module
