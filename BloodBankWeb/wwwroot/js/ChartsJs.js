
$.get({
    url: '/Home/GetDataOfChart'
    , success: function (data) {
        console.log(data)
        var options = {
            chart: {
                type: 'bar',
                height : 300
            },
            series: [{
                name: 'bag',
                data: data.map(i=>i.value)
            }],
            xaxis: {
                categories: data.map(i => i.label)
            }
         
        }

        var chart = new ApexCharts(document.querySelector("#chart"), options);

        chart.render();
    }
    , error: function (e) {
        console.log(e.error);
        console.log(e.responseText);
    }
});



