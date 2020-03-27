Imports System.Text.RegularExpressions
Imports System.IO

Public Class Form1

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Load in the sample text
        LoadTextFile()

        Me.SplitResultsView.Columns(0).Width = Me.SplitResultsView.Width
    End Sub

    Private Sub Test_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Test.Click
        If regularExpression.Text.Length > 0 And searchText.Text.Length > 0 Then
            Try
                TestExpression(regularExpression.Text)
            Catch ex As Exception
                MessageBox.Show("There was an error while executing the search" & vbCrLf & ex.Message, "Regex Tester", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Else
            MessageBox.Show("You must enter an expression and text to search first", "Regex Tester", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TestExpression(ByVal testExpression As String)

        ' Create the regex options and assign the options
        Dim regex As Regex = New Regex(testExpression, SetRegexOptions)

        ' populate the match collection based on the expression
        Dim matches As MatchCollection = regex.Matches(searchText.Text)

        ' If there were any groups get them
        Dim groupNumbers As Integer() = regex.GetGroupNumbers

        ' Add the results to the results list view
        SetupResultList(groupNumbers, matches)

        ' Highlight the matches in the search text
        SetupSearchText(matches)

    End Sub

    Private Function Split(ByVal splitExpression As String, ByVal maxElements As Integer, ByVal startPosition As Integer) As String()

        ' Using the split value break the text into seperate strings and return in array
        Try
            Dim regex As Regex = New Regex(splitExpression, SetRegexOptions)
            Return regex.Split(searchText.Text, maxElements, startPosition)
        Catch ex As ArgumentException
            MessageBox.Show("The Split operation failed with the following message:" & vbCrLf & ex.Message, "Regular Expression Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Private Function Replace(ByVal replaceExpression As String) As String

        ' using the replace expression find the matches
        ' each match is handled in the MatchEvaluator delegate function
        Try
            Dim regex As Regex = New Regex(replaceExpression, SetRegexOptions)
            Return regex.Replace(searchText.Text, New MatchEvaluator(AddressOf ReplaceIt))
        Catch ex As ArgumentException
            MessageBox.Show("You entered an invalid character" & vbCrLf & vbCrLf & "The " & replaceExpression & " character is not valid" & vbCrLf & ex.Message, "Regular Expression Sample", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try

    End Function

    Private Function ReplaceIt(ByVal match As Match) As String

        ' Do the actual replace once a match has been made
        Dim resultString As String = match.ToString
        Dim replaceString As String = Me.ReplaceWith.Text
        Return resultString.Replace(match.ToString, replaceString)

    End Function

    Private Function SetRegexOptions() As RegexOptions

        ' first set up the various options based on the check boxes checked
        Dim options As RegexOptions = New RegexOptions

        If Me.IsRegexOptionsNone.Checked Then
            ' // No options so no need to check the other settings
            options = options Or RegexOptions.None
            Return options
        End If

        If Me.IsRegexCompiled.Checked Then
            options = options Or RegexOptions.Compiled
        End If
        If Me.IsRegexCultureInvariant.Checked Then
            options = options Or RegexOptions.CultureInvariant
        End If
        If Me.IsRegexExplicitCapture.Checked Then
            options = options Or RegexOptions.ExplicitCapture
        End If
        If Me.IsRegexIgnoreCase.Checked Then
            options = options Or RegexOptions.IgnoreCase
        End If
        If Me.IsRegexIgnorePatternWhitespace.Checked Then
            options = options Or RegexOptions.IgnorePatternWhitespace
        End If
        If Me.IsRegexMultiline.Checked Then
            options = options Or RegexOptions.Multiline
        End If
        If Me.IsRegexRightToLeft.Checked Then
            options = options Or RegexOptions.RightToLeft
        End If
        If Me.IsRegexSingleline.Checked Then
            options = options Or RegexOptions.Singleline
        End If

        Return options

    End Function

    Private Sub LoadTextFile()

        'read the text from the sample file into the textbox
        Dim sourceFile As String = Path.Combine(Application.StartupPath, "sample.txt")

        If File.Exists(sourceFile) Then
            Me.searchText.Text = File.ReadAllText(sourceFile)
        End If

    End Sub

    Private Sub SetupResultList(ByVal groupNumbers As Integer(), ByVal matches As MatchCollection)

        Me.resultsView.Clear()

        ' set up the standard columns
        Me.resultsView.Columns.Add("Match", CType(Me.resultsView.Width / 2, Integer))
        Me.resultsView.Columns.Add("Position", CType(Me.resultsView.Width / 4, Integer))
        Me.resultsView.Columns.Add("Length", CType(Me.resultsView.Width / 4, Integer))

        ' if there are goups in the expression add a column for each group
        For Each groupNumber As Integer In groupNumbers
            If groupNumber > 0 Then
                Me.resultsView.Columns.Add("Group " + groupNumber.ToString, 100, HorizontalAlignment.Left)
            End If
        Next

        Me.resultsView.Items.Clear()

        ' add all matches to the list
        For Each match As Match In matches
            Dim listViewItem As ListViewItem = Me.resultsView.Items.Add(match.ToString)
            listViewItem.SubItems.Add(match.Index.ToString)
            listViewItem.SubItems.Add(match.Length.ToString)
            Dim groupNumber As Integer = 1
            While groupNumber < match.Groups.Count
                listViewItem.SubItems.Add(match.Groups(groupNumber).Value)
                System.Math.Min(System.Threading.Interlocked.Increment(groupNumber), groupNumber - 1)
            End While
        Next

    End Sub

    Private Sub SetupSearchText(ByVal matches As MatchCollection)

        ' Highlight each match in the text in red
        Me.searchText.HideSelection = True
        Me.searchText.SelectAll()
        Me.searchText.SelectionColor = Color.Black

        For Each match As Match In matches
            Me.searchText.Select(match.Index, match.Length)
            Me.searchText.SelectionColor = Color.Red
        Next

        Me.searchText.Select(0, 0)
        Me.searchText.SelectionColor = Color.Black
        Me.resultsCount.Text = matches.Count.ToString + " matches found"

    End Sub

    Private Sub resultsView_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resultsView.SelectedIndexChanged

        ' Show the selected text in the search text
        If Me.resultsView.SelectedItems.Count > 0 Then
            Me.searchText.HideSelection = False
            Me.searchText.Select(0, 0)
            Me.searchText.Select(Int32.Parse(Me.resultsView.SelectedItems(0).SubItems(1).Text), Int32.Parse(Me.resultsView.SelectedItems(0).SubItems(2).Text))
        End If

    End Sub

    Private Sub IsRegexOptionsNone_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IsRegexOptionsNone.CheckedChanged

        'If the Option none is checked then uncheck all others
        If Me.IsRegexOptionsNone.Checked = True Then
            For Each control As Control In Me.groupBox6.Controls
                Dim checkbox As CheckBox = CType(control, CheckBox)
                If Not (checkbox Is Nothing) Then
                    If Not (checkbox Is Me.IsRegexOptionsNone) AndAlso checkbox.Checked = True Then
                        RemoveHandler checkbox.CheckedChanged, AddressOf Me.OtherOptions_CheckChanges
                        checkbox.Checked = False
                        AddHandler checkbox.CheckedChanged, AddressOf Me.OtherOptions_CheckChanges
                    End If
                End If
            Next
        End If

    End Sub

    Private Sub OtherOptions_CheckChanges(ByVal sender As Object, ByVal e As EventArgs) Handles IsRegexSingleline.CheckedChanged, IsRegexRightToLeft.CheckedChanged, IsRegexMultiline.CheckedChanged, IsRegexIgnorePatternWhitespace.CheckedChanged, IsRegexIgnoreCase.CheckedChanged, IsRegexExplicitCapture.CheckedChanged, IsRegexCultureInvariant.CheckedChanged, IsRegexCompiled.CheckedChanged

        ' If any option is checked then uncheck None
        If Me.IsRegexOptionsNone.Checked = True Then
            Me.IsRegexOptionsNone.Checked = False
        End If

    End Sub

    Private Sub SplitText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SplitText.Click

        ' Add each split string to the results list
        Me.SplitResultsView.Items.Clear()
        If Me.SplitExpression.Text.Length > 0 AndAlso Me.SplitMaxElements.Text.Length > 0 AndAlso Me.SplitStartPosition.Text.Length > 0 Then
            Dim maxElements As Integer
            Dim startPostion As Integer
            Dim result As String()
            Try
                maxElements = Convert.ToInt32(Me.SplitMaxElements.Text)
                startPostion = Convert.ToInt32(Me.SplitStartPosition.Text)
                result = Me.Split(Me.SplitExpression.Text, maxElements, startPostion)
                If result Is Nothing Then
                    MessageBox.Show("The split expression returned an error. Please try another expression", "Regex Tester", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                    Return
                End If
                For Each splitChunk As String In result
                    Me.SplitResultsView.Items.Add(New ListViewItem(splitChunk))
                Next
            Catch ex As FormatException
                MessageBox.Show("You must enter a valid Integer" & ex.Message, "Regex Tester", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
        Else
            MessageBox.Show("You must enter an expression, Max Elements and Start Position Value first", "Regex Tester", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End If
    End Sub

    Private Sub TextReplace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextReplace.Click

        If Me.ReplaceFindWhat.Text.Length > 0 AndAlso Me.ReplaceWith.Text.Length > 0 Then

            Dim result As String = Me.Replace(ReplaceFindWhat.Text)
            If Not result Is Nothing Then
                If result.Length > 0 Then
                    Me.searchText.Text = result
                End If
            End If
        End If

    End Sub


End Class
