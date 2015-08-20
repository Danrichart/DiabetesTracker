$(document).ready(function () {
    var options = {
        chart: {
            renderTo: 'chart',
            type: 'line',
            zoomType: 'x'
        },
        title: {
            text: 'Diabetes Charts',
        },
        subtitle: {
            text: document.ontouchstart === undefined ?
                    'Click and drag in the plot area to zoom in' : 'Pinch the chart to zoom in'
        },
        xAxis: {
            type: 'datetime',
            title: {
                text: 'Date'
            },
           
        },
        yAxis: [{
            title: {
                text: 'Blood Sugar Levels(mg/dl)'
            },
            id: "blood-sugar",
            opposite: false,
            showEmpty: false
        },
        {
            title: {
                text: 'Weight(lbs)'
            },
            id: "weight",
            opposite: false,
            showEmpty: false
        },
        {
            title: {
                text: 'A1C %'
            },
            id: "a1c",
            opposite: true,
            showEmpty: false
        },
        {
            title: {
                text: 'Carbohydrates(mg)'
            },
            id: "carbs",
            opposite: true,
            showEmpty: false
        }],
        plotOptions: {
            line: {
                marker: {
                    enable: true
                },
            }
        },
        series: []
    }



    var chart = new Highcharts.Chart(options)

    $("#graph-buttons button.btn").click(function () {
        $(this).toggleClass("active")
        var controlVal = this.innerHTML
        var tempBool = $(this).attr("value");
        
        var controlFlag = tempBool == "true" ? true : false
        switch (controlVal) {
            case 'Blood Sugar':
                controlFlag = !controlFlag
                controlFlag == true ? addChart(GetBloodSugarData) : removeChart(controlVal)
                $(this).val(controlFlag.toString())
                break;
            case 'Weight':
                controlFlag = !controlFlag
                controlFlag == true ? addChart(GetWeightData) : removeChart(controlVal)
                $(this).val(controlFlag.toString())
                break;
            case 'A1C':
                controlFlag = !controlFlag
                controlFlag == true ? addChart(GetA1CData) : removeChart(controlVal)
                $(this).val(controlFlag.toString())
                break;
            case 'Carbohydrates':
                controlFlag = !controlFlag
                controlFlag == true ? addChart(GetCarbData) : removeChart(controlVal)
                $(this).val(controlFlag.toString())
                break;
        }
        
    })

    function addChart(getDataFunction) {
        var addData = getDataFunction()
        chart.addSeries({
            type: 'line',
            name: addData.seriesName,
            data: addData.dataArray,
            yAxis: addData.yAxisId
        })
    }

    function removeChart(id) {
        var seriesLength = chart.series.length
        for (var i = 0; i < seriesLength; i++) {
            if (chart.series[i].name == id) {
                chart.series[i].remove()
            }
        }
    }

    function GetBloodSugarData() {
        var resultData
        $.ajax({
            url: '/Graphs/DisplayBloodSugar',
            dataType: 'json',
            async: false,
            success: function (data) {
                var dataArray = []
                for (var item in data) {
                   
                    dataArray.push([
                        parseInt(data[item].inputDate.substr(6)),
                        data[item].bloodSugarAmount 
                    ])
                }            
                resultData = { yAxisId: 'blood-sugar', titletext: "Blood Sugar", seriesName: "Blood Sugar", dataArray : dataArray}
            }
        })
        return resultData
    } //getBloodSugarData

    function GetWeightData() {
        var resultData
        $.ajax({
            url: '/Graphs/DisplayWeight',
            dataType: 'json',
            async: false,
            success: function (data) {
                var dataArray = []
                for (var item in data) {

                    dataArray.push([
                        parseInt(data[item].inputDate.substr(6)),
                        data[item].weightAmount
                    ])
                }
                resultData = { yAxisId: 'weight', titletext: "Weight", seriesName: "Weight", dataArray: dataArray }
            }
        })
        return resultData
    } //getWeightData

    function GetCarbData() {
        var resultData
        $.ajax({
            url: '/Graphs/DisplayCarbs',
            dataType: 'json',
            async: false,
            success: function (data) {
                var dataArray = []
                for (var item in data) {

                    dataArray.push([
                        parseInt(data[item].inputDate.substr(6)),
                        data[item].carbAmount
                    ])
                }
                resultData = { yAxisId: 'carbs', titletext: "Carbohydrate", seriesName: "Carbohydrates", dataArray: dataArray }
                
            }
        })
        return resultData
    } //getWeightData

    function GetA1CData() {
        var resultData
        $.ajax({
            url: '/Graphs/DisplayA1C',
            dataType: 'json',
            async: false,
            success: function (data) {
                var dataArray = []
                for (var item in data) {

                    dataArray.push([
                        parseInt(data[item].inputDate.substr(6)),
                        data[item].a1cAmount
                    ])
                }
                resultData = { yAxisId: 'a1c', titletext: "A1C", seriesName: "A1C", dataArray: dataArray }
                
            }
        })
        return resultData
    } //getWeightData
}) // documentready