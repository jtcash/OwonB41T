Imports System.Reflection
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Form_Plot


    Private Database(100) As Decimal
    Private Database_Count As Integer = 0



    Private Sub Form_Plot_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Invoke(New EventHandler(AddressOf Plot_Value))

    End Sub
    Private Sub Form_Plot_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Form1.Polt_Open = False

    End Sub



    Private Sub Timer_ReadValue_Tick(sender As Object, e As EventArgs) Handles Timer_ReadValue.Tick

        'Read value


        Database(Database_Count) = Form1.Dec_Value / Form1.Dev_Value

            Database_Count += 1

            If Database_Count >= Database.Length Then

                Database_Count = 99

                For index = 0 To Database.Length - 2

                    Database(index) = Database(index + 1)

                Next
            End If

            Plot_Values()

    End Sub


    Private Sub Plot_Values()

        Chart_Plot.Series("Series_Plot").Points.Clear()
        For index = 0 To Database_Count

            Chart_Plot.Series("Series_Plot").Points.AddXY(index, Database(index))

        Next

    End Sub


End Class