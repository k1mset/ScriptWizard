Public Class frmEditor

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click
        Generate.script.Text = generator.generate(cmbTarget.SelectedItem, chkInstant.Checked, chkProg.Checked, cmbProgType.SelectedItem)
        Generate.Visible = True
    End Sub
End Class