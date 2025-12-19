Imports System
Imports System.Windows.Forms
Imports System.Collections.Generic
Imports Transbank.POSIntegrado
Imports Transbank.Exceptions.CommonExceptions
Imports Transbank.Exceptions.IntegradoExceptions
Imports Transbank.Responses.CommonResponses
Imports Transbank.Responses.IntegradoResponses
Imports System.Threading.Tasks

Public Class FrmPos

    Private portName As String = ""
    Private total As Integer = 0
    Private intermediateMsg As Boolean = False
    Private eventResponseMessage As String = ""

    Private ReadOnly internalItems As List(Of class_producto) = New List(Of class_producto)() From {
        New class_producto With {.Name = "Café", .Price = 5},
        New class_producto With {.Name = "Jugo", .Price = 4},
        New class_producto With {.Name = "Galletas", .Price = 10},
        New class_producto With {.Name = "Helado", .Price = 10},
        New class_producto With {.Name = "Donut", .Price = 20},
        New class_producto With {.Name = "Pizza", .Price = 30},
        New class_producto With {.Name = "Ensalada", .Price = 1},
        New class_producto With {.Name = "Hamburguesa", .Price = 2},
        New class_producto With {.Name = "Papitas", .Price = 3}
    }

    Public ReadOnly Property BuyItems As List(Of class_producto)

    Public Sub New()
        CenterToScreen()
        InitializeComponent()
        PortName_lbl.Text = portName
        Port_ddown.DataSource = POSIntegrado.Instance.ListPorts()
        portName = Port_ddown.SelectedItem.ToString()
        Price_lbl.Text = total.ToString()
        BuyItems = New List(Of class_producto)()
        AddHandler POSIntegrado.Instance.IntermediateResponseChange, New EventHandler(Of IntermediateResponse)(Sub(s, response) UpdateMessage(s, response))
    End Sub

    Private Sub PortDropDown_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Port_ddown.SelectedIndexChanged
        portName = Port_ddown.SelectedItem.ToString()
    End Sub

    Private Sub pollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles pollToolStripMenuItem.Click
        Try
            Dim pollResult As Task(Of Boolean) = Task.Run(Async Function() Await POSIntegrado.Instance.Poll())
            pollResult.Wait()

            If pollResult.Result Then
                MessageBox.Show("POS está conectado.", "Polling POS")
            Else
                MessageBox.Show("POS NO está conectado.", "Polling POS")
            End If

        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try

    End Sub

    Private Sub Connect_btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Connect_btn.Click
        Try
            POSIntegrado.Instance.OpenPort(portName)
            PortName_lbl.Text = portName
        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub Disconnect_btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Disconnect_btn.Click
        Try
            POSIntegrado.Instance.ClosePort()
            PortName_lbl.Text = ""
        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub LoadKeysToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadKeysToolStripMenuItem.Click
        Try
            Dim response As Task(Of LoadKeysResponse) = POSIntegrado.Instance.LoadKeys()
            response.Wait()

            If response.Result.Success Then
                MessageBox.Show(response.Result.ToString(), "Keys cargadas satisfactoriamente.")
            End If

        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseToolStripMenuItem.Click
        Try
            Dim response As Task(Of CloseResponse) = POSIntegrado.Instance.Close()
            response.Wait()

            If response.Result.Success Then
                MessageBox.Show(response.Result.ToString(), "Registro cerrado satisfactoriamente.")
            End If

        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub SetNormalModeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles setNormalModeToolStripMenuItem.Click
        Try
            Dim dialogResult As DialogResult = MessageBox.Show("Cambiar a Modo Noraml desconectará el POS" & vbLf & " ¿ está seguro ?", "Cambiar a Modo Normal", MessageBoxButtons.YesNo)

            If dialogResult = DialogResult.Yes Then
                Dim result As Task(Of Boolean) = Task.Run(Async Function() Await POSIntegrado.Instance.SetNormalMode())
                result.Wait()

                'Dim result As Boolean = Await POSIntegrado.Instance.SetNormalMode()
                'result.Wait()

                If result.Result Then
                    MessageBox.Show("POS configurado en Modo Normal")
                    Disconnect_btn_Click(sender, e)
                Else
                    MessageBox.Show("Falla al configurar el POS en modo Normal")
                End If

                Disconnect_btn_Click(sender, e)
            End If

        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub AddItemToShoppingCart(ByVal class_producto As class_producto)
        Dim item As ListViewItem = New ListViewItem(class_producto.Row) With {
            .Tag = class_producto
        }
        ShopingList_lst.Items.Add(item)
        total += class_producto.Price
        Price_lbl.Text = total.ToString()
        Price_lbl.Refresh()
    End Sub

    Private Sub Cofee_Click(sender As Object, e As EventArgs) Handles Cofee_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Café"))
    End Sub

    Private Sub Juice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Juice_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Jugo"))
    End Sub

    Private Sub Cookies_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Cookies_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Galletas"))
    End Sub

    Private Sub Icecream_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Icecream_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Helado"))
    End Sub

    Private Sub Pizza_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Pizza_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Pizza"))
    End Sub

    Private Sub Donut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Donut_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Donut"))
    End Sub

    Private Sub Burger_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Burger_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Hamburguesa"))
    End Sub

    Private Sub Salad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Salad_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Ensalada"))
    End Sub

    Private Sub Fries_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Fries_img.Click
        AddItemToShoppingCart(internalItems.Find(Function(product) product.Name = "Papitas"))
    End Sub

    Private Sub CarroCompraList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ShopingList_lst.SelectedIndexChanged
        Dim remove As ListView.SelectedListViewItemCollection = ShopingList_lst.SelectedItems

        For Each item As ListViewItem In remove
            total -= (CType(item.Tag, class_producto)).Price
            ShopingList_lst.Items.Remove(item)
            Price_lbl.Text = total.ToString()
            Price_lbl.Refresh()
        Next
    End Sub

    Protected Sub Clean_btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Clean_btn.Click
        ShopingList_lst.Items.Clear()
        total = 0
        Price_lbl.Text = total.ToString()
        Price_lbl.Refresh()
    End Sub

    Private Sub Pay_btn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Pay_btn.Click
        eventResponseMessage = ""

        Try

            If total > 0 AndAlso ShopingList_lst.Items.Count > 0 Then
                Dim ticket As String = New Random().[Next](0, 999999).ToString("D6")
                Dim response As Task(Of SaleResponse) = POSIntegrado.Instance.Sale(total, ticket, intermediateMsg)
                response.Wait()
                MessageBox.Show(response.Result.ToString())
                Clean_btn_Click(sender, e)
            Else
                MessageBox.Show("No hay elementos para cobrar o el total es 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If

        Catch a As TransbankSaleException
            MessageBox.Show("Error Procesando el Pago" & vbLf & a.SaleResponse.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        Catch a As TransbankException
            MessageBox.Show(a.Message & vbLf + a.Data.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub getTotalsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles getTotalsToolStripMenuItem.Click
        Try
            Dim response As Task(Of TotalsResponse) = POSIntegrado.Instance.Totals()
            response.Wait()

            If response.Result.Success Then
                MessageBox.Show(response.Result.ToString(), "Totales obtenidos satisfactoriamente.")
            End If

        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub lastSaleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lastSaleToolStripMenuItem.Click
        Try
            Dim response As Task(Of LastSaleResponse) = POSIntegrado.Instance.LastSale()
            response.Wait()

            If response.Result.Success Then
                MessageBox.Show(response.Result.ToString(), "Última venta obtenida satisfactoriamente.")
            End If

        Catch a As TransbankException
            MessageBox.Show(a.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
        End Try
    End Sub

    Private Sub refundToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles refundToolStripMenuItem.Click
        Dim p As Form = New RefundPrompt()
        p.Show()
        p.Focus()
    End Sub

    Private Sub salesDetailToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles salesDetailToolStripMenuItem.Click
        Dim p As Form = New DetailPrompt()
        p.Show()
        p.Focus()
    End Sub

    Private Sub toolStripComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripComboBox1.Click
        If toolStripComboBox1.SelectedIndex = 0 Then
            intermediateMsg = True
        Else
            intermediateMsg = False
        End If
    End Sub

    Private Sub UpdateMessage(ByVal sender As Object, ByVal response As IntermediateResponse)
        If eventResponseMessage <> response.ResponseMessage Then intermediateMsgTxtBox.Text += $"{response.ResponseMessage}\r\n"
        intermediateMsgTxtBox.SelectionStart = intermediateMsgTxtBox.Text.Length
        intermediateMsgTxtBox.ScrollToCaret()
        Refresh()
        eventResponseMessage = response.ResponseMessage
    End Sub

End Class