Namespace Datos


    Public Class Clientes


        Private cdt As PrestamosDataSet.ClienteDataTable
        Private cta As PrestamosDataSetTableAdapters.ClienteTableAdapter
        Private binding As BindingSource
        Private Shared cli As Clientes = Nothing

        Public Sub New()

            cdt = New PrestamosDataSet.ClienteDataTable
            cta = New PrestamosDataSetTableAdapters.ClienteTableAdapter
            cta.Fill(cdt)
            binding = New BindingSource
            binding.DataSource = cdt






        End Sub


        Public Shared Function Instanciar() As Clientes

            If IsNothing(cli) Then
                cli = New Clientes


            End If
            Return cli

        End Function


        Public ReadOnly Property _biding As BindingSource
            Get
                Return binding
            End Get
        End Property


        Public Sub insertar(nombre As String, apellido As String, direccion As String, telefono As Integer, celular As Integer, Cedula As String)


            Try

                binding.Current("Cedula") = Cedula
                binding.Current("Nombre") = nombre
                binding.Current("Apellido") = apellido
                binding.Current("Direccion") = direccion
                binding.Current("Telefono") = telefono
                binding.Current("Celular") = celular

                binding.EndEdit()
                Dim posicion

                cta.Update(cdt)
                posicion = Binding.Position
                Me.cta.Fill(cdt)
                binding.Position = posicion

                MsgBox("Se guardo exitosamente el cliente ", MsgBoxStyle.Information, "Prestamos")




            Catch ex As Exception

                MsgBox("Se guardo exitosamente el cliente ", MsgBoxStyle.Critical, "Prestamos")
            End Try




        End Sub


        Public Sub eliminar()

            Try
                Dim posicion

                If MsgBox("En realidad desea usted eliminar al cliente?", MsgBoxStyle.YesNo) = vbYes Then
                    binding.RemoveCurrent()
                    binding.EndEdit()
                    cta.Update(cdt)
                    posicion = binding.Position
                    Me.cta.Fill(cdt)
                    binding.Position = posicion



                End If
                


            Catch ex As Exception

                MsgBox("Se ha producido un error : Usted esta tratando de eliminar registros que estan siendo utilizados en otras tablas ", MsgBoxStyle.Critical, "Prestamos")
                Dim posicion = binding.Position
                Me.cta.Fill(cdt)
                binding.Position = posicion



            End Try






        End Sub




    End Class


    
    Public Class CuentasPrestamos


        Private cdt As PrestamosDataSet.Cuenta_PrestamosDataTable
        Private cta As PrestamosDataSetTableAdapters.Cuenta_PrestamosTableAdapter
        Private binding As BindingSource
        Private Shared cli As Clientes = Nothing

        Public Sub New()

            cdt = New PrestamosDataSet.Cuenta_PrestamosDataTable
            cta = New PrestamosDataSetTableAdapters.Cuenta_PrestamosTableAdapter
            cta.Fill(cdt)
            binding = New BindingSource
            binding.DataSource = cdt






        End Sub


        Public Shared Function Instanciar() As Clientes

            If IsNothing(cli) Then
                cli = New Clientes


            End If
            Return cli

        End Function


        Public ReadOnly Property _biding As BindingSource
            Get
                Return binding
            End Get
        End Property


        Public Sub insertar(nombre As String, apellido As String, direccion As String, telefono As Integer, celular As Integer, Cedula As String)


            Try

                binding.Current("Cedula") = Cedula
                binding.Current("Nombre") = nombre
                binding.Current("Apellido") = apellido
                binding.Current("Direccion") = direccion
                binding.Current("Telefono") = telefono
                binding.Current("Celular") = celular

                binding.EndEdit()
                Dim posicion

                cta.Update(cdt)
                posicion = Binding.Position
                Me.cta.Fill(cdt)
                binding.Position = posicion

                MsgBox("Se guardo exitosamente el cliente ", MsgBoxStyle.Information, "Prestamos")




            Catch ex As Exception

                MsgBox("Se guardo exitosamente el cliente ", MsgBoxStyle.Critical, "Prestamos")
            End Try




        End Sub


        Public Sub eliminar()

            Try
                Dim posicion

                If MsgBox("En realidad desea usted eliminar al cliente?", MsgBoxStyle.YesNo) = vbYes Then
                    binding.RemoveCurrent()
                    binding.EndEdit()
                    cta.Update(cdt)
                    posicion = binding.Position
                    Me.cta.Fill(cdt)
                    binding.Position = posicion



                End If



            Catch ex As Exception

                MsgBox("Se ha producido un error : Usted esta tratando de eliminar registros que estan siendo utilizados en otras tablas ", MsgBoxStyle.Critical, "Prestamos")
                Dim posicion = binding.Position
                Me.cta.Fill(cdt)
                binding.Position = posicion



            End Try






        End Sub




    End Class



End Namespace
