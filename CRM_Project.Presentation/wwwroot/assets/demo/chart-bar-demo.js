// Set new default font family and font color to mimic Bootstrap's default styling
Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
Chart.defaults.global.defaultFontColor = '#292b2c';

// Bar Chart Example
var ctx = document.getElementById("myBarChart");
var qlabels = document.querySelectorAll(".ll1");
var qdatas = document.querySelectorAll(".dd1");
var arrlabels = new Array();
var arrdatas = new Array();
for (var i = 0; i < qlabels.length;i++) {
    arrlabels[i] = qlabels[i].innerHTML;
}
for (var i = 0; i < qlabels.length; i++) {
    arrdatas[i] = qdatas[i].innerHTML;
}
var myLineChart = new Chart(ctx, {
  type: 'bar',
  data: {
      labels: arrlabels,
    datasets: [{
      label: "Eklenen Servis Adimi",
      backgroundColor: "rgba(2,117,216,1)",
      borderColor: "rgba(2,117,216,1)",
        data: arrdatas,
    }],
  },
  options: {
    scales: {
      xAxes: [{
        time: {
          unit: 'month'
        },
        gridLines: {
          display: false
        },
        ticks: {
          maxTicksLimit: 6
        }
      }],
      yAxes: [{
        ticks: {
          min: 0,
          max: 10,
          maxTicksLimit: 5
        },
        gridLines: {
          display: true
        }
      }],
    },
    legend: {
      display: false
    }
  }
});
