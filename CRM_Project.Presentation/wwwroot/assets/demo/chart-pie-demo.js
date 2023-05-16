// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Pie Chart Example
var ctx = document.getElementById("myPieChart");
var num = parseFloat(document.getElementById('c1').innerText);
var num2 = parseFloat(document.getElementById('c2').innerText);
var label1 = document.getElementById('l1').innerText;
var label2 = document.getElementById('l2').innerText;
var myPieChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: [label1, label2],
        datasets: [{
            data: [num2, num],
            backgroundColor: ['#dc3545', '#28a745'],
        }],
    },
});
