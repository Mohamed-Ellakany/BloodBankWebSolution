function renderBloodBankChart(data) {
    var normalizedData = data.map(function (item) {
        return {
            label: item.bloodTypeName || item.BloodTypeName || item.label || item.Label,
            value: item.count || item.Count || item.value || item.Value || 0
        };
    });

    var options = {
        chart: {
            type: 'bar',
            height: 300
        },
        series: [{
            name: 'bag',
            data: normalizedData.map(function (item) { return item.value; })
        }],
        xaxis: {
            categories: normalizedData.map(function (item) { return item.label; })
        }
    };

    var chart = new ApexCharts(document.querySelector("#chart"), options);

    chart.render();
}

if (window.bloodBankChartData) {
    renderBloodBankChart(window.bloodBankChartData);
} else {
    $.get({
        url: '/Home/GetDataOfChart',
        success: renderBloodBankChart,
        error: function (e) {
            console.log(e.error);
            console.log(e.responseText);
        }
    });
}
