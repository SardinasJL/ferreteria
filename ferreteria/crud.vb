Imports System.Data.OleDb

Public Class crud

    Dim con As New OleDbConnection(_cadena_de_conexion)
    Sub conexion()
        ':::Instruccion Try para capturar errores
        Try
            ':::Abrimos nuestro conexion con la propiedad Open
            con.Open()
            MsgBox("Conexión realizada de manera exitosa", MsgBoxStyle.Information, "Módulo CRUD")
            ':::Y cerramos la conexion
            con.Close()
        Catch ex As Exception
            MsgBox("No se logro realizar la conexión debido: " & ex.Message, MsgBoxStyle.Critical, "Módulo CRUD")
        End Try
    End Sub

    ':::Procedimiento para realizar consulta SELECT
    ':::2 parámetros para ejecutarse correctamente (Tabla, Sql)
    Sub consulta(ByVal Tabla As DataGridView, ByVal Sql As String)
        ':::Instruccion Try para capturar errores
        Try
            'Esperamos algunos milisegundos antes de leer la BD de Access, para evitar errores de lectura/escritura en PCs muy lentas
            System.Threading.Thread.Sleep(100)
            ':::Creamos el objeto DataAdapter y le pasamos los dos parametros (Instruccion, conexión)
            Dim DA As New OleDbDataAdapter(Sql, con)
            ':::Creamos el objeto DataTable que recibe la informacion del DataAdapter
            Dim DT As New DataTable
            ':::Pasamos la informacion del DataAdapter al DataTable mediante la propiedad Fill
            DA.Fill(DT)
            ':::Ahora mostramos los datos en el DataGridView
            Tabla.DataSource = DT
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical, "Módulo CRUD")
        End Try
    End Sub
    ':::Procedimiento para realizar una consulta SELECT sin grilla
    ':::1 parámetro para ejecutarse correctamente (Sql)
    '::: Salida: los datos de la consulta dentro de un datatable, false si la consulta no se ejecuta
    Function datos(ByVal Sql As String)
        Try
            'Esperamos algunos milisegundos antes de leer la BD de Access, para evitar errores de lectura/escritura en PCs muy lentas
            System.Threading.Thread.Sleep(100)
            Dim DA As New OleDbDataAdapter(Sql, con)
            Dim DT As New DataTable
            DA.Fill(DT)
            datos = DT
            Return datos
            'Para recuperar los datos en el destino, utilizar una instancia de un datatable y hacer nombredatatable.Rows(0)(índice o nombre de la columna)
        Catch ex As Exception
            MsgBox("No se logro realizar la consulta por: " & ex.Message, MsgBoxStyle.Critical, "Módulo CRUD")
            Return False
        End Try
    End Function

    ':::Procedimiento para Agregar, Actualizar y Eliminar un registro
    ':::1 parametro para ejecutarse correctamente (Sql)
    '::: Salida: True si la consulta se ejecuta correctamente, caso contrario False
    Function operaciones(ByVal Sql As String)
        ':::Abrimos la conexion
        con.Open()
        ':::Instruccion Try para capturar errores
        Try
            ':::Creamos nuestro objeto de tipo Command que almacenara nuestras instrucciones
            ':::Necesita 2 parametros (Instruccion, conexion)
            Dim cmd As New OleDbCommand(Sql, con)
            ':::Ejecutamos la instruccion mediante la propiedad ExecuteNonQuery del command
            cmd.ExecuteNonQuery()
            ':::Se crea un retraso de unos cuantos milisegundos para que no haya colisión en los querys (sólo usar en Access)
            System.Threading.Thread.Sleep(500)
            ':::Si la función se ejecutó correctamente, se retorna TRUE
            Return True
        Catch ex As Exception
            MsgBox("No se logro realizar la operación por: " & ex.Message, MsgBoxStyle.Critical, "Módulo CRUD")
            MsgBox(Sql)
            Return False
        End Try
        ':::Cerramos la conexion
        con.Close()
    End Function
End Class
