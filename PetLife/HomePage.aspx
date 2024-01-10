<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="PetLife.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home Page</title>
    <style>
        body {
            background-image: url('https://i.ibb.co/S6TddSL/Whats-App-G-rsel-2024-01-08-saat-22-17-01-dd2956e8.jpg'); /* Replace with your image URL */
            background-size: 100%,100%;
            background-repeat: no-repeat;
            background-position: top;
            display: flex;

            
        }

        .header {
            display: flex;
            justify-content: space-between;
            align-items: center;
            width: 100%;
            padding: 50px;
        }

        .logo {
            width: 200px; /* Adjust the size as needed */
            height: 200px; /* Adjust the size as needed */
        }

        .add-animal-button {
            position:fixed;
            bottom:140px;
            left:70px;
            border: 1px solid #ffffff;
            border-radius: 50px;
            padding: 15px 25px;
            background-color: #ffffff;
            color: #000000;
            cursor: pointer;
            transition: background-color 0.3s;
            
        }

        .button-container {
            display: flex;
            margin-top: 20px;
        }

        .button {
            margin: 0 15px; /* More space between buttons */
            padding: 10px 20px;
            font-size: 16px;
            background-color: rgba(52, 152, 219, 0.2);
            color: #ffffff;
            border: 1px solid #ffffff;
            border-radius: 50px;
            cursor: pointer;
            transition: opacity 0.3s;
        }

        .button:hover {
            opacity: 0.4;
        }

        .add-animal-button:hover {
            background-color: #bdc3c7; /* Adjust the color as needed */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <img class="logo" src="https://i.ibb.co/pRsC8Gx/Whats-App-G-rsel-2024-01-08-saat-22-15-28-07896cd6-removebg-preview.png" alt="Logo" /> <!-- Replace with your logo image URL -->
            <div class="button-container">
                <asp:Button runat="server" ID="Button1" Text="Ana Sayfa" CssClass="button" OnClientClick="return false;" />
                <asp:Button runat="server" ID="Button2" Text="Dostlarım" CssClass="button" OnClientClick="return false;" />
                <asp:Button runat="server" ID="Button3" Text="Alarmlarım" CssClass="button" OnClientClick="return false;" />
                <asp:Button runat="server" ID="Button4" Text="Keşfet" CssClass="button" OnClientClick="return false;" />
                <asp:Button runat="server" ID="Button5" Text="Profilim" CssClass="button" OnClientClick="return false;" />
            </div>
        </div>
        <button class="add-animal-button" type="button">Hayvan Ekle</button>
    </form>
</body>
</html>
