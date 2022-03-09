<%@ Page Title="Admin Home | Invoice Management" Language="C#" MasterPageFile="~/AdminSectionLayout.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.AdminSection.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Home Page</h2>
    <div class="row">
        <div class="col-6">
            <canvas id="dateRevenue"></canvas>
        </div>
        <div class="col-6">
            <canvas id="clientRevenue"></canvas>
        </div>
    </div>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.5.1/chart.min.js" integrity="sha512-Wt1bJGtlnMtGP0dqNFH1xlkLBNpEodaiQ8ZN5JLA5wpc1sUlk/O5uuOMNgvzddzkpvZ9GLyYNa8w2s7rqiTk5Q==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script>
        var labels = [];
        var data = [];
        <% for (int i = 0; i < clientNames.Length; i++) {%>
        labels.push("<%= clientNames[i] %>");
        data.push(<%= totalRevenue[i] %>);
        <% } %>
        var clientRevenue = document.getElementById('clientRevenue').getContext('2d');
        var myChart = new Chart(clientRevenue, {
            type: 'bar',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Total revenue from clients',
                    data: data,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                        'rgba(54, 162, 235, 0.2)',
                        'rgba(255, 206, 86, 0.2)',
                        'rgba(75, 192, 192, 0.2)',
                        'rgba(153, 102, 255, 0.2)',
                        'rgba(255, 159, 64, 0.2)'
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                        'rgba(54, 162, 235, 1)',
                        'rgba(255, 206, 86, 1)',
                        'rgba(75, 192, 192, 1)',
                        'rgba(153, 102, 255, 1)',
                        'rgba(255, 159, 64, 1)'
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });

        labels = [];
        data = [];
        <% for (int i = 0; i < clientNames.Length; i++) {%>
        labels.push("<%= dates[i] %>");
        data.push(<%= dateRevenue[i] %>);
        <% } %>
        var dateRevenue = document.getElementById('dateRevenue').getContext('2d');
        var newChart = new Chart(dateRevenue, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Total revenue for Dates',
                    data: data,
                    backgroundColor: [
                        'rgba(255, 99, 132, 0.2)',
                    ],
                    borderColor: [
                        'rgba(255, 99, 132, 1)',
                    ],
                    borderWidth: 1
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    </script>
</asp:Content>
