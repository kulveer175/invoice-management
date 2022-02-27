<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login | Invoice Management</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/css/bootstrap.min.css" integrity="sha384-B0vP5xmATw1+K9KRQjQERJvTumQW0nPEzvF6L/Z6nronJ3oUOFUFpCjEUQouq2+l" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js" integrity="sha384-Piv4xVNRyMGpqkS2by6br4gNJ7DXjqk09RmUpJ8jgGtD7zP9yug3goQfGII0yAns" crossorigin="anonymous"></script>
    <style>
        html,
        body {
            height: 100%;
        }

        body {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: center;
            align-items: center;
            padding-top: 40px;
            padding-bottom: 40px;
            background-color: #f5f5f5;
        }

        #passwordContainer {
            position: relative;
        }

            #passwordContainer img {
                position: absolute;
                height: 66%;
                width: 9%;
                top: 9px;
                right: 9px;
                z-index: 3;
            }

        .form-signin {
            width: 100%;
            max-width: 330px;
            padding: 15px;
            margin: auto;
        }

            .form-signin .checkbox {
                font-weight: 400;
            }

            .form-signin .form-control {
                position: relative;
                box-sizing: border-box;
                height: auto;
                padding: 10px;
                font-size: 16px;
            }

                .form-signin .form-control:focus {
                    z-index: 2;
                }

            .form-signin #LoginControl_UserName /*input[type="text"]*/ {
                margin-bottom: -1px;
                border-bottom-right-radius: 0;
                border-bottom-left-radius: 0;
            }

            .form-signin #LoginControl_Password /*input[type="password"]*/ {
                margin-bottom: 10px;
                border-top-left-radius: 0;
                border-top-right-radius: 0;
            }
    </style>
</head>
<body>
    <form id="form1" class="form-signin text-center" runat="server">
        <div>
            <nav class="navbar navbar-expand-md navbar-dark bg-dark fixed-top">
                <a class="navbar-brand" href="#">
                    Invoice Management
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarsExampleDefault" aria-controls="navbarsExampleDefault" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarNav">
                    <ul class="navbar-nav">
                    </ul>
                </div>
            </nav>
            <asp:Login ID="LoginControl" runat="server" EnableTheming="true" Width="100%" OnLoggedIn="LoginControl_LoggedIn">
                <LayoutTemplate>
                    <div>
                        <asp:Image CssClass="mb-4" ImageUrl="./assets/images/logo.svg" runat="server" Width="72" Height="72" />
                        <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>
                        <asp:TextBox ID="UserName" CssClass="form-control" required placeholder="Email Address" runat="server"></asp:TextBox>
                        <div id="passwordContainer">
                            <asp:TextBox ID="Password" runat="server" CssClass="form-control" required placeholder="Password" TextMode="Password"></asp:TextBox>
                            <asp:Image ID="Eye" runat="server" ImageUrl="~/assets/images/eye.png" onclick="togglePassword()" />
                        </div>
                        <div class="checkbox mb-3">
                            <label>
                                <asp:CheckBox ID="RememberMe" runat="server" />
                                Remember me
                            </label>
                        </div>
                        <asp:Button ID="LoginButton" runat="server" CssClass="btn btn-lg btn-primary btn-block" CommandName="Login" Text="Log In" ValidationGroup="ctl03" />
                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="ctl03">*</asp:RequiredFieldValidator>
                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="ctl03">*</asp:RequiredFieldValidator>
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        <p class="mt-5 mb-3 text-muted">&copy; 2021</p>
                    </div>
                </LayoutTemplate>
            </asp:Login>
        </div>
    </form>
    <script>
        var showPassword = true;

        function togglePassword() {
            document.getElementById('LoginControl_Password').type = showPassword ? 'text' : 'password';
            showPassword = !showPassword;
        }
    </script>
</body>
</html>
