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


        Private cpdt As PrestamosDataSet.Cuenta_PrestamosDataTable
        Private cpta As PrestamosDataSetTableAdapters.Cuenta_PrestamosTableAdapter
        Private binding As BindingSource
        Private Shared cp As CuentasPrestamos = Nothing

        Public Sub New()

            cpdt = New PrestamosDataSet.Cuenta_PrestamosDataTable
            cpta = New PrestamosDataSetTableAdapters.Cuenta_PrestamosTableAdapter
            cpta.Fill(cpdt)
            binding = New BindingSource
            binding.DataSource = cpdt

        End Sub


        Public Shared Function Instanciar() As CuentasPrestamos


            If IsNothing(cp) Then
                cp = New CuentasPrestamos



            End If
            Return cp

        End Function


        Public ReadOnly Property _biding As BindingSource
            Get
                Return binding
            End Get
        End Property


        Public Sub insertar(ByVal idCliente As Integer, ByVal monto As Decimal, ByVal fechaini As Date, ByVal fechafin As Date, ByVal intereses As Decimal)



            Try

                binding.Current("IdCliente") = idCliente
                binding.Current("Monto") = monto
                binding.Current("FechaIni") = fechaini
                binding.Current("FechaFin") = fechafin
                binding.Current("Intereses") = intereses


                binding.EndEdit()
                Dim posicion

                cpta.Update(cpdt)
                posicion = binding.Position
                Me.cpta.Fill(cpdt)
                binding.Position = posicion

                MsgBox("Se guardo exitosamente la nueva deuda ", MsgBoxStyle.Information, "Prestamos")




            Catch ex As Exception

                MsgBox("No se pudo eliminar la deuda ", MsgBoxStyle.Critical, "Prestamos")
            End Try




        End Sub


        Public Sub eliminar()

            Try
                Dim posicion

                If MsgBox("En realidad desea usted eliminar la cuenta?", MsgBoxStyle.YesNo) = vbYes Then
                    binding.RemoveCurrent()
                    binding.EndEdit()
                    cpta.Update(cpdt)
                    posicion = binding.Position
                    Me.cpta.Fill(cpdt)
                    binding.Position = posicion



                End If



            Catch ex As Exception

                MsgBox("Se ha producido un error : Usted esta tratando de eliminar registros que estan siendo utilizados en otras tablas ", MsgBoxStyle.Critical, "Prestamos")
                Dim posicion = binding.Position
                Me.cpta.Fill(cpdt)
                binding.Position = posicion



            End Try






        End Sub




    End Class



    Public Class abonos



        Private adt As PrestamosDataSet.AbonosDataTable
        Private ata As PrestamosDataSetTableAdapters.AbonosTableAdapter
        Private binding As BindingSource
        Private Shared abo As abonos = Nothing

        Public Sub New()

            adt = New PrestamosDataSet.AbonosDataTable
            ata = New PrestamosDataSetTableAdapters.AbonosTableAdapter

            ata.Fill(adt)
            binding = New BindingSource
            binding.DataSource = adt

        End Sub


        Public Shared Function Instanciar() As abonos


            If IsNothing(abo) Then
                abo = New abonos



            End If
            Return abo

        End Function


        Public ReadOnly Property _biding As BindingSource
            Get
                Return binding
            End Get
        End Property


        Public Sub insertar(ByVal idCuenta As Integer, ByVal fecha As Date, ByVal monto As Decimal)

            Dim nuevoahorro As PrestamosDataSet.AbonosRow
            nuevoahorro = adt.NewAbonosRow

            nuevoahorro.idCuenta = idCuenta
            nuevoahorro.Fecha = fecha
            nuevoahorro.Monto = monto
            adt.AddAbonosRow(nuevoahorro)
            ata.Update(adt)

        End Sub


        Public Sub eliminar()


            Dim dr As DataRowView

            dr = CType(_biding.Current, DataRowView)
            dr.Delete()
            ata.Update(adt)



        End Sub
       



        Public Function ObtenerAbonos(ByVal cuenta As Integer) As DataRow

            'Pendiente por error
            ' Dim dr() As Data.DataRow

            'dr = adt.Select("IdCuenta =" & cuenta)
            'Return dr

        End Function



        Public Function ObtenerUltimo(ByVal cuenta As Integer) As Date

            Dim dr() As Data.DataRow
            Dim cue As String
            Dim i As Integer
            Dim fecha As Date
            cue = "IdCuenta" + CStr(cuenta)
            dr = adt.Select(cue)

            For i = 0 To dr.Count - 2

                fecha = CDate(dr(i).Item(2))

                If fecha < CDate(dr(i).Item("fecha")) Then
                    fecha = CDate(dr(i + 1).Item("Fecha"))

                End If

            Next

            Return fecha

        End Function







    End Class



End Namespace
