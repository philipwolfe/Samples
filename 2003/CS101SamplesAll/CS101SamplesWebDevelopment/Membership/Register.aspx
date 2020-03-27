<%@ Page Language="C#" MasterPageFile="~/SiteMaster.master" CodeFile="Register.aspx.cs" Inherits="Register_aspx" Title="Register" %>
<asp:content contentplaceholderid="PageContent" runat="Server">
<h2>Register</h2>

<asp:createuserwizard id="CreateUserWizard1" runat="server" canceldestinationpageurl="~/Home.aspx" displaycancelbutton="True" logincreateduser="False" continuedestinationpageurl="~/login.aspx" ConfirmPasswordCompareErrorMessage="The passwords must match." DuplicateUserNameErrorMessage="User name already exists. Please enter a different user name.">
    <wizardsteps>
        <asp:createuserwizardstep runat="server">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td align="left" colspan="2">
                            <strong>Sign Up for Your New Account:</strong></td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label for="UserName">
                                User Name:</label></td>
                        <td>
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label for="Password">
                                Password:</label></td>
                        <td>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label for="ConfirmPassword">
                                Confirm Password:</label></td>
                        <td>
                            <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                                ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label for="Email">
                                E-mail:</label></td>
                        <td>
                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label for="Question">
                                Security Question:</label></td>
                        <td>
                            <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question"
                                ErrorMessage="Security question is required." ToolTip="Security question is required."
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <label for="Answer">
                                Security Answer:</label></td>
                        <td>
                            <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer"
                                ErrorMessage="Security answer is required." ToolTip="Security answer is required."
                                ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The passwords must match."
                                ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2" style="color: red">
                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:createuserwizardstep>
        <asp:completewizardstep runat="server">
            <ContentTemplate>
                <table border="0">
                    <tr>
                        <td align="left" colspan="2" style="height: 14px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Your account has been successfully created.</td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" CommandName="Continue"
                                Text="Continue" ValidationGroup="CreateUserWizard1" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:completewizardstep>
    </wizardsteps>
</asp:createuserwizard>

</asp:content>
