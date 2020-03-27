<%@ Page Language="VB" MasterPageFile="~/SiteMaster.master" CodeFile="RecoverPassword.aspx.vb" Inherits="RecoverPassword_aspx" Title="Recover Password" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Recover Password</h2>

<asp:passwordrecovery OnSendMailError="SendMailError" id="PasswordRecovery1" runat="server" SubmitButtonText="Send My Password" UserNameInstructionText="">
    <QuestionTemplate>
        <table border="0" cellpadding="1">
            <tr>
                <td>
                    <table border="0" cellpadding="0">
                        <tr>
                            <td align="left" colspan="2">
                                <strong>We must confirm your identity. Please answer the following:</strong></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                User Name:</td>
                            <td>
                                <asp:Literal ID="UserName" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Question:</td>
                            <td>
                                <asp:Literal ID="Question" runat="server"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Answer:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                    ErrorMessage="Answer is required." ToolTip="Answer is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="color: red">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Send My Password"
                                    ValidationGroup="PasswordRecovery1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </QuestionTemplate>
    <UserNameTemplate>
        <table border="0" cellpadding="1">
            <tr>
                <td>
                    <table border="0" cellpadding="0">
                        <tr>
                            <td align="left" colspan="2">
                                <strong>Forgot Your Password? Enter your user name:</strong></td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="color: red">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2">
                                <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="Send My Password"
                                    ValidationGroup="PasswordRecovery1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </UserNameTemplate>
</asp:passwordrecovery>

<br />
<br />
<br />
<br />
</asp:content>
