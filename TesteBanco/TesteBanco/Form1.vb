Imports System.Data
Imports System.Data.SqlClient

Public Class Form1

    Private Sub ListarTipos()
        Try
            Dim cn As New SqlConnection

            cn.ConnectionString = "Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Neto\Documents\Visual Studio 2013\Projects\TesteBanco\TesteBanco\Base.mdf;Integrated Security=True"

            'Abrindo conexão
            cn.Open()

            Dim ds As New DataSet
            Dim query As String = ""

            query &= "Select idTipo, Nome From TipoProdutos Order by Nome"

            Dim da As New SqlDataAdapter(query, cn)

            da.Fill(ds, "Tipos")

            DataGridView1.DataSource = ds.Tables("Tipos")

            'Fechando conexão
            cn.Close()

        Catch ex As Exception
            MessageBox.Show("Ocorreu um erro: " + ex.Message)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListarTipos()
    End Sub
End Class

