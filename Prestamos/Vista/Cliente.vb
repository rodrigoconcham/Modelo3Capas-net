Public Class Cliente

    Private cli As Datos.Clientes
    Private Shared clientec As Cliente = Nothing





    Private Sub Cliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cli = Datos.Clientes.Instanciar
        Me.BindingNavigator1.BindingSource = cli._biding





    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub TbDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TbDireccion.TextChanged

    End Sub
End Class